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
            btnGetData = new Button();
            txtPredict = new TextBox();
            btnAction = new Button();
            lblResult = new Label();
            btnGetModel = new Button();
            dtOutput = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtOutput).BeginInit();
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
            textBox1.Size = new Size(657, 163);
            textBox1.TabIndex = 1;
            textBox1.DragDrop += textBox1_DragDrop;
            textBox1.DragEnter += textBox1_DragEnter;
            // 
            // btnGetData
            // 
            btnGetData.Location = new Point(74, 603);
            btnGetData.Name = "btnGetData";
            btnGetData.Size = new Size(115, 37);
            btnGetData.TabIndex = 2;
            btnGetData.Text = "Obtener Data";
            btnGetData.UseVisualStyleBackColor = true;
            btnGetData.Click += button1_Click;
            // 
            // txtPredict
            // 
            txtPredict.Location = new Point(411, 611);
            txtPredict.Name = "txtPredict";
            txtPredict.Size = new Size(198, 23);
            txtPredict.TabIndex = 3;
            // 
            // btnAction
            // 
            btnAction.Location = new Point(615, 611);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(75, 23);
            btnAction.TabIndex = 4;
            btnAction.Text = "Predict";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(419, 640);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(39, 15);
            lblResult.TabIndex = 5;
            lblResult.Text = "Result";
            // 
            // btnGetModel
            // 
            btnGetModel.Location = new Point(195, 603);
            btnGetModel.Name = "btnGetModel";
            btnGetModel.Size = new Size(115, 37);
            btnGetModel.TabIndex = 6;
            btnGetModel.Text = "Crear Modelo";
            btnGetModel.UseVisualStyleBackColor = true;
            btnGetModel.Click += button2_Click;
            // 
            // dtOutput
            // 
            dtOutput.AllowUserToOrderColumns = true;
            dtOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtOutput.Location = new Point(74, 244);
            dtOutput.Name = "dtOutput";
            dtOutput.Size = new Size(652, 313);
            dtOutput.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 689);
            Controls.Add(dtOutput);
            Controls.Add(btnGetModel);
            Controls.Add(lblResult);
            Controls.Add(btnAction);
            Controls.Add(txtPredict);
            Controls.Add(btnGetData);
            Controls.Add(textBox1);
            Controls.Add(lbltexto);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dtOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbltexto;
        private TextBox textBox1;
        private Button btnGetData;
        private TextBox txtPredict;
        private Button btnAction;
        private Label lblResult;
        private Button btnGetModel;
        private DataGridView dtOutput;
    }
}
