namespace MessengerClient
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chatBox = new TextBox();
            messageBox = new TextBox();
            nameBox = new TextBox();
            connectButton = new Button();
            sendButton = new Button();
            IPBox = new TextBox();
            IPLabel = new Label();
            nameLabel = new Label();
            SuspendLayout();
            // 
            // chatBox
            // 
            chatBox.Location = new Point(27, 50);
            chatBox.Margin = new Padding(3, 2, 3, 2);
            chatBox.Multiline = true;
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(550, 152);
            chatBox.TabIndex = 0;
            // 
            // messageBox
            // 
            messageBox.Location = new Point(27, 233);
            messageBox.Margin = new Padding(3, 2, 3, 2);
            messageBox.Multiline = true;
            messageBox.Name = "messageBox";
            messageBox.Size = new Size(292, 42);
            messageBox.TabIndex = 1;
            messageBox.KeyDown += messageBox_KeyDown;
            messageBox.KeyUp += messageBox_KeyUp;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(27, 16);
            nameBox.Margin = new Padding(3, 2, 3, 2);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(110, 23);
            nameBox.TabIndex = 2;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(290, 15);
            connectButton.Margin = new Padding(3, 2, 3, 2);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(120, 22);
            connectButton.TabIndex = 3;
            connectButton.Text = "Подключиться";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(340, 242);
            sendButton.Margin = new Padding(3, 2, 3, 2);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(82, 22);
            sendButton.TabIndex = 4;
            sendButton.Text = "Отправить";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // IPBox
            // 
            IPBox.Location = new Point(157, 16);
            IPBox.Margin = new Padding(3, 2, 3, 2);
            IPBox.Name = "IPBox";
            IPBox.Size = new Size(110, 23);
            IPBox.TabIndex = 5;
            IPBox.Text = "192.168.0.143";
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Location = new Point(178, 1);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(51, 15);
            IPLabel.TabIndex = 6;
            IPLabel.Text = "IP адрес";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(45, 1);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(31, 15);
            nameLabel.TabIndex = 6;
            nameLabel.Text = "Имя";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(nameLabel);
            Controls.Add(IPLabel);
            Controls.Add(IPBox);
            Controls.Add(sendButton);
            Controls.Add(connectButton);
            Controls.Add(nameBox);
            Controls.Add(messageBox);
            Controls.Add(chatBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClientForm";
            Text = "Форма клиента";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox chatBox;
        private TextBox messageBox;
        private TextBox nameBox;
        private Button connectButton;
        private Button sendButton;
        private TextBox IPBox;
        private Label IPLabel;
        private Label nameLabel;
    }
}
