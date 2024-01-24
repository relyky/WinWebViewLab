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
      string decodedHtml = Regex.Unescape(html); // 解 Unicode, \u003C => `<`
      string decodedHtml2 = WebUtility.HtmlDecode(decodedHtml); // 解 

      // 解析資訊 => datainfo with RegEx ; 或直接用 js 取值出來
      string dataTable = decodedHtml2;
    }

    private async void button2_Click(object sender, EventArgs e)
    {
      labelResult.Text = string.Empty;
      progressBar.Value = 0;

      //string status = "disputed"; // All | open | disputed | inactive | resolved 。
      string status = (string)(cboStatus.Text ?? "ALL");

      string queryJs = $"document.querySelector('#edit-field-status-list-value').value = '{status}'; " 
        + @"document.querySelector('#views-exposed-form-itf-current-cases-block-1').submit();";
      await webAgent.CoreWebView2.ExecuteScriptAsync(queryJs);

      progressBar.Value = 10;

      // 讓子彈飛
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

      // 檢畫面確定status 查詢條件無誤!
      string regionResult = await webAgent.CoreWebView2.ExecuteScriptAsync(@"document.querySelector('#edit-field-region-target-id').value");
      string statusResult = await webAgent.CoreWebView2.ExecuteScriptAsync(@"document.querySelector('#edit-field-status-list-value').value");
      labelResult.Text = $"{regionResult} | {statusResult}";

      progressBar.Value = 70;

      // 取回資訊 html 或直接用 js 取值出來
      string html = await webAgent.CoreWebView2.ExecuteScriptAsync(@"document.querySelector('#block-views-block-itf-current-cases-block-1 > div > div > table > tbody').outerHTML");
      string decodedHtml = Regex.Unescape(html); // 解 Unicode, \u003C => `<`
      string decodedHtml2 = WebUtility.HtmlDecode(decodedHtml); // 解 

      progressBar.Value = 80;

      // 解析資訊 => datainfo with RegEx 
      string dataTable = decodedHtml2;

      progressBar.Value = 100;
    }
  }
}
