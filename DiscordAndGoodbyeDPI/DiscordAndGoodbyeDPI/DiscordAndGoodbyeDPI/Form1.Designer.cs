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
    private System.Windows.Forms.CheckBox chkAutoRun;
    private System.Windows.Forms.TextBox txtDiscordPath;
    private System.Windows.Forms.Button btnBrowseDiscord;
    private System.Windows.Forms.Label lblDiscordPath;
    private System.Windows.Forms.Button btnSettings;
    private System.Windows.Forms.GroupBox grpSettings;
    private System.Windows.Forms.CheckBox chkMinimizeDpiLink;
    private System.Windows.Forms.CheckBox chkAutoClose;

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtGoodbyeDPIPath = new System.Windows.Forms.TextBox();
        btnBrowse = new System.Windows.Forms.Button();
        btnRun = new System.Windows.Forms.Button();
        lblPath = new System.Windows.Forms.Label();
        chkAutoRun = new System.Windows.Forms.CheckBox();
        txtDiscordPath = new System.Windows.Forms.TextBox();
        btnBrowseDiscord = new System.Windows.Forms.Button();
        lblDiscordPath = new System.Windows.Forms.Label();
        btnSettings = new System.Windows.Forms.Button();
        grpSettings = new System.Windows.Forms.GroupBox();
        chkMinimizeDpiLink = new System.Windows.Forms.CheckBox();
        chkAutoClose = new System.Windows.Forms.CheckBox();
        grpSettings.SuspendLayout();
        SuspendLayout();
        // 
        // txtGoodbyeDPIPath
        // 
        txtGoodbyeDPIPath.Location = new System.Drawing.Point(12, 29);
        txtGoodbyeDPIPath.Name = "txtGoodbyeDPIPath";
        txtGoodbyeDPIPath.Size = new System.Drawing.Size(300, 23);
        txtGoodbyeDPIPath.TabIndex = 5;
        // 
        // btnBrowse
        // 
        btnBrowse.Location = new System.Drawing.Point(320, 27);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Size = new System.Drawing.Size(75, 23);
        btnBrowse.TabIndex = 6;
        btnBrowse.Text = "Browse";
        btnBrowse.Click += btnBrowse_Click;
        // 
        // btnRun
        // 
        btnRun.Location = new System.Drawing.Point(12, 110);
        btnRun.Name = "btnRun";
        btnRun.Size = new System.Drawing.Size(383, 30);
        btnRun.TabIndex = 10;
        btnRun.Text = "Run GoodbyeDPI + Launch Discord";
        btnRun.Click += btnRun_Click;
        // 
        // lblPath
        // 
        lblPath.AutoSize = true;
        lblPath.Location = new System.Drawing.Point(12, 10);
        lblPath.Name = "lblPath";
        lblPath.Size = new System.Drawing.Size(133, 15);
        lblPath.TabIndex = 11;
        lblPath.Text = "GoodbyeDPI CMD Path:";
        // 
        // chkAutoRun
        // 
        chkAutoRun.AutoSize = true;
        chkAutoRun.Location = new System.Drawing.Point(12, 146);
        chkAutoRun.Name = "chkAutoRun";
        chkAutoRun.Size = new System.Drawing.Size(120, 19);
        chkAutoRun.TabIndex = 4;
        chkAutoRun.Text = "Auto Run on Start";
        chkAutoRun.UseVisualStyleBackColor = true;
        chkAutoRun.CheckedChanged += chkAutoRun_CheckedChanged;
        // 
        // txtDiscordPath
        // 
        txtDiscordPath.Location = new System.Drawing.Point(12, 79);
        txtDiscordPath.Name = "txtDiscordPath";
        txtDiscordPath.Size = new System.Drawing.Size(300, 23);
        txtDiscordPath.TabIndex = 7;
        // 
        // btnBrowseDiscord
        // 
        btnBrowseDiscord.Location = new System.Drawing.Point(320, 77);
        btnBrowseDiscord.Name = "btnBrowseDiscord";
        btnBrowseDiscord.Size = new System.Drawing.Size(75, 23);
        btnBrowseDiscord.TabIndex = 8;
        btnBrowseDiscord.Text = "Browse";
        btnBrowseDiscord.Click += btnBrowseDiscord_Click;
        // 
        // lblDiscordPath
        // 
        lblDiscordPath.AutoSize = true;
        lblDiscordPath.Location = new System.Drawing.Point(12, 60);
        lblDiscordPath.Name = "lblDiscordPath";
        lblDiscordPath.Size = new System.Drawing.Size(99, 15);
        lblDiscordPath.TabIndex = 9;
        lblDiscordPath.Text = "Discord EXE Path:";
        // 
        // btnSettings
        // 
        btnSettings.Location = new System.Drawing.Point(320, 144);
        btnSettings.Name = "btnSettings";
        btnSettings.Size = new System.Drawing.Size(75, 23);
        btnSettings.TabIndex = 1;
        btnSettings.Text = "Settings ▼";
        btnSettings.Click += btnSettings_Click;
        // 
        // grpSettings
        // 
        grpSettings.Controls.Add(chkMinimizeDpiLink);
        grpSettings.Controls.Add(chkAutoClose);
        grpSettings.Location = new System.Drawing.Point(12, 175);
        grpSettings.Name = "grpSettings";
        grpSettings.Size = new System.Drawing.Size(383, 100);
        grpSettings.TabIndex = 0;
        grpSettings.TabStop = false;
        grpSettings.Text = "Advanced Settings";
        // 
        // chkMinimizeDpiLink
        // 
        chkMinimizeDpiLink.AutoSize = true;
        chkMinimizeDpiLink.Checked = true;
        chkMinimizeDpiLink.CheckState = System.Windows.Forms.CheckState.Checked;
        chkMinimizeDpiLink.Location = new System.Drawing.Point(10, 20);
        chkMinimizeDpiLink.Name = "chkMinimizeDpiLink";
        chkMinimizeDpiLink.Size = new System.Drawing.Size(207, 19);
        chkMinimizeDpiLink.TabIndex = 0;
        chkMinimizeDpiLink.Text = "Minimize DPI Link unconditionally";
        chkMinimizeDpiLink.CheckedChanged += chkSetting_CheckedChanged;
        // 
        // chkAutoClose
        // 
        chkAutoClose.AutoSize = true;
        chkAutoClose.Location = new System.Drawing.Point(10, 45);
        chkAutoClose.Name = "chkAutoClose";
        chkAutoClose.Size = new System.Drawing.Size(248, 19);
        chkAutoClose.TabIndex = 2;
        chkAutoClose.Text = "Auto Close DPI Link instead of minimizing";
        chkAutoClose.CheckedChanged += chkSetting_CheckedChanged;
        // 
        // Form1
        // 
        ClientSize = new System.Drawing.Size(410, 172);
        Controls.Add(grpSettings);
        Controls.Add(btnSettings);
        Controls.Add(chkAutoRun);
        Controls.Add(txtGoodbyeDPIPath);
        Controls.Add(btnBrowse);
        Controls.Add(txtDiscordPath);
        Controls.Add(btnBrowseDiscord);
        Controls.Add(lblDiscordPath);
        Controls.Add(btnRun);
        Controls.Add(lblPath);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Text = "DPI Link";
        Shown += Form1_Shown;
        grpSettings.ResumeLayout(false);
        grpSettings.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }


    #endregion
}