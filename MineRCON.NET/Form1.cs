using System;
using System.Windows.Forms;
using RconSharp;

namespace MineRCON.NET
{
    public partial class Form1 : Form
    {
        // 在这里声明一个 RCON 客户端实例
        private RconClient rconClient;
        private const string ConfigFilePath = "config.txt";
        private bool eulaAgreed = false;

        public Form1()
        {
            InitializeComponent();
            CheckEulaAgreement();
        }

        private void CheckEulaAgreement()
        {
            if (File.Exists(ConfigFilePath))
            {
                string configContent = File.ReadAllText(ConfigFilePath);
                eulaAgreed = bool.Parse(configContent);
            }

            if (!eulaAgreed)
            {
                // 如果用户还未同意 EULA，则显示提示信息
                var result = MessageBox.Show("您必须同意 Minecraft 的 EULA 才能继续使用本软件。您是否同意？", "Minecraft EULA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // 用户同意 EULA，将配置写入文件
                    WriteConfig(true);
                }
                else
                {
                    // 用户不同意 EULA，关闭软件
                    MessageBox.Show("您必须同意 Minecraft 的 EULA 才能继续使用本软件。", "Minecraft EULA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void WriteConfig(bool agreed)
        {
            File.WriteAllText(ConfigFilePath, agreed.ToString());
            eulaAgreed = agreed;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // 从 textbox2 中获取服务器地址
            string serverAddress = textBox2.Text;

            // 从 textbox3 中获取 RCON 密码
            string rconPassword = textBox3.Text;

            // 从 textbox4 中获取端口号并转换为整数
            int port;
            if (!int.TryParse(textBox4.Text, out port))
            {
                MessageBox.Show("端口号必须是一个整数。");
                return;
            }

            try
            {
                listBox1.Items.Clear();
                button2.Enabled = false;
                // 创建一个 RCON 客户端实例
                rconClient = RconClient.Create(serverAddress, port);

                // 连接到服务器
                await rconClient.ConnectAsync();

                listBox1.Items.Add("连接至 RCON 服务器");

                // 认证
                await rconClient.AuthenticateAsync(rconPassword);

                button1.Enabled = true;

                button3.Enabled = true;
            }
            catch (Exception ex)
            {
                button2.Enabled = true;
                button1.Enabled = false;
                button3.Enabled = false;
                // 处理异常
                listBox1.Items.Add($"RCON 连接失败: {ex.Message}");
                MessageBox.Show($"RCON 连接失败: {ex.Message}");

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var status = await rconClient.ExecuteCommandAsync(textBox1.Text);

            listBox1.Items.Add($"[RCON 日志] {status}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {

            // 断开连接
            rconClient.Disconnect();
            listBox1.Items.Add("已断开与 RCON 服务器的连接");

            button2.Enabled = true;
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void 复制选中日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedText = listBox1.SelectedItem.ToString();

                // 将选中的文本复制到剪贴板
                Clipboard.SetText(selectedText);
            }
        }

        private void 删除选中日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // 获取选中项的索引
                int selectedIndex = listBox1.SelectedIndex;

                // 删除选中项
                listBox1.Items.RemoveAt(selectedIndex);
            }
        }
    }
}