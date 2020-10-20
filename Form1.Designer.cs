namespace MyExcelLAB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.TableOut = new System.Windows.Forms.ToolStripTextBox();
            this.Enter = new System.Windows.Forms.ToolStripButton();
            this.AddColumn = new System.Windows.Forms.ToolStripButton();
            this.DeleteColumn = new System.Windows.Forms.ToolStripButton();
            this.AddRow = new System.Windows.Forms.ToolStripButton();
            this.DeleteRow = new System.Windows.Forms.ToolStripButton();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.AllowItemReorder = true;
            this.ToolStrip.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ToolStrip.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TableOut,
            this.Enter,
            this.AddColumn,
            this.DeleteColumn,
            this.AddRow,
            this.DeleteRow});
            this.ToolStrip.Location = new System.Drawing.Point(0, 33);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(812, 32);
            this.ToolStrip.TabIndex = 4;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // TableOut
            // 
            this.TableOut.AutoSize = false;
            this.TableOut.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TableOut.Name = "TableOut";
            this.TableOut.Size = new System.Drawing.Size(300, 31);
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Enter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Enter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Enter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(56, 29);
            this.Enter.Text = "Enter";
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // AddColumn
            // 
            this.AddColumn.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.AddColumn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddColumn.Name = "AddColumn";
            this.AddColumn.Size = new System.Drawing.Size(117, 29);
            this.AddColumn.Text = "Add Column";
            this.AddColumn.Click += new System.EventHandler(this.AddColumn_Click);
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.DeleteColumn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Size = new System.Drawing.Size(133, 29);
            this.DeleteColumn.Text = "Delete Column";
            this.DeleteColumn.Click += new System.EventHandler(this.DeleteColumn_Click);
            // 
            // AddRow
            // 
            this.AddRow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddRow.Name = "AddRow";
            this.AddRow.Size = new System.Drawing.Size(85, 29);
            this.AddRow.Text = "Add row";
            this.AddRow.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // DeleteRow
            // 
            this.DeleteRow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeleteRow.Name = "DeleteRow";
            this.DeleteRow.Size = new System.Drawing.Size(101, 29);
            this.DeleteRow.Text = "Delete row";
            this.DeleteRow.Click += new System.EventHandler(this.DeleteRow_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGV.ColumnHeadersHeight = 30;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 65);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 70;
            this.DGV.Size = new System.Drawing.Size(812, 475);
            this.DGV.TabIndex = 6;
            this.DGV.Text = "dataGridView1";
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Ivory;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 33);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Ivory;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(52, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(207, 30);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(204, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(207, 30);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(812, 540);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(830, 587);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton AddRow;
        private System.Windows.Forms.ToolStripButton AddColumn;
        private System.Windows.Forms.ToolStripButton DeleteRow;
        private System.Windows.Forms.ToolStripButton DeleteColumn;
        private System.Windows.Forms.ToolStripTextBox TableOut;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ToolStripButton Enter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;  
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

