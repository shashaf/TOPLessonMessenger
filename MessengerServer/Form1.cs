using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessengerServer
{
    public partial class ServerForm : Form
    {
        TcpListener server;
        List<TcpClient> clients = new List<TcpClient>();
        Dictionary<string, TcpClient> connectedClients = new Dictionary<string, TcpClient>();

        bool isRunning = false;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
                StartServer();
            else
                StopServer();
        }

        void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            isRunning = true;

            runButton.Text = "Остановить сервер";
            Log("Сервер запущен на порту 5000");

            Thread acceptThread = new Thread(AcceptClients);
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }

        void StopServer()
        {
            isRunning = false;

            try
            {
                server.Stop(); 
            }
            catch { }

            lock (clients)
            {

                foreach (var client in clients)
                {
                    try
                    {
                        client.Close();
                    }
                    catch { }
                }
                clients.Clear();
            }

            runButton.Text = "Запустить сервер";
            Log("Сервер остановлен");
        }



        void AcceptClients()
        {
            try
            {
                while (isRunning)
                {
                    TcpClient client = server.AcceptTcpClient();
                    // вот отсюда
                    IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    string clientIP = clientEndPoint.Address.ToString();
                    int clientPort = clientEndPoint.Port;

                    string clientKey = $"{clientEndPoint.Address}:{clientEndPoint.Port}";

                    lock (connectedClients)
                    {
                        if (connectedClients.ContainsKey(clientKey))
                        {
                            // Уже есть подключение с этого устройства
                            using var tempWriter = new StreamWriter(client.GetStream()) { AutoFlush = true };
                            tempWriter.WriteLine("Ошибка: с вашего устройства уже установлено соединение.");
                            client.Close();
                            continue;
                        }

                        connectedClients.Add(clientKey, client);
                    }
                    // досюда


                    var stream = client.GetStream();
                    var reader = new StreamReader(stream, Encoding.UTF8);
                    var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                    string clientName = reader.ReadLine();

                    lock (clients)
                        clients.Add(client);

                    Log($"Подключился клиент {clientName}");

                    Thread clientThread = new Thread(() => HandleClient(client, clientName, clientKey));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (SocketException)
            {
                // Нормальная ситуация при server.Stop()
            }
        }


        void HandleClient(TcpClient client, string clientName, string clientKey)
        {
            try
            {
                using NetworkStream stream = client.GetStream();
                using StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                while (true)
                {
                    string message = reader.ReadLine();
                    if (message == null) break;

                    string formatted = message.Replace("<br>", Environment.NewLine);

                    Log($"{clientName}: {formatted}");
                    Broadcast($"{clientName}: {message}");
                }
            }
            catch
            {
                Log($"Клиент {clientName} отключился");
            }
            finally
            {
                lock (connectedClients)
                    connectedClients.Remove(clientKey);
                
                clients.Remove(client);
                client.Close();
            }
        }

        void Broadcast(string message)
        {
            foreach (var client in clients)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8)
                    {
                        AutoFlush = true
                    };
                    writer.WriteLine(message);
                }
                catch { }
            }
        }

        void Log(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Log(text)));
                return;
            }

            textBoxLog.AppendText(text + Environment.NewLine);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning)
                StopServer();
        }
    }
}
