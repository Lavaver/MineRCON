using System;
using System.Windows.Forms;
using RconSharp;

namespace MineRCON.NET
{
    public partial class Form1 : Form
    {
        // ����������һ�� RCON �ͻ���ʵ��
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
                // ����û���δͬ�� EULA������ʾ��ʾ��Ϣ
                var result = MessageBox.Show("������ͬ�� Minecraft �� EULA ���ܼ���ʹ�ñ���������Ƿ�ͬ�⣿", "Minecraft EULA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // �û�ͬ�� EULA��������д���ļ�
                    WriteConfig(true);
                }
                else
                {
                    // �û���ͬ�� EULA���ر����
                    MessageBox.Show("������ͬ�� Minecraft �� EULA ���ܼ���ʹ�ñ������", "Minecraft EULA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // �� textbox2 �л�ȡ��������ַ
            string serverAddress = textBox2.Text;

            // �� textbox3 �л�ȡ RCON ����
            string rconPassword = textBox3.Text;

            // �� textbox4 �л�ȡ�˿ںŲ�ת��Ϊ����
            int port;
            if (!int.TryParse(textBox4.Text, out port))
            {
                MessageBox.Show("�˿ںű�����һ��������");
                return;
            }

            try
            {
                listBox1.Items.Clear();
                button2.Enabled = false;
                // ����һ�� RCON �ͻ���ʵ��
                rconClient = RconClient.Create(serverAddress, port);

                // ���ӵ�������
                await rconClient.ConnectAsync();

                listBox1.Items.Add("������ RCON ������");

                // ��֤
                await rconClient.AuthenticateAsync(rconPassword);

                button1.Enabled = true;

                button3.Enabled = true;
            }
            catch (Exception ex)
            {
                button2.Enabled = true;
                button1.Enabled = false;
                button3.Enabled = false;
                // �����쳣
                listBox1.Items.Add($"RCON ����ʧ��: {ex.Message}");
                MessageBox.Show($"RCON ����ʧ��: {ex.Message}");

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var status = await rconClient.ExecuteCommandAsync(textBox1.Text);

            listBox1.Items.Add($"[RCON ��־] {status}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {

            // �Ͽ�����
            rconClient.Disconnect();
            listBox1.Items.Add("�ѶϿ��� RCON ������������");

            button2.Enabled = true;
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void ����ѡ����־ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedText = listBox1.SelectedItem.ToString();

                // ��ѡ�е��ı����Ƶ�������
                Clipboard.SetText(selectedText);
            }
        }

        private void ɾ��ѡ����־ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // ��ȡѡ���������
                int selectedIndex = listBox1.SelectedIndex;

                // ɾ��ѡ����
                listBox1.Items.RemoveAt(selectedIndex);
            }
        }
    }
}