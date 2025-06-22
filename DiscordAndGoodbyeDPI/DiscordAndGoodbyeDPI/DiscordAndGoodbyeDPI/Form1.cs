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

            // Load saved path if available
            if (File.Exists(ConfigPath))
            {
                string savedPath = File.ReadAllText(ConfigPath).Trim();
                if (File.Exists(savedPath))
                {
                    txtGoodbyeDPIPath.Text = savedPath;
                }
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
                File.WriteAllText(ConfigPath, dialog.FileName);
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

            // Save current path before running
            File.WriteAllText(ConfigPath, cmdPath);

            try
            {
                // Run GoodbyeDPI CMD as admin
                Process.Start(new ProcessStartInfo
                {
                    FileName = cmdPath,
                    UseShellExecute = true,
                    Verb = "runas"
                });

                // Launch Discord after a short delay
                Timer timer = new Timer { Interval = 1500 };
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    string discordPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "Discord", "Update.exe");
                    Process.Start(discordPath, "--processStart Discord.exe");
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
    }
}
