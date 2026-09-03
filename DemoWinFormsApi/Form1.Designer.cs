namespace DemoWinFormsApi
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
            btnLoadData = new Button();
            dgvData = new DataGridView();
            lblState = new Label();
            btnLoadFromDb = new Button();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnLoadData
            // 
            btnLoadData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLoadData.Location = new Point(244, 355);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(300, 29);
            btnLoadData.TabIndex = 0;
            btnLoadData.Text = "Download and save data on db";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += OnClickLoadData;
            // 
            // dgvData
            // 
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.BackgroundColor = SystemColors.InactiveCaption;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(276, 128);
            dgvData.Margin = new Padding(5);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(248, 124);
            dgvData.TabIndex = 1;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // lblState
            // 
            lblState.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblState.Location = new Point(186, 284);
            lblState.Name = "lblState";
            lblState.Size = new Size(413, 50);
            lblState.TabIndex = 2;
            lblState.Text = "Load State";
            lblState.TextAlign = ContentAlignment.TopCenter;
            lblState.Click += OnClickLoadData;
            // 
            // btnLoadFromDb
            // 
            btnLoadFromDb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLoadFromDb.Location = new Point(244, 400);
            btnLoadFromDb.Name = "btnLoadFromDb";
            btnLoadFromDb.Size = new Size(300, 29);
            btnLoadFromDb.TabIndex = 4;
            btnLoadFromDb.Text = "Load From DB and populate grid";
            btnLoadFromDb.UseVisualStyleBackColor = true;
            btnLoadFromDb.Click += btnLoadFromDatabase;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.HotTrack;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(3, 200, 3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 60);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "FDI System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitle);
            Controls.Add(btnLoadFromDb);
            Controls.Add(lblState);
            Controls.Add(dgvData);
            Controls.Add(btnLoadData);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadData;
        private DataGridView dgvData;
        private Label lblState;
        private Button btnLoadFromDb;
        private Label lblTitle;
    }
}
