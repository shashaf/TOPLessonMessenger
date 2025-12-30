namespace MessengerClient
{
    partial class Form1
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
            SuspendLayout();
            // 
            // chatBox
            // 
            chatBox.Location = new Point(31, 66);
            chatBox.Multiline = true;
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(628, 202);
            chatBox.TabIndex = 0;
            // 
            // messageBox
            // 
            messageBox.Location = new Point(31, 311);
            messageBox.Multiline = true;
            messageBox.Name = "messageBox";
            messageBox.Size = new Size(333, 54);
            messageBox.TabIndex = 1;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(31, 21);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(125, 27);
            nameBox.TabIndex = 2;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(183, 19);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(137, 29);
            connectButton.TabIndex = 3;
            connectButton.Text = "Подключиться";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(388, 323);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(94, 29);
            sendButton.TabIndex = 4;
            sendButton.Text = "Отправить";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sendButton);
            Controls.Add(connectButton);
            Controls.Add(nameBox);
            Controls.Add(messageBox);
            Controls.Add(chatBox);
            Name = "Form1";
            Text = "Form1";
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
    }
}
