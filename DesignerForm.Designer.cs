namespace BOzdemirQGame
{
    partial class DesignerForm
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblRows = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.lblColumns = new System.Windows.Forms.Label();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.lblToolBox = new System.Windows.Forms.Label();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnRedDoor = new System.Windows.Forms.Button();
            this.btnGreenDoor = new System.Windows.Forms.Button();
            this.btnRedBox = new System.Windows.Forms.Button();
            this.btnGreenBox = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pboxRedDoor = new System.Windows.Forms.PictureBox();
            this.pboxGreenDoor = new System.Windows.Forms.PictureBox();
            this.pboxGreenBox = new System.Windows.Forms.PictureBox();
            this.pboxRedBox = new System.Windows.Forms.PictureBox();
            this.pboxWall = new System.Windows.Forms.PictureBox();
            this.pboxNone = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pboxRedDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGreenDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxRedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxNone)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Yellow;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Black;
            this.btnGenerate.Location = new System.Drawing.Point(310, 31);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 43);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(15, 39);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(44, 16);
            this.lblRows.TabIndex = 1;
            this.lblRows.Text = "Rows:";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(65, 39);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(58, 22);
            this.txtRows.TabIndex = 2;
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(141, 39);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(62, 16);
            this.lblColumns.TabIndex = 1;
            this.lblColumns.Text = "Columns:";
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(206, 39);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(58, 22);
            this.txtColumns.TabIndex = 2;
            // 
            // lblToolBox
            // 
            this.lblToolBox.AutoSize = true;
            this.lblToolBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblToolBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolBox.Location = new System.Drawing.Point(12, 77);
            this.lblToolBox.Name = "lblToolBox";
            this.lblToolBox.Size = new System.Drawing.Size(111, 29);
            this.lblToolBox.TabIndex = 3;
            this.lblToolBox.Text = "ToolBox";
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(17, 133);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(157, 64);
            this.btnNone.TabIndex = 4;
            this.btnNone.Text = "None";
            this.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNone.UseVisualStyleBackColor = true;
            // 
            // btnWall
            // 
            this.btnWall.Location = new System.Drawing.Point(17, 214);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(157, 64);
            this.btnWall.TabIndex = 4;
            this.btnWall.Text = "Wall";
            this.btnWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWall.UseVisualStyleBackColor = true;
            // 
            // btnRedDoor
            // 
            this.btnRedDoor.Location = new System.Drawing.Point(17, 295);
            this.btnRedDoor.Name = "btnRedDoor";
            this.btnRedDoor.Size = new System.Drawing.Size(157, 72);
            this.btnRedDoor.TabIndex = 4;
            this.btnRedDoor.Text = "Red Door";
            this.btnRedDoor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedDoor.UseVisualStyleBackColor = true;
            // 
            // btnGreenDoor
            // 
            this.btnGreenDoor.Location = new System.Drawing.Point(17, 398);
            this.btnGreenDoor.Name = "btnGreenDoor";
            this.btnGreenDoor.Size = new System.Drawing.Size(157, 72);
            this.btnGreenDoor.TabIndex = 4;
            this.btnGreenDoor.Text = "Green Door";
            this.btnGreenDoor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGreenDoor.UseVisualStyleBackColor = true;
            // 
            // btnRedBox
            // 
            this.btnRedBox.Location = new System.Drawing.Point(17, 484);
            this.btnRedBox.Name = "btnRedBox";
            this.btnRedBox.Size = new System.Drawing.Size(157, 64);
            this.btnRedBox.TabIndex = 4;
            this.btnRedBox.Text = "Red Box";
            this.btnRedBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedBox.UseVisualStyleBackColor = true;
            // 
            // btnGreenBox
            // 
            this.btnGreenBox.Location = new System.Drawing.Point(17, 565);
            this.btnGreenBox.Name = "btnGreenBox";
            this.btnGreenBox.Size = new System.Drawing.Size(157, 64);
            this.btnGreenBox.TabIndex = 4;
            this.btnGreenBox.Text = "Green Box";
            this.btnGreenBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGreenBox.UseVisualStyleBackColor = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Location = new System.Drawing.Point(321, 141);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(455, 466);
            this.pnlGrid.TabIndex = 6;
            // 
            // pboxRedDoor
            // 
            this.pboxRedDoor.BackColor = System.Drawing.Color.Lime;
            this.pboxRedDoor.Image = global::BOzdemirQGame.Properties.Resources.reddoor;
            this.pboxRedDoor.Location = new System.Drawing.Point(32, 295);
            this.pboxRedDoor.Name = "pboxRedDoor";
            this.pboxRedDoor.Size = new System.Drawing.Size(57, 72);
            this.pboxRedDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxRedDoor.TabIndex = 5;
            this.pboxRedDoor.TabStop = false;
            // 
            // pboxGreenDoor
            // 
            this.pboxGreenDoor.BackColor = System.Drawing.Color.Lime;
            this.pboxGreenDoor.Image = global::BOzdemirQGame.Properties.Resources.greendoor;
            this.pboxGreenDoor.Location = new System.Drawing.Point(32, 398);
            this.pboxGreenDoor.Name = "pboxGreenDoor";
            this.pboxGreenDoor.Size = new System.Drawing.Size(57, 72);
            this.pboxGreenDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxGreenDoor.TabIndex = 5;
            this.pboxGreenDoor.TabStop = false;
            // 
            // pboxGreenBox
            // 
            this.pboxGreenBox.BackColor = System.Drawing.Color.Lime;
            this.pboxGreenBox.Image = global::BOzdemirQGame.Properties.Resources.greenbox;
            this.pboxGreenBox.Location = new System.Drawing.Point(32, 571);
            this.pboxGreenBox.Name = "pboxGreenBox";
            this.pboxGreenBox.Size = new System.Drawing.Size(57, 50);
            this.pboxGreenBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxGreenBox.TabIndex = 5;
            this.pboxGreenBox.TabStop = false;
            // 
            // pboxRedBox
            // 
            this.pboxRedBox.BackColor = System.Drawing.Color.Red;
            this.pboxRedBox.Image = global::BOzdemirQGame.Properties.Resources.redbox;
            this.pboxRedBox.Location = new System.Drawing.Point(32, 490);
            this.pboxRedBox.Name = "pboxRedBox";
            this.pboxRedBox.Size = new System.Drawing.Size(57, 50);
            this.pboxRedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxRedBox.TabIndex = 5;
            this.pboxRedBox.TabStop = false;
            // 
            // pboxWall
            // 
            this.pboxWall.BackColor = System.Drawing.Color.Silver;
            this.pboxWall.Image = global::BOzdemirQGame.Properties.Resources.wall;
            this.pboxWall.Location = new System.Drawing.Point(32, 220);
            this.pboxWall.Name = "pboxWall";
            this.pboxWall.Size = new System.Drawing.Size(57, 50);
            this.pboxWall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxWall.TabIndex = 5;
            this.pboxWall.TabStop = false;
            // 
            // pboxNone
            // 
            this.pboxNone.BackColor = System.Drawing.Color.White;
            this.pboxNone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxNone.Image = global::BOzdemirQGame.Properties.Resources.none;
            this.pboxNone.Location = new System.Drawing.Point(32, 139);
            this.pboxNone.Name = "pboxNone";
            this.pboxNone.Size = new System.Drawing.Size(57, 50);
            this.pboxNone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxNone.TabIndex = 5;
            this.pboxNone.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStripFile
            // 
            this.menuStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuStripFile.Name = "menuStripFile";
            this.menuStripFile.Size = new System.Drawing.Size(46, 24);
            this.menuStripFile.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // DesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 658);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pboxRedDoor);
            this.Controls.Add(this.pboxGreenDoor);
            this.Controls.Add(this.pboxGreenBox);
            this.Controls.Add(this.pboxRedBox);
            this.Controls.Add(this.pboxWall);
            this.Controls.Add(this.pboxNone);
            this.Controls.Add(this.lblToolBox);
            this.Controls.Add(this.txtColumns);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.btnGreenDoor);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.btnGreenBox);
            this.Controls.Add(this.btnRedDoor);
            this.Controls.Add(this.btnRedBox);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnWall);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DesignerForm";
            this.Text = "DesignerForm";
//            this.Load += new System.EventHandler(this.DesignerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxRedDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGreenDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxRedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxNone)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.Label lblToolBox;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.PictureBox pboxNone;
        private System.Windows.Forms.Button btnWall;
        private System.Windows.Forms.PictureBox pboxWall;
        private System.Windows.Forms.Button btnRedDoor;
        private System.Windows.Forms.Button btnGreenDoor;
        private System.Windows.Forms.PictureBox pboxGreenDoor;
        private System.Windows.Forms.Button btnRedBox;
        private System.Windows.Forms.PictureBox pboxRedBox;
        private System.Windows.Forms.Button btnGreenBox;
        private System.Windows.Forms.PictureBox pboxGreenBox;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.PictureBox pboxRedDoor;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStripFile;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}