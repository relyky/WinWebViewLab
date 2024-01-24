using System.Net;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace WinWebViewLab;

public partial class Form1 : Form
{
  const string simsRawHtml = """
    "<tbody>
    	<tr>
    		<td headers="view-field-vessel-name-table-column--Ot-rDmU5szg" class="views-field views-field-field-vessel-name">MARCO POLO          </td>
    		<td headers="view-field-imo-table-column--wAIKM3Uv4HQ" class="views-field views-field-field-imo">7821051          </td>
    		<td headers="view-field-flag-table-column--RRQ2RO19ykQ" class="views-field views-field-field-flag">Mauritius          </td>
    		<td headers="view-field-port-table-column--59gPpX0SLsk" class="views-field views-field-field-port">Luanda          </td>
    		<td headers="view-field-country-table-column--lHU25ouwYSA" class="views-field views-field-field-country">Angola          </td>
    		<td headers="view-field-owed-wages-table-column--iJAyZtc7OWg" class="views-field views-field-field-owed-wages">3 months          </td>
    		<td headers="view-field-seafarers-table-column--iPIRdzluh6M" class="views-field views-field-field-seafarers">17          </td>
    		<td headers="view-field-nationalities-table-column--SJMcoY774Wg" class="views-field views-field-field-nationalities">Angola, Russia, Ukraine          </td>
    		<td headers="view-field-reported-to-itf-table-column--SkM3UqLURFs" class="views-field views-field-field-reported-to-itf is-active">
    			<time datetime="2023-04-01T12:00:00Z">01 Apr 2023</time>
    		</td>
    		<td headers="view-field-status-list-table-column--xeRYwaEFJx4" class="views-field views-field-field-status-list">Inactive          </td>
    	</tr>
    	<tr>
    		<td headers="view-field-vessel-name-table-column--Ot-rDmU5szg" class="views-field views-field-field-vessel-name">PSL TIGER          </td>
    		<td headers="view-field-imo-table-column--wAIKM3Uv4HQ" class="views-field views-field-field-imo">9153123          </td>
    		<td headers="view-field-flag-table-column--RRQ2RO19ykQ" class="views-field views-field-field-flag">Tanzania          </td>
    		<td headers="view-field-port-table-column--59gPpX0SLsk" class="views-field views-field-field-port">Jelel Ali          </td>
    		<td headers="view-field-country-table-column--lHU25ouwYSA" class="views-field views-field-field-country">UAE          </td>
    		<td headers="view-field-owed-wages-table-column--iJAyZtc7OWg" class="views-field views-field-field-owed-wages">6 months          </td>
    		<td headers="view-field-seafarers-table-column--iPIRdzluh6M" class="views-field views-field-field-seafarers">6          </td>
    		<td headers="view-field-nationalities-table-column--SJMcoY774Wg" class="views-field views-field-field-nationalities">India          </td>
    		<td headers="view-field-reported-to-itf-table-column--SkM3UqLURFs" class="views-field views-field-field-reported-to-itf is-active">
    			<time datetime="2022-05-01T12:00:00Z">01 May 2022</time>
    		</td>
    		<td headers="view-field-status-list-table-column--xeRYwaEFJx4" class="views-field views-field-field-status-list">Inactive          </td>
    	</tr>
    	<tr>
    		<td headers="view-field-vessel-name-table-column--Ot-rDmU5szg" class="views-field views-field-field-vessel-name">SEA SAPPHIRE          </td>
    		<td headers="view-field-imo-table-column--wAIKM3Uv4HQ" class="views-field views-field-field-imo">          </td>
    		<td headers="view-field-flag-table-column--RRQ2RO19ykQ" class="views-field views-field-field-flag">Tanzania          </td>
    		<td headers="view-field-port-table-column--59gPpX0SLsk" class="views-field views-field-field-port">Sharjah          </td>
    		<td headers="view-field-country-table-column--lHU25ouwYSA" class="views-field views-field-field-country">UAE          </td>
    		<td headers="view-field-owed-wages-table-column--iJAyZtc7OWg" class="views-field views-field-field-owed-wages">10 months          </td>
    		<td headers="view-field-seafarers-table-column--iPIRdzluh6M" class="views-field views-field-field-seafarers">5          </td>
    		<td headers="view-field-nationalities-table-column--SJMcoY774Wg" class="views-field views-field-field-nationalities">India, Philippines          </td>
    		<td headers="view-field-reported-to-itf-table-column--SkM3UqLURFs" class="views-field views-field-field-reported-to-itf is-active">
    			<time datetime="2022-02-01T12:00:00Z">01 Feb 2022</time>
    		</td>
    		<td headers="view-field-status-list-table-column--xeRYwaEFJx4" class="views-field views-field-field-status-list">Inactive          </td>
    	</tr>
    </tbody>"
    """;

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
    ////string html = await webAgent.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
    //string html = await webAgent.CoreWebView2.ExecuteScriptAsync(@"document.querySelector('#block-views-block-itf-current-cases-block-1 > div > div > table > tbody').outerHTML");
    //string decodedHtml = Regex.Unescape(html); // 解 Unicode, \u003C => `<`
    //string decodedHtml2 = WebUtility.HtmlDecode(decodedHtml); // 解 

    string decodedHtml2 = simsRawHtml;

    // 解析資訊 => datainfo with RegEx ; 或直接用 js 取值出來
    string pattern =
           @"(<td .*-vessel-name"">(?<vesselName>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-imo"">(?<imo>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-flag"">(?<flag>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-port"">(?<port>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-country"">(?<country>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-owed-wages"">(?<owedWages>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-seafarers"">(?<seafarers>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-nationalities"">(?<nationalities>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-reported-to-itf is-active"">(?<reportedToItf>[\s\S]*?)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-status-list"">(?<statusList>.*)<\/td>)";

    List<SeafarerAbandonment> infoList = new();
    foreach (Match tr in Regex.Matches(decodedHtml2, @"<tr>([\s\S\r\n\t]*?)<\/tr>"))
    {
      Match match = Regex.Match(tr.Value, pattern);

      if (match.Success)
      {
        var info = new SeafarerAbandonment();
        info.VesselName = match.Groups["vesselName"].ToString().Trim();
        info.Imo = match.Groups["imo"].ToString().Trim();
        info.Flag = match.Groups["flag"].ToString().Trim();
        info.Port = match.Groups["port"].ToString().Trim();
        info.Country = match.Groups["country"].ToString().Trim();
        info.OwedWages = match.Groups["owedWages"].ToString().Trim();
        info.Seafarers = match.Groups["seafarers"].ToString().Trim();
        info.Nationalities = match.Groups["nationalities"].ToString().Trim();
        info.ReportedToItf = match.Groups["reportedToItf"].ToString().Trim();
        info.StatusList = match.Groups["statusList"].ToString().Trim();

        infoList.Add(info);
      }
    }

    string dataJson = JsonSerializer.Serialize(infoList, new JsonSerializerOptions
    {
      WriteIndented = true,
      Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 中文字不編碼
    });

    textBox1.Text = dataJson;
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
    string decodedHtml = Regex.Unescape(html); // 解碼: Unicode, \u003C => `<`
    string decodedHtml2 = WebUtility.HtmlDecode(decodedHtml); // 解碼:html 

    progressBar.Value = 80;

    // 解析資訊 => datainfo with RegEx 
    const string pattern =
           @"(<td .*-vessel-name"">(?<vesselName>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-imo"">(?<imo>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-flag"">(?<flag>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-port"">(?<port>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-country"">(?<country>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-owed-wages"">(?<owedWages>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-seafarers"">(?<seafarers>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-nationalities"">(?<nationalities>.*)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-reported-to-itf is-active"">(?<reportedToItf>[\s\S]*?)<\/td>)[\s\r\n\t]*" +
           @"(<td .*-status-list"">(?<statusList>.*)<\/td>)";

    List<SeafarerAbandonment> infoList = new();
    foreach (Match tr in Regex.Matches(decodedHtml2, @"<tr>([\s\S\r\n\t]*?)<\/tr>"))
    {
      Match match = Regex.Match(tr.Value, pattern);

      if (match.Success)
      {
        var info = new SeafarerAbandonment();
        info.VesselName = match.Groups["vesselName"].ToString().Trim();
        info.Imo = match.Groups["imo"].ToString().Trim();
        info.Flag = match.Groups["flag"].ToString().Trim();
        info.Port = match.Groups["port"].ToString().Trim();
        info.Country = match.Groups["country"].ToString().Trim();
        info.OwedWages = match.Groups["owedWages"].ToString().Trim();
        info.Seafarers = match.Groups["seafarers"].ToString().Trim();
        info.Nationalities = match.Groups["nationalities"].ToString().Trim();
        info.ReportedToItf = match.Groups["reportedToItf"].ToString().Trim();
        info.StatusList = match.Groups["statusList"].ToString().Trim();

        infoList.Add(info);
      }
    }

    progressBar.Value = 90;

    //## 輸出到畫面
    string dataJson = JsonSerializer.Serialize(infoList, new JsonSerializerOptions
    {
      WriteIndented = true,
      Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 中文字不編碼
    });

    textBox1.Text = dataJson;

    progressBar.Value = 100;
  }
}

class SeafarerAbandonment
{
  public string VesselName { get; set; } = string.Empty;
  public string Imo { get; set; } = string.Empty;
  public string Flag { get; set; } = string.Empty;
  public string Port { get; set; } = string.Empty;
  public string Country { get; set; } = string.Empty;
  public string OwedWages { get; set; } = string.Empty;
  public string Seafarers { get; set; } = string.Empty;
  public string Nationalities { get; set; } = string.Empty;
  public string ReportedToItf { get; set; } = string.Empty;
  public string StatusList { get; set; } = string.Empty;
}
