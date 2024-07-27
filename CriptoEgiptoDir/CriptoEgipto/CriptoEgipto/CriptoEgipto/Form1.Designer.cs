namespace CriptoEgipto
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetTest = new System.Windows.Forms.Button();
            this.pbMainProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnGetTest
            // 
            this.btnGetTest.Location = new System.Drawing.Point(670, 53);
            this.btnGetTest.Name = "btnGetTest";
            this.btnGetTest.Size = new System.Drawing.Size(75, 23);
            this.btnGetTest.TabIndex = 0;
            this.btnGetTest.Text = "GET (test)";
            this.btnGetTest.UseVisualStyleBackColor = true;
            this.btnGetTest.Click += new System.EventHandler(this.btnGetTest_Click);
            // 
            // pbMainProgressBar
            // 
            this.pbMainProgressBar.Location = new System.Drawing.Point(13, 415);
            this.pbMainProgressBar.Name = "pbMainProgressBar";
            this.pbMainProgressBar.Size = new System.Drawing.Size(775, 23);
            this.pbMainProgressBar.TabIndex = 1;
            this.pbMainProgressBar.Click += new System.EventHandler(this.pbMainProgressBar_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbMainProgressBar);
            this.Controls.Add(this.btnGetTest);
            this.Name = "Home";
            this.Text = "Crypto-Egipto";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetTest;
        private System.Windows.Forms.ProgressBar pbMainProgressBar;
    }
}

