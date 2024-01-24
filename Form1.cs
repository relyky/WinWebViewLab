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

    
  }
}
