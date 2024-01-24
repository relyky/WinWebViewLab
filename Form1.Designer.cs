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
      backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      webAgent = new Microsoft.Web.WebView2.WinForms.WebView2();
      button1 = new Button();
      panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)webAgent).BeginInit();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.Controls.Add(button1);
      panel1.Dock = DockStyle.Top;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(800, 70);
      panel1.TabIndex = 0;
      // 
      // webAgent
      // 
      webAgent.AllowExternalDrop = true;
      webAgent.CreationProperties = null;
      webAgent.DefaultBackgroundColor = Color.White;
      webAgent.Dock = DockStyle.Fill;
      webAgent.Location = new Point(0, 70);
      webAgent.Margin = new Padding(8);
      webAgent.Name = "webAgent";
      webAgent.Padding = new Padding(8);
      webAgent.Size = new Size(800, 380);
      webAgent.TabIndex = 1;
      webAgent.ZoomFactor = 1D;
      // 
      // button1
      // 
      button1.Location = new Point(25, 12);
      button1.Name = "button1";
      button1.Size = new Size(132, 34);
      button1.TabIndex = 0;
      button1.Text = "button1";
      button1.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(9F, 19F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(webAgent);
      Controls.Add(panel1);
      Name = "Form1";
      Text = "Form1";
      Load += Form1_Load;
      panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)webAgent).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private Microsoft.Web.WebView2.WinForms.WebView2 webAgent;
    private Button button1;
  }
}
