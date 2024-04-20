namespace StopWatch
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
            textScreen = new Label();
            startBtn = new Button();
            stopBtn = new Button();
            resetBtn = new Button();
            cb_mainAction = new ComboBox();
            pb_showImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_showImage).BeginInit();
            SuspendLayout();
            // 
            // textScreen
            // 
            textScreen.AutoSize = true;
            textScreen.Font = new Font("Consolas", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textScreen.ForeColor = Color.Cyan;
            textScreen.Location = new Point(67, 28);
            textScreen.Name = "textScreen";
            textScreen.Size = new Size(630, 112);
            textScreen.TabIndex = 0;
            textScreen.Text = "00:00:00:00";
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.FromArgb(0, 205, 151);
            startBtn.FlatStyle = FlatStyle.Popup;
            startBtn.Font = new Font("Consolas", 12F, FontStyle.Bold);
            startBtn.ForeColor = Color.Cyan;
            startBtn.Location = new Point(67, 212);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(160, 60);
            startBtn.TabIndex = 1;
            startBtn.Text = "START";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += startBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.BackColor = Color.FromArgb(247, 86, 91);
            stopBtn.FlatStyle = FlatStyle.Popup;
            stopBtn.Font = new Font("Consolas", 12F, FontStyle.Bold);
            stopBtn.ForeColor = Color.Cyan;
            stopBtn.Location = new Point(67, 294);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(160, 60);
            stopBtn.TabIndex = 2;
            stopBtn.Text = "STOP";
            stopBtn.UseVisualStyleBackColor = false;
            stopBtn.Click += stopBtn_Click;
            // 
            // resetBtn
            // 
            resetBtn.BackColor = Color.FromArgb(25, 130, 196);
            resetBtn.FlatStyle = FlatStyle.Popup;
            resetBtn.Font = new Font("Consolas", 12F, FontStyle.Bold);
            resetBtn.ForeColor = Color.Cyan;
            resetBtn.Location = new Point(67, 376);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(160, 60);
            resetBtn.TabIndex = 3;
            resetBtn.Text = "RESET";
            resetBtn.UseVisualStyleBackColor = false;
            resetBtn.Click += resetBtn_Click;
            // 
            // cb_mainAction
            // 
            cb_mainAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_mainAction.FormattingEnabled = true;
            cb_mainAction.Items.AddRange(new object[] { ".Net", "Angular", "Azure", "HackerRank", "Blender", "linkedin" });
            cb_mainAction.Location = new Point(67, 165);
            cb_mainAction.Name = "cb_mainAction";
            cb_mainAction.Size = new Size(630, 23);
            cb_mainAction.TabIndex = 5;
            cb_mainAction.SelectedIndexChanged += cb_mainAction_SelectedIndexChanged;
            // 
            // pb_showImage
            // 
            pb_showImage.Location = new Point(283, 212);
            pb_showImage.Name = "pb_showImage";
            pb_showImage.Size = new Size(414, 208);
            pb_showImage.TabIndex = 6;
            pb_showImage.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoValidate = AutoValidate.Disable;
            BackColor = Color.FromArgb(29, 39, 48);
            ClientSize = new Size(786, 500);
            Controls.Add(pb_showImage);
            Controls.Add(cb_mainAction);
            Controls.Add(resetBtn);
            Controls.Add(stopBtn);
            Controls.Add(startBtn);
            Controls.Add(textScreen);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pb_showImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label textScreen;
        private Button startBtn;
        private Button stopBtn;
        private Button resetBtn;
        private ComboBox cb_mainAction;
        private PictureBox pb_showImage;
    }
}
