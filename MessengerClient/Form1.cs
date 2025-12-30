using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections.Generic;



namespace MessengerClient
{
    public partial class Form1 : Form
    {
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;
        Thread listenThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                //string ip = textBoxIP.Text;
                //client = new TcpClient(ip, 5000); // IP сервера
                client = new TcpClient("192.168.50.49", 5000); // IP сервера
                var stream = client.GetStream();

                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                // отправляем имя пользователя
                writer.WriteLine(nameBox.Text);

                listenThread = new Thread(Listen);
                listenThread.IsBackground = true;
                listenThread.Start();

                chatBox.AppendText("Подключено к серверу\n");
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться");
            }
        }

        void Listen()
        {
            try
            {
                while (true)
                {
                    string message = reader.ReadLine();
                    Invoke(new Action(() =>
                    {
                        chatBox.AppendText(message + "\n");
                    }));
                }
            }
            catch
            {
                Invoke(new Action(() =>
                {
                    chatBox.AppendText("Соединение разорвано\n");
                }));
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(messageBox.Text))
            {
                writer.WriteLine(messageBox.Text);
                messageBox.Clear();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client?.Close();
                listenThread?.Abort();
            }
            catch { }

            base.OnFormClosing(e);
        }
    }
}
