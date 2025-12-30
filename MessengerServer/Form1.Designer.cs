namespace MessengerServer
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
            textBoxLog = new TextBox();
            runButton = new Button();
            SuspendLayout();
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(12, 12);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.Size = new Size(755, 310);
            textBoxLog.TabIndex = 0;
            // 
            // runButton
            // 
            runButton.Location = new Point(288, 350);
            runButton.Name = "runButton";
            runButton.Size = new Size(205, 29);
            runButton.TabIndex = 1;
            runButton.Text = "Запустить сервер";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(runButton);
            Controls.Add(textBoxLog);
            Name = "Form1";
            Text = "Форма сервера";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLog;
        private Button runButton;
    }
}
