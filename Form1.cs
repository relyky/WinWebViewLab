using System.Net;
using System.Reflection.Metadata;
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
      // init
      cboStatus.SelectedIndex = 0;

      // init WebView2
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

    private async void button2_Click(object sender, EventArgs e)
    {
      labelResult.Text = string.Empty;
      progressBar.Value = 0;

      //string status = "disputed"; // All | open | disputed | inactive | resolved �C
      string status = (string)(cboStatus.Text ?? "ALL");

      string queryJs = $"document.querySelector('#edit-field-status-list-value').value = '{status}'; " 
        + @"document.querySelector('#views-exposed-form-itf-current-cases-block-1').submit();";
      await webAgent.CoreWebView2.ExecuteScriptAsync(queryJs);

      progressBar.Value = 10;

      // ���l�u��
      await Task.Delay(1000);
      progressBar.Value = 20;
      await Task.Delay(1000);
      progressBar.Value = 30;
      await Task.Delay(1000);
      progressBar.Value = 40;
      await Task.Delay(1000);
      progressBar.Value = 50;
      await Task.Delay(1000);
      progressBar.Value = 60;

      // �˵e���T�wstatus �d�߱���L�~!
      string regionResult = await webAgent.CoreWebView2.ExecuteScriptAsync(@"document.querySelector('#edit-field-region-target-id').value");
      string statusResult = await webAgent.CoreWebView2.ExecuteScriptAsync(@"document.querySelector('#edit-field-status-list-value').value");
      labelResult.Text = $"{regionResult} | {statusResult}";

      progressBar.Value = 70;

      // ���^��T html �Ϊ����� js ���ȥX��
      string html = await webAgent.CoreWebView2.ExecuteScriptAsync(@"document.querySelector('#block-views-block-itf-current-cases-block-1 > div > div > table > tbody').outerHTML");
      string decodedHtml = Regex.Unescape(html); // �� Unicode, \u003C => `<`
      string decodedHtml2 = WebUtility.HtmlDecode(decodedHtml); // �� 

      progressBar.Value = 80;

      // �ѪR��T => datainfo with RegEx 
      string dataTable = decodedHtml2;

      progressBar.Value = 100;
    }
  }
}
