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
        bool isConnected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = textBoxIP.Text;
                client = new TcpClient(ip, 5000); // IP сервера
                var stream = client.GetStream();

                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                // отправляем имя пользователя
                writer.WriteLine(nameBox.Text);

                isConnected = true;

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
                while (isConnected)
                {
                    string message = reader.ReadLine();

                    if (message == null)
                        break;

                    Invoke(new Action(() =>
                    {
                        chatBox.AppendText(message + Environment.NewLine);
                    }));
                }
            }
            catch
            {
                
            }
            finally 
            {
                Invoke(new Action(() =>
                {
                    chatBox.AppendText("Соединение разорвано\n");
                }));

                isConnected = false;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!isConnected) return;

            if (!string.IsNullOrWhiteSpace(messageBox.Text))
            {
                writer.WriteLine(messageBox.Text);
                messageBox.Clear();
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isConnected = false;

            try
            {
                reader?.Close();
                writer?.Close();
                client?.Close();
            }
            catch { }
        }

    }
}
