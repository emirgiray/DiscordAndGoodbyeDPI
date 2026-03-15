using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace DiscordAndGoodbyeDPI
{
    public partial class Form1 : Form
    {
        private const string ConfigFileName = "config.txt";
        private string ConfigPath => Path.Combine(Application.StartupPath, ConfigFileName);

        public Form1()
        {
            InitializeComponent();

            // Attempt to load the application's icon to display on the Window itself
            try
            {
                this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch { /* Ignore if it fails to extract icon */ }

            // Load saved config if available
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(ConfigPath))
            {
                string[] lines = File.ReadAllLines(ConfigPath);
                if (lines.Length > 0)
                {
                    string savedPath = lines[0].Trim();
                    if (File.Exists(savedPath))
                    {
                        txtGoodbyeDPIPath.Text = savedPath;
                    }
                }
                if (lines.Length > 1)
                {
                    if (bool.TryParse(lines[1].Trim(), out bool autoRun))
                    {
                        chkAutoRun.Checked = autoRun;
                    }
                }
                if (lines.Length > 2)
                {
                    string discordPath = lines[2].Trim();
                    if (File.Exists(discordPath))
                    {
                        txtDiscordPath.Text = discordPath;
                    }
                }
                if (lines.Length > 3)
                {
                    if (bool.TryParse(lines[3].Trim(), out bool minDpi)) chkMinimizeDpiLink.Checked = minDpi;
                }
                if (lines.Length > 4)
                {
                    if (bool.TryParse(lines[4].Trim(), out bool autoClose)) chkAutoClose.Checked = autoClose;
                }
            }
            
            TryAutoDetectPaths();
        }

        private void TryAutoDetectPaths()
        {
            // Auto-detect Discord
            if (string.IsNullOrWhiteSpace(txtDiscordPath.Text))
            {
                string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string possibleDiscordPath = Path.Combine(localAppData, "Discord", "Update.exe");
                if (File.Exists(possibleDiscordPath))
                {
                    txtDiscordPath.Text = possibleDiscordPath;
                }
            }

            // Auto-detect GoodbyeDPI (looking for common batch files in the current directory or a 'goodbyedpi' subfolder)
            if (string.IsNullOrWhiteSpace(txtGoodbyeDPIPath.Text))
            {
                string[] possibleFiles = { 
                    "2_any_country_dnsredir.cmd",
                    "2_any_country.cmd", 
                    "1_turkey_gui.cmd",
                    "3_all_dns_only.cmd"
                };

                string startDir = Application.StartupPath;
                
                // Also check a common subfolder name if not in root
                string[] dirsToCheck = { startDir, Path.Combine(startDir, "goodbyedpi"), Path.Combine(startDir, "GoodbyeDPI") };

                foreach (var dir in dirsToCheck)
                {
                    if (!Directory.Exists(dir)) continue;

                    foreach (var file in possibleFiles)
                    {
                        string fullPath = Path.Combine(dir, file);
                        if (File.Exists(fullPath))
                        {
                            txtGoodbyeDPIPath.Text = fullPath;
                            return; // Stop after finding the first match
                        }
                    }
                }
            }
        }

        private void SaveConfig()
        {
            string[] lines = new string[]
            {
                txtGoodbyeDPIPath.Text,
                chkAutoRun.Checked.ToString(),
                txtDiscordPath.Text,
                chkMinimizeDpiLink.Checked.ToString(),
                chkAutoClose.Checked.ToString()
            };
            File.WriteAllLines(ConfigPath, lines);
        }

        private void chkSetting_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }
        
        // Backward compatibility for chkAutoRun which still points here in designer
        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (this.ClientSize.Height <= 175)
            {
                this.ClientSize = new System.Drawing.Size(410, 285);
                btnSettings.Text = "Settings \u25B2"; // Up arrow
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(410, 175);
                btnSettings.Text = "Settings \u25BC"; // Down arrow
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (chkAutoRun.Checked && File.Exists(txtGoodbyeDPIPath.Text))
            {
                btnRun_Click(this, EventArgs.Empty);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Command Files|*.cmd",
                Title = "Select GoodbyeDPI CMD File"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtGoodbyeDPIPath.Text = dialog.FileName;

                // Save path to config
                SaveConfig();
            }
        }

        private void btnBrowseDiscord_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Executable Files|*.exe",
                Title = "Select Discord Executable (Update.exe or Discord.exe)"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDiscordPath.Text = dialog.FileName;

                // Save path to config
                SaveConfig();
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string cmdPath = txtGoodbyeDPIPath.Text;

            if (!File.Exists(cmdPath))
            {
                MessageBox.Show("Selected CMD file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string discordPath = txtDiscordPath.Text;
            if (!File.Exists(discordPath))
            {
                MessageBox.Show("Selected Discord executable does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save current path before running
            SaveConfig();

            try
            {
                // Run GoodbyeDPI CMD as admin
                ProcessStartInfo gbStartInfo = new ProcessStartInfo
                {
                    FileName = cmdPath,
                    UseShellExecute = true,
                    Verb = "runas"
                };
                

                Process.Start(gbStartInfo);

                // Launch Discord after a short delay
                Timer timer = new Timer { Interval = 1500 };
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    string argsStr = discordPath.EndsWith("Update.exe", StringComparison.OrdinalIgnoreCase) 
                        ? "--processStart Discord.exe" 
                        : ""; 
                    Process.Start(discordPath, argsStr);
                };
                timer.Start();

                // Window Handling
                if (chkAutoClose.Checked)
                {
                    Application.Exit();
                }
                else if (chkMinimizeDpiLink.Checked)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
    }
}
