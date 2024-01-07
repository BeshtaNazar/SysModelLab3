namespace Lab3
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.pondDataGridView = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tactsCountLabel = new System.Windows.Forms.Label();
            this.stopTimerButton = new System.Windows.Forms.Button();
            this.startTimerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pondDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pondDataGridView
            // 
            this.pondDataGridView.AllowUserToAddRows = false;
            this.pondDataGridView.AllowUserToDeleteRows = false;
            this.pondDataGridView.AllowUserToResizeColumns = false;
            this.pondDataGridView.AllowUserToResizeRows = false;
            this.pondDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.pondDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pondDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.pondDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.pondDataGridView.ColumnHeadersVisible = false;
            this.pondDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pondDataGridView.Location = new System.Drawing.Point(0, 33);
            this.pondDataGridView.MultiSelect = false;
            this.pondDataGridView.Name = "pondDataGridView";
            this.pondDataGridView.ReadOnly = true;
            this.pondDataGridView.RowHeadersVisible = false;
            this.pondDataGridView.ShowCellToolTips = false;
            this.pondDataGridView.Size = new System.Drawing.Size(800, 417);
            this.pondDataGridView.TabIndex = 0;
            this.pondDataGridView.SelectionChanged += new System.EventHandler(this.pondDataGridView_SelectionChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tactsCountLabel
            // 
            this.tactsCountLabel.AutoSize = true;
            this.tactsCountLabel.Location = new System.Drawing.Point(12, 9);
            this.tactsCountLabel.Name = "tactsCountLabel";
            this.tactsCountLabel.Size = new System.Drawing.Size(35, 13);
            this.tactsCountLabel.TabIndex = 1;
            this.tactsCountLabel.Text = "label1";
            // 
            // stopTimerButton
            // 
            this.stopTimerButton.Location = new System.Drawing.Point(116, 4);
            this.stopTimerButton.Name = "stopTimerButton";
            this.stopTimerButton.Size = new System.Drawing.Size(75, 23);
            this.stopTimerButton.TabIndex = 2;
            this.stopTimerButton.Text = "Stop";
            this.stopTimerButton.UseVisualStyleBackColor = true;
            this.stopTimerButton.Click += new System.EventHandler(this.stopTimerButton_Click);
            // 
            // startTimerButton
            // 
            this.startTimerButton.Location = new System.Drawing.Point(197, 4);
            this.startTimerButton.Name = "startTimerButton";
            this.startTimerButton.Size = new System.Drawing.Size(75, 23);
            this.startTimerButton.TabIndex = 3;
            this.startTimerButton.Text = "Continue";
            this.startTimerButton.UseVisualStyleBackColor = true;
            this.startTimerButton.Click += new System.EventHandler(this.startTimerButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startTimerButton);
            this.Controls.Add(this.stopTimerButton);
            this.Controls.Add(this.tactsCountLabel);
            this.Controls.Add(this.pondDataGridView);
            this.Name = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.SizeChanged += new System.EventHandler(this.GameForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pondDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView pondDataGridView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label tactsCountLabel;
        private System.Windows.Forms.Button stopTimerButton;
        private System.Windows.Forms.Button startTimerButton;
    }
}