using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections.Generic;


namespace MessengerClient
{
    public partial class ClientForm : Form
    {
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;
        Thread listenThread;
        bool isConnected = false;

        System.Windows.Forms.Timer escTimer;
        bool escPressed = false;

        public ClientForm()
        {
            InitializeComponent();

            escTimer = new System.Windows.Forms.Timer();
            escTimer.Interval = 3000; // 3 секунды
            escTimer.Tick += EscTimer_Tick;

        }

        private void EscTimer_Tick(object sender, EventArgs e)
        {
            escTimer.Stop();

            if (escPressed)
            {
                messageBox.Clear();
            }
        }


        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = IPBox.Text; // получаем IP сервера, которое ввёл пользователь в Textbox
                client = new TcpClient(ip, 5000);  // создаём объекта client, который подключается к порту 5000 по указанному IP-адресу
                var stream = client.GetStream(); // получаем объекта потока для обмена данными с сервером 

                reader = new StreamReader(stream); // сообщаем, что поток stream будет работать как поток для чтения через объект reader
                writer = new StreamWriter(stream) { AutoFlush = true }; // сообщаем, что поток stream будет работать как поток для записи
                                                                        // через объект writer, AutoFlush = true говорит о том, что данные
                                                                        // будут отправляться на сервер сразу же


                writer.WriteLine(nameBox.Text); // отправляем имя пользователя на сервер 

                isConnected = true; // сообщаем, что мы соединились с сервером

                listenThread = new Thread(Listen); // открываем нить (подпрограмму) для прослушивания сервера (через наш метод Listen)
                listenThread.IsBackground = true; // говорим, что эта подпрограмма должна работать в фоновом режиме
                listenThread.Start(); // запускаем подпрограмму 

                chatBox.AppendText($"Вы подключились под именем {nameBox.Text}{Environment.NewLine}"); // выводим в окно чата уведомление о подключении
            }
            catch // блок
            {
                MessageBox.Show("Не удалось подключиться"); // всплывающее окно с сообщением об ошибке
            }
        }

        void Listen()
        {
            try
            {
                while (isConnected) // пока мы соединены с сервером
                {
                    string message = reader.ReadLine(); // проверяем, хочет ли сервер нам что-то сказать (читаем через ReadLine)

                    if (message == null) // сообщение от сервера будет равно null, если соединение разорвано
                        break; // перестаём слушать сервер в таком случае

                    Invoke(new Action(() =>
                    {
                        string formatted = message.Replace("<br>", Environment.NewLine); // новая строка
                        chatBox.AppendText(formatted + Environment.NewLine); // выводим сообщение от сервера в окно с чатом 
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
            if (!isConnected) return; // если мы нажимаем на кнопку, не подключившись к серверу, ничего не происходит

            if (!string.IsNullOrWhiteSpace(messageBox.Text)) // если текстбокс для сообщения не пустой
            {
                string text = messageBox.Text.Replace(Environment.NewLine, "<br>"); // новая строка
                writer.WriteLine(text); // writer - поток для передачи данных на сервер - записывает текст сообщения
                messageBox.Clear(); // текст сообщения очищается
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

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter
            if (e.KeyCode == Keys.Enter)
            {

                if (e.Shift)
                {
                    int cursorPos = messageBox.SelectionStart;
                    messageBox.Text = messageBox.Text.Insert(cursorPos, Environment.NewLine);
                    messageBox.SelectionStart = cursorPos + Environment.NewLine.Length;

                    e.SuppressKeyPress = true; // подавляем стандартный Enter
                }
                else
                {
                    // Enter без Shift → отправка сообщения
                    sendButton.PerformClick();
                    e.SuppressKeyPress = true;
                }
            }

            // Escape
            if (e.KeyCode == Keys.Escape && !escPressed)
            {
                escPressed = true;
                escTimer.Start();
            }
        }

        private void messageBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                escPressed = false;
                escTimer.Stop();
            }
        }
    }
}
