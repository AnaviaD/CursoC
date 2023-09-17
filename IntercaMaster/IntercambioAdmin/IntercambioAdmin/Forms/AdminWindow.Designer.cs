namespace IntercambioAdmin.Forms
{
    partial class AdminWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnDelete = new Button();
            btnPut = new Button();
            btnPost = new Button();
            btnGetAll = new Button();
            bntGet = new Button();
            txtID = new TextBox();
            txtJob = new TextBox();
            txtName = new TextBox();
            txtResponse = new RichTextBox();
            dgMain = new DataGridView();
            equipoTerminalBindingSource = new BindingSource(components);
            deviceIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            terminalNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            terminalTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            terminalLastBackUpDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnDwnload = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)equipoTerminalBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(1272, 71);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(177, 88);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnPut
            // 
            btnPut.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnPut.Location = new Point(1089, 69);
            btnPut.Name = "btnPut";
            btnPut.Size = new Size(177, 90);
            btnPut.TabIndex = 1;
            btnPut.Text = "PUT";
            btnPut.UseVisualStyleBackColor = true;
            // 
            // btnPost
            // 
            btnPost.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnPost.Location = new Point(906, 71);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(177, 88);
            btnPost.TabIndex = 2;
            btnPost.Text = "POST";
            btnPost.UseVisualStyleBackColor = true;
            // 
            // btnGetAll
            // 
            btnGetAll.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnGetAll.Location = new Point(16, 71);
            btnGetAll.Name = "btnGetAll";
            btnGetAll.Size = new Size(138, 88);
            btnGetAll.TabIndex = 3;
            btnGetAll.Text = "GetAll";
            btnGetAll.UseVisualStyleBackColor = true;
            btnGetAll.Click += btnGetAll_Click;
            // 
            // bntGet
            // 
            bntGet.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            bntGet.Location = new Point(160, 108);
            bntGet.Name = "bntGet";
            bntGet.Size = new Size(278, 51);
            bntGet.TabIndex = 4;
            bntGet.Text = "getById";
            bntGet.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            txtID.Location = new Point(160, 71);
            txtID.Name = "txtID";
            txtID.Size = new Size(278, 31);
            txtID.TabIndex = 5;
            // 
            // txtJob
            // 
            txtJob.Location = new Point(529, 128);
            txtJob.Name = "txtJob";
            txtJob.Size = new Size(341, 31);
            txtJob.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(529, 71);
            txtName.Name = "txtName";
            txtName.Size = new Size(341, 31);
            txtName.TabIndex = 7;
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(16, 204);
            txtResponse.Name = "txtResponse";
            txtResponse.Size = new Size(1447, 147);
            txtResponse.TabIndex = 8;
            txtResponse.Text = "";
            // 
            // dgMain
            // 
            dgMain.AllowUserToAddRows = false;
            dgMain.AllowUserToDeleteRows = false;
            dgMain.AutoGenerateColumns = false;
            dgMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMain.Columns.AddRange(new DataGridViewColumn[] { deviceIdDataGridViewTextBoxColumn, terminalNameDataGridViewTextBoxColumn, terminalTypeDataGridViewTextBoxColumn, terminalLastBackUpDataGridViewTextBoxColumn, btnDwnload });
            dgMain.DataSource = equipoTerminalBindingSource;
            dgMain.Dock = DockStyle.Bottom;
            dgMain.Location = new Point(0, 399);
            dgMain.Name = "dgMain";
            dgMain.ReadOnly = true;
            dgMain.RowHeadersWidth = 62;
            dgMain.RowTemplate.Height = 33;
            dgMain.Size = new Size(1475, 322);
            dgMain.TabIndex = 9;
            dgMain.CellContentClick += dgMain_CellContentClick;
            // 
            // equipoTerminalBindingSource
            // 
            equipoTerminalBindingSource.DataSource = typeof(Clases.EquipoTerminal);
            // 
            // deviceIdDataGridViewTextBoxColumn
            // 
            deviceIdDataGridViewTextBoxColumn.DataPropertyName = "deviceId";
            deviceIdDataGridViewTextBoxColumn.HeaderText = "Id";
            deviceIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            deviceIdDataGridViewTextBoxColumn.Name = "deviceIdDataGridViewTextBoxColumn";
            deviceIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // terminalNameDataGridViewTextBoxColumn
            // 
            terminalNameDataGridViewTextBoxColumn.DataPropertyName = "terminalName";
            terminalNameDataGridViewTextBoxColumn.HeaderText = "Nombre";
            terminalNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            terminalNameDataGridViewTextBoxColumn.Name = "terminalNameDataGridViewTextBoxColumn";
            terminalNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // terminalTypeDataGridViewTextBoxColumn
            // 
            terminalTypeDataGridViewTextBoxColumn.DataPropertyName = "terminalType";
            terminalTypeDataGridViewTextBoxColumn.HeaderText = "Tipo";
            terminalTypeDataGridViewTextBoxColumn.MinimumWidth = 8;
            terminalTypeDataGridViewTextBoxColumn.Name = "terminalTypeDataGridViewTextBoxColumn";
            terminalTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // terminalLastBackUpDataGridViewTextBoxColumn
            // 
            terminalLastBackUpDataGridViewTextBoxColumn.DataPropertyName = "terminalLastBackUp";
            terminalLastBackUpDataGridViewTextBoxColumn.HeaderText = "ultimo Back Up";
            terminalLastBackUpDataGridViewTextBoxColumn.MinimumWidth = 8;
            terminalLastBackUpDataGridViewTextBoxColumn.Name = "terminalLastBackUpDataGridViewTextBoxColumn";
            terminalLastBackUpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnDwnload
            // 
            btnDwnload.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            btnDwnload.HeaderText = "Back Up";
            btnDwnload.MinimumWidth = 8;
            btnDwnload.Name = "btnDwnload";
            btnDwnload.ReadOnly = true;
            btnDwnload.Text = "Hacer Back Up !";
            btnDwnload.UseColumnTextForButtonValue = true;
            // 
            // AdminWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1475, 721);
            Controls.Add(dgMain);
            Controls.Add(txtResponse);
            Controls.Add(txtName);
            Controls.Add(txtJob);
            Controls.Add(txtID);
            Controls.Add(bntGet);
            Controls.Add(btnGetAll);
            Controls.Add(btnPost);
            Controls.Add(btnPut);
            Controls.Add(btnDelete);
            Name = "AdminWindow";
            Text = "AdminWindow";
            ((System.ComponentModel.ISupportInitialize)dgMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)equipoTerminalBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private Button btnPut;
        private Button btnPost;
        private Button btnGetAll;
        private Button bntGet;
        private TextBox txtID;
        private TextBox txtJob;
        private TextBox txtName;
        private RichTextBox txtResponse;
        private DataGridView dgMain;
        private BindingSource equipoTerminalBindingSource;
        private DataGridViewTextBoxColumn deviceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn terminalNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn terminalTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn terminalLastBackUpDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn btnDwnload;
    }
}