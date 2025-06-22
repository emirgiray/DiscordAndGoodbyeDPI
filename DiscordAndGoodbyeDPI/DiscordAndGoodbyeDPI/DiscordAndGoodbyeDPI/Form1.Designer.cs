namespace DiscordAndGoodbyeDPI;

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

    private System.Windows.Forms.TextBox txtGoodbyeDPIPath;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Label lblPath;

    private void InitializeComponent()
    {
        this.txtGoodbyeDPIPath = new System.Windows.Forms.TextBox();
        this.btnBrowse = new System.Windows.Forms.Button();
        this.btnRun = new System.Windows.Forms.Button();
        this.lblPath = new System.Windows.Forms.Label();
        this.SuspendLayout();
    
        // txtGoodbyeDPIPath
        this.txtGoodbyeDPIPath.Location = new System.Drawing.Point(12, 29);
        this.txtGoodbyeDPIPath.Size = new System.Drawing.Size(300, 20);
    
        // btnBrowse
        this.btnBrowse.Location = new System.Drawing.Point(320, 27);
        this.btnBrowse.Size = new System.Drawing.Size(75, 23);
        this.btnBrowse.Text = "Browse";
        this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
    
        // btnRun
        this.btnRun.Location = new System.Drawing.Point(12, 60);
        this.btnRun.Size = new System.Drawing.Size(383, 30);
        this.btnRun.Text = "Run GoodbyeDPI + Launch Discord";
        this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
    
        // lblPath
        this.lblPath.AutoSize = true;
        this.lblPath.Location = new System.Drawing.Point(12, 10);
        this.lblPath.Text = "GoodbyeDPI CMD Path:";

        // DiscordAndGoodbyeDPI
        this.ClientSize = new System.Drawing.Size(410, 100);
        this.Controls.Add(this.txtGoodbyeDPIPath);
        this.Controls.Add(this.btnBrowse);
        this.Controls.Add(this.btnRun);
        this.Controls.Add(this.lblPath);
        this.Text = "Discord + GoodbyeDPI Launcher";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.ResumeLayout(false);
        this.PerformLayout();
    }


    #endregion
}