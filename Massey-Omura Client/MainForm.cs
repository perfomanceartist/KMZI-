using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Massey_Omura_Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonMessage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonFile_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private async void checkBoxListen_CheckedChanged(object sender, EventArgs e)
        {
            string IP = textBoxInboxIP.Text;
            string Port = textBoxInboxPort.Text;


            Server server = new Server(IP, Convert.ToInt32(Port));
            while (checkBoxListen.Checked)
            {
                Message m = await Task.Run(() => server.Listen());
                flowLayoutPanel.Controls.Add(new MessagePanel(m));
                Debug.WriteLine("1 message received");
            }

            /*Server server = new Server(IP, Port);
            server.StartListening();
            Debug.WriteLine("Start listening...");

            while (checkBoxListen.Checked)
            {
                Message m = await Task.Run(() => server.GetMessage());
                flowLayoutPanel.Controls.Add(new MessagePanel(m));
                Debug.WriteLine("1 message received");
            }*/


        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string dataString = richTextBox1.Text;
            string IP = textBoxNewIP.Text;
            string Port = textBoxNewPort.Text;

            Client client = new Client(IP, Convert.ToInt32(Port));
            client.Send(dataString);

            /*Client client = new Client(IP, Port);
            if(!client.Connect())
            {
                MessageBox.Show("���������� ������������", "Massey-Omura");
                return;
            }

            if (!client.Send(Encoding.UTF8.GetBytes(dataString)))
            {
                MessageBox.Show("���������� ��������� ���������", "Massey-Omura");
                return;
            }*/

            /*if(!client.Disconnect())
            {
                MessageBox.Show("���������� �����������", "Massey-Omura");
                return;
            }*/
        }
    }
}