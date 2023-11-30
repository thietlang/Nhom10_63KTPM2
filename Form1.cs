using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tientrinh
{
    public partial class Form1 : Form
    {
        private Process wordProcess; // Tham chiếu để lưu trữ tiến trình Word

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowRunningProcesses();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StartNewProcess("winword.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Đóng tiến trình Word nếu nó đã được mở
            if (wordProcess != null && !wordProcess.HasExited)
            {
                wordProcess.CloseMainWindow();
                wordProcess.WaitForExit();
            }
            else
            {
                MessageBox.Show("Microsoft Word is not running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowRunningProcesses()
        {
            // Lấy danh sách các tiến trình đang chạy
            Process[] processes = Process.GetProcesses();

            // Hiển thị thông tin về từng tiến trình trong cửa sổ mới
            StringBuilder processInfo = new StringBuilder();
            foreach (Process process in processes)
            {
                processInfo.AppendLine($"Process Name: {process.ProcessName}, ID: {process.Id}");
            }

            // Hiển thị thông tin trong một cửa sổ mới
            ShowProcessesForm(processInfo.ToString(), "Running Processes");
        }

        private void ShowProcessesForm(string content, string title)
        {
            // Tạo một cửa sổ mới
            Form processesForm = new Form();
            processesForm.Text = title;

            // Tạo một TextBox để hiển thị thông tin và cho phép cuộn
            TextBox textBox = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Text = content
            };

            // Thêm TextBox vào Form
            processesForm.Controls.Add(textBox);

            // Thiết lập kích thước của Form
            processesForm.Size = new System.Drawing.Size(800, 500);

            // Hiển thị cửa sổ
            processesForm.ShowDialog();
        }

        private void StartNewProcess(string processName)
        {
            try
            {
                // Tạo một tiến trình mới
                wordProcess = new Process();

                // Thiết lập thông tin của tiến trình
                wordProcess.StartInfo.FileName = processName;

                // Khởi động tiến trình
                wordProcess.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenPersonalizationSettings();
        }
        private void OpenPersonalizationSettings()
        {
            try
            {
                // Mở cửa sổ Personalization trong Settings
                Process.Start("ms-settings:personalization-background");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Personalization Settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}