namespace WinWebViewLab
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      panel1 = new Panel();
      textBox1 = new TextBox();
      progressBar = new ProgressBar();
      labelResult = new Label();
      label1 = new Label();
      cboStatus = new ComboBox();
      button2 = new Button();
      button1 = new Button();
      backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      webAgent = new Microsoft.Web.WebView2.WinForms.WebView2();
      panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)webAgent).BeginInit();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.Controls.Add(textBox1);
      panel1.Controls.Add(progressBar);
      panel1.Controls.Add(labelResult);
      panel1.Controls.Add(label1);
      panel1.Controls.Add(cboStatus);
      panel1.Controls.Add(button2);
      panel1.Controls.Add(button1);
      panel1.Dock = DockStyle.Top;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(800, 211);
      panel1.TabIndex = 0;
      // 
      // textBox1
      // 
      textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      textBox1.Location = new Point(12, 68);
      textBox1.Multiline = true;
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(776, 132);
      textBox1.TabIndex = 6;
      // 
      // progressBar
      // 
      progressBar.Location = new Point(70, 50);
      progressBar.Name = "progressBar";
      progressBar.Size = new Size(403, 10);
      progressBar.TabIndex = 5;
      // 
      // labelResult
      // 
      labelResult.AutoSize = true;
      labelResult.Location = new Point(378, 20);
      labelResult.Name = "labelResult";
      labelResult.Size = new Size(51, 19);
      labelResult.TabIndex = 4;
      labelResult.Text = "label2";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(12, 20);
      label1.Name = "label1";
      label1.Size = new Size(52, 19);
      label1.TabIndex = 3;
      label1.Text = "Status";
      // 
      // cboStatus
      // 
      cboStatus.FormattingEnabled = true;
      cboStatus.Items.AddRange(new object[] { "All", "open", "disputed", "inactive", "resolved" });
      cboStatus.Location = new Point(70, 17);
      cboStatus.Name = "cboStatus";
      cboStatus.Size = new Size(153, 27);
      cboStatus.TabIndex = 2;
      // 
      // button2
      // 
      button2.Location = new Point(229, 12);
      button2.Name = "button2";
      button2.Size = new Size(132, 34);
      button2.TabIndex = 1;
      button2.Text = "送出查詢指令";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // button1
      // 
      button1.Location = new Point(656, 12);
      button1.Name = "button1";
      button1.Size = new Size(132, 34);
      button1.TabIndex = 0;
      button1.Text = "for 開發測試";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // webAgent
      // 
      webAgent.AllowExternalDrop = true;
      webAgent.CreationProperties = null;
      webAgent.DefaultBackgroundColor = Color.White;
      webAgent.Dock = DockStyle.Fill;
      webAgent.Location = new Point(0, 211);
      webAgent.Margin = new Padding(8);
      webAgent.Name = "webAgent";
      webAgent.Padding = new Padding(8);
      webAgent.Size = new Size(800, 328);
      webAgent.TabIndex = 1;
      webAgent.ZoomFactor = 1D;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(9F, 19F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 539);
      Controls.Add(webAgent);
      Controls.Add(panel1);
      Name = "Form1";
      Text = "Form1";
      Load += Form1_Load;
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)webAgent).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private Microsoft.Web.WebView2.WinForms.WebView2 webAgent;
    private Button button1;
    private Button button2;
    private ComboBox cboStatus;
    private Label label1;
    private Label labelResult;
    private ProgressBar progressBar;
    private TextBox textBox1;
  }
}
