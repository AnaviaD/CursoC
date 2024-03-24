namespace excelFiles
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
            lbltexto = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            txtPredict = new TextBox();
            btnAction = new Button();
            lblResult = new Label();
            SuspendLayout();
            // 
            // lbltexto
            // 
            lbltexto.AutoSize = true;
            lbltexto.Location = new Point(69, 20);
            lbltexto.Name = "lbltexto";
            lbltexto.Size = new Size(48, 15);
            lbltexto.TabIndex = 0;
            lbltexto.Text = "Archivo";
            // 
            // textBox1
            // 
            textBox1.AllowDrop = true;
            textBox1.Location = new Point(69, 38);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(653, 321);
            textBox1.TabIndex = 1;
            textBox1.DragDrop += textBox1_DragDrop;
            textBox1.DragEnter += textBox1_DragEnter;
            // 
            // button1
            // 
            button1.Location = new Point(69, 387);
            button1.Name = "button1";
            button1.Size = new Size(115, 37);
            button1.TabIndex = 2;
            button1.Text = "Crear Modelo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtPredict
            // 
            txtPredict.Location = new Point(485, 395);
            txtPredict.Name = "txtPredict";
            txtPredict.Size = new Size(198, 23);
            txtPredict.TabIndex = 3;
            // 
            // btnAction
            // 
            btnAction.Location = new Point(689, 395);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(75, 23);
            btnAction.TabIndex = 4;
            btnAction.Text = "Predict";
            btnAction.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(493, 424);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(39, 15);
            lblResult.TabIndex = 5;
            lblResult.Text = "Result";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(btnAction);
            Controls.Add(txtPredict);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(lbltexto);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbltexto;
        private TextBox textBox1;
        private Button button1;
        private TextBox txtPredict;
        private Button btnAction;
        private Label lblResult;
    }
}
