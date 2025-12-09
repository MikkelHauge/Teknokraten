using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Teknokraten
{
    public partial class Form1 : Form
    {
        private Process _runningProcess;
        private readonly string ytDlpPath;
        public Form1()
        {
            InitializeComponent();
            CheckYtDlpVersion();
            DownloadBtnMp3.Click += DownloadBtnMp3_Click;
            DownloadBtnVideo.Click += DownloadBtnVideo_Click;
            this.Text = "Teknokraten";
            ytDlpPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "yt-dlp", "yt-dlp.exe");
            try
            {
                this.Icon = new System.Drawing.Icon("Resources\\teknokraten.ico");
            }
            catch
            {

            }

        }

        private async void DownloadBtnMp3_Click(object sender, EventArgs e)
        {
            string url = UrlBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                updateTextBox("Please enter a valid URL.");
                return;
            }

            SetUIForDownloading();
            try
            {
                await Task.Run(() => RunYtDlp($"-x --audio-format mp3 \"{url}\""));
                updateTextBox("MP3 Download Complete.");
            }
            catch (Exception ex)
            {
                updateTextBox("Error: " + ex.Message);
            }
            finally
            {
                ResetUI();
            }
        }

        private async void DownloadBtnVideo_Click(object sender, EventArgs e)
        {
            string url = UrlBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                updateTextBox("Please enter a valid URL.");
                return;
            }

            SetUIForDownloading();
            try
            {
                await Task.Run(() => RunYtDlp($"-f best \"{url}\""));
                updateTextBox("Video Download Complete.");
            }
            catch (Exception ex)
            {
                updateTextBox("Error: " + ex.Message);
            }
            finally
            {
                ResetUI();
            }
        }

        private void SetUIForDownloading()
        {
            this.Invoke((Action)(() =>
            {
                DownloadBtnMp3.Enabled = false;
                DownloadBtnVideo.Enabled = false;
                textBox1.Clear();
            }));
        }

        private void ResetUI()
        {
            this.Invoke((Action)(() =>
            {
                DownloadBtnMp3.Enabled = true;
                DownloadBtnVideo.Enabled = true;
            }));
        }

        private void RunYtDlp(string arguments)
        {
            var process = new Process();
            try
            {
                process.StartInfo.FileName = ytDlpPath;  // Use the correct path here
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.OutputDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        updateTextBox(e.Data);
                };

                process.ErrorDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        updateTextBox(e.Data);
                };

                process.Start();

                _runningProcess = process;

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
                _runningProcess = null;
            }
            finally
            {
                process.Dispose();
            }
        }

        private async void CheckYtDlpVersion()
        {
            ResultLabel.Text = "Looking for yt-dlp at: " + ytDlpPath;
            string version = await Task.Run(() => RunProcessForOutput(ytDlpPath, "--version")); // Use path here too
            ResultLabel.Text = version ?? "yt-dlp not found, in or failed to run.";
        }

        private void updateTextBox(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action(() =>
                {
                    textBox1.AppendText(text + Environment.NewLine);
                }));
            }
            else
            {
                textBox1.AppendText(text + Environment.NewLine);
            }
        }

        private string RunProcessForOutput(string fileName, string arguments)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                return output.Trim();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
