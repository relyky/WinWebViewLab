using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace WinWebViewLab
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
      await webAgent.EnsureCoreWebView2Async(null);
      webAgent.CoreWebView2.Navigate("https://www.itfseafarers.org/en/abandonment-list/seafarer-abandonment");
    }

    private async void button1_Click(object sender, EventArgs e)
    {
      //string html = await webAgent.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
      string html = await webAgent.CoreWebView2.ExecuteScriptAsync(@"document.querySelector('#block-views-block-itf-current-cases-block-1 > div > div > table > tbody').outerHTML");
      string decodedHtml = Regex.Unescape(html); // �� Unicode, \u003C => `<`
      string decodedHtml2 = WebUtility.HtmlDecode(decodedHtml); // �� 

      // �ѪR��T => datainfo with RegEx ; �Ϊ����� js ���ȥX��
      string dataTable = decodedHtml2;
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }
  }
}
