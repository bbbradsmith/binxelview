namespace Binxelview.Dialogs
{
    partial class ViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.tableBase = new System.Windows.Forms.TableLayoutPanel();
            this.pixelBox = new System.Windows.Forms.PictureBox();
            this.pixelScroll = new System.Windows.Forms.VScrollBar();
            this.tableBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableBase
            // 
            this.tableBase.AutoSize = true;
            this.tableBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableBase.ColumnCount = 2;
            this.tableBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableBase.Controls.Add(this.pixelBox, 0, 0);
            this.tableBase.Controls.Add(this.pixelScroll, 1, 0);
            this.tableBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBase.Location = new System.Drawing.Point(0, 0);
            this.tableBase.Name = "tableBase";
            this.tableBase.RowCount = 1;
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.Size = new System.Drawing.Size(542, 518);
            this.tableBase.TabIndex = 1;
            // 
            // pixelBox
            // 
            this.pixelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pixelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelBox.Location = new System.Drawing.Point(3, 3);
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.Size = new System.Drawing.Size(512, 512);
            this.pixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pixelBox.TabIndex = 1;
            this.pixelBox.TabStop = false;
            this.pixelBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pixelBox_MouseMove);
            this.pixelBox.Resize += new System.EventHandler(this.pixelBox_Resize);
            // 
            // pixelScroll
            // 
            this.pixelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelScroll.LargeChange = 1;
            this.pixelScroll.Location = new System.Drawing.Point(518, 0);
            this.pixelScroll.Maximum = 0;
            this.pixelScroll.Name = "pixelScroll";
            this.pixelScroll.Size = new System.Drawing.Size(24, 518);
            this.pixelScroll.TabIndex = 1;
            this.pixelScroll.TabStop = true;
            this.pixelScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pixelScroll_Scroll);
            // 
            // ViewForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 518);
            this.Controls.Add(this.tableBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewForm";
            this.Text = "Pixels";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ViewForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ViewForm_DragEnter);
            this.tableBase.ResumeLayout(false);
            this.tableBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableBase;
        private System.Windows.Forms.PictureBox pixelBox;
        private System.Windows.Forms.VScrollBar pixelScroll;
    }
}