﻿namespace Binxelview
{
    partial class BinxelviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BinxelviewForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBinaryChunkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadPresetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetStripMenuDash = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decimalPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexadecimalPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsStripMenuDash1 = new System.Windows.Forms.ToolStripSeparator();
            this.snapScrollToNextStrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsStripMenuDash2 = new System.Windows.Forms.ToolStripSeparator();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsStripMenuDash3 = new System.Windows.Forms.ToolStripSeparator();
            this.verticalLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsStripMenuDash4 = new System.Windows.Forms.ToolStripSeparator();
            this.twiddleZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twiddleNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableTop = new System.Windows.Forms.TableLayoutPanel();
            this.groupPacking = new System.Windows.Forms.GroupBox();
            this.buttonPixel = new System.Windows.Forms.Button();
            this.buttonRow = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.checkAutoNext = new System.Windows.Forms.CheckBox();
            this.checkAutoRow = new System.Windows.Forms.CheckBox();
            this.checkAutoPixel = new System.Windows.Forms.CheckBox();
            this.buttonSavePreset = new System.Windows.Forms.Button();
            this.buttonLoadPreset = new System.Windows.Forms.Button();
            this.buttonDefaultPreset = new System.Windows.Forms.Button();
            this.numericRowStrideBit = new System.Windows.Forms.NumericUpDown();
            this.numericNextStrideBit = new System.Windows.Forms.NumericUpDown();
            this.numericPixelStrideBit = new System.Windows.Forms.NumericUpDown();
            this.numericRowStrideByte = new System.Windows.Forms.NumericUpDown();
            this.numericNextStrideByte = new System.Windows.Forms.NumericUpDown();
            this.numericPixelStrideByte = new System.Windows.Forms.NumericUpDown();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelBPP = new System.Windows.Forms.Label();
            this.numericBPP = new System.Windows.Forms.NumericUpDown();
            this.checkChunky = new System.Windows.Forms.CheckBox();
            this.checkEndian = new System.Windows.Forms.CheckBox();
            this.dataGridPixel = new System.Windows.Forms.DataGridView();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offByte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offBit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPalette = new System.Windows.Forms.GroupBox();
            this.buttonGrey = new System.Windows.Forms.Button();
            this.labelInfoPal = new System.Windows.Forms.Label();
            this.buttonSavePal = new System.Windows.Forms.Button();
            this.buttonLoadPal = new System.Windows.Forms.Button();
            this.buttonRGBPal = new System.Windows.Forms.Button();
            this.buttonRandomPal = new System.Windows.Forms.Button();
            this.bgLabel = new System.Windows.Forms.Label();
            this.bgBox = new System.Windows.Forms.PictureBox();
            this.paletteBox = new System.Windows.Forms.PictureBox();
            this.tablePosPlane = new System.Windows.Forms.TableLayoutPanel();
            this.groupPosition = new System.Windows.Forms.GroupBox();
            this.buttonZero = new System.Windows.Forms.Button();
            this.buttonBitPos = new System.Windows.Forms.Button();
            this.buttonZoom = new System.Windows.Forms.Button();
            this.buttonBytePos = new System.Windows.Forms.Button();
            this.numericZoom = new System.Windows.Forms.NumericUpDown();
            this.labelInfoPixel = new System.Windows.Forms.Label();
            this.numericPosBit = new System.Windows.Forms.NumericUpDown();
            this.numericPosByte = new System.Windows.Forms.NumericUpDown();
            this.groupTile = new System.Windows.Forms.GroupBox();
            this.labelTileStride = new System.Windows.Forms.Label();
            this.labelTileSize = new System.Windows.Forms.Label();
            this.labelTileY = new System.Windows.Forms.Label();
            this.numericTileSizeY = new System.Windows.Forms.NumericUpDown();
            this.numericTileStrideBitY = new System.Windows.Forms.NumericUpDown();
            this.numericTileStrideByteY = new System.Windows.Forms.NumericUpDown();
            this.labelTileX = new System.Windows.Forms.Label();
            this.numericTileSizeX = new System.Windows.Forms.NumericUpDown();
            this.numericTileStrideBitX = new System.Windows.Forms.NumericUpDown();
            this.numericTileStrideByteX = new System.Windows.Forms.NumericUpDown();
            this.tableBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableBottom = new System.Windows.Forms.TableLayoutPanel();
            this.pixelBox = new System.Windows.Forms.PictureBox();
            this.contextMenuPixel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionToPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelScroll = new System.Windows.Forms.VScrollBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStripMain.SuspendLayout();
            this.tableTop.SuspendLayout();
            this.groupPacking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRowStrideBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNextStrideBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPixelStrideBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRowStrideByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNextStrideByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPixelStrideByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPixel)).BeginInit();
            this.groupPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteBox)).BeginInit();
            this.tablePosPlane.SuspendLayout();
            this.groupPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPosBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPosByte)).BeginInit();
            this.groupTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileStrideBitY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileStrideByteY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileStrideBitX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileStrideByteX)).BeginInit();
            this.tableBase.SuspendLayout();
            this.tableBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.contextMenuPixel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.presetToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(797, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.reloadFileToolStripMenuItem,
            this.saveAllVisibleToolStripMenuItem,
            this.exportBinaryChunkToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // reloadFileToolStripMenuItem
            // 
            this.reloadFileToolStripMenuItem.Name = "reloadFileToolStripMenuItem";
            this.reloadFileToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.reloadFileToolStripMenuItem.Text = "&Reload";
            this.reloadFileToolStripMenuItem.Click += new System.EventHandler(this.reloadFileToolStripMenuItem_Click);
            // 
            // saveAllVisibleToolStripMenuItem
            // 
            this.saveAllVisibleToolStripMenuItem.Name = "saveAllVisibleToolStripMenuItem";
            this.saveAllVisibleToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveAllVisibleToolStripMenuItem.Text = "&Save &All Visible";
            this.saveAllVisibleToolStripMenuItem.Click += new System.EventHandler(this.saveAllVisibleToolStripMenuItem_Click);
            // 
            // exportBinaryChunkToolStripMenuItem
            // 
            this.exportBinaryChunkToolStripMenuItem.Name = "exportBinaryChunkToolStripMenuItem";
            this.exportBinaryChunkToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exportBinaryChunkToolStripMenuItem.Text = "Export Binary Chunk...";
            this.exportBinaryChunkToolStripMenuItem.Click += new System.EventHandler(this.exportBinaryChunkToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // presetToolStripMenuItem
            // 
            this.presetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadPresetsToolStripMenuItem,
            this.presetStripMenuDash});
            this.presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            this.presetToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.presetToolStripMenuItem.Text = "&Preset";
            // 
            // reloadPresetsToolStripMenuItem
            // 
            this.reloadPresetsToolStripMenuItem.Name = "reloadPresetsToolStripMenuItem";
            this.reloadPresetsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reloadPresetsToolStripMenuItem.Text = "&Reload";
            this.reloadPresetsToolStripMenuItem.Click += new System.EventHandler(this.reloadPresetsToolStripMenuItem_Click);
            // 
            // presetStripMenuDash
            // 
            this.presetStripMenuDash.Name = "presetStripMenuDash";
            this.presetStripMenuDash.Size = new System.Drawing.Size(177, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decimalPositionToolStripMenuItem,
            this.hexadecimalPositionToolStripMenuItem,
            this.optionsStripMenuDash1,
            this.snapScrollToNextStrideToolStripMenuItem,
            this.optionsStripMenuDash2,
            this.gridToolStripMenuItem,
            this.optionsStripMenuDash3,
            this.verticalLayoutToolStripMenuItem,
            this.horizontalLayoutToolStripMenuItem,
            this.optionsStripMenuDash4,
            this.twiddleZToolStripMenuItem,
            this.twiddleNToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // decimalPositionToolStripMenuItem
            // 
            this.decimalPositionToolStripMenuItem.Name = "decimalPositionToolStripMenuItem";
            this.decimalPositionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.decimalPositionToolStripMenuItem.Text = "&Decimal Position";
            this.decimalPositionToolStripMenuItem.Click += new System.EventHandler(this.decimalPositionToolStripMenuItem_Click);
            // 
            // hexadecimalPositionToolStripMenuItem
            // 
            this.hexadecimalPositionToolStripMenuItem.Checked = true;
            this.hexadecimalPositionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hexadecimalPositionToolStripMenuItem.Name = "hexadecimalPositionToolStripMenuItem";
            this.hexadecimalPositionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.hexadecimalPositionToolStripMenuItem.Text = "&Hexadecimal Position";
            this.hexadecimalPositionToolStripMenuItem.Click += new System.EventHandler(this.hexadecimalPositionToolStripMenuItem_Click);
            // 
            // optionsStripMenuDash1
            // 
            this.optionsStripMenuDash1.Name = "optionsStripMenuDash1";
            this.optionsStripMenuDash1.Size = new System.Drawing.Size(200, 6);
            // 
            // snapScrollToNextStrideToolStripMenuItem
            // 
            this.snapScrollToNextStrideToolStripMenuItem.Checked = true;
            this.snapScrollToNextStrideToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.snapScrollToNextStrideToolStripMenuItem.Name = "snapScrollToNextStrideToolStripMenuItem";
            this.snapScrollToNextStrideToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.snapScrollToNextStrideToolStripMenuItem.Text = "&Snap scroll to next stride";
            this.snapScrollToNextStrideToolStripMenuItem.Click += new System.EventHandler(this.snapScrollToNextStrideToolStripMenuItem_Click);
            // 
            // optionsStripMenuDash2
            // 
            this.optionsStripMenuDash2.Name = "optionsStripMenuDash2";
            this.optionsStripMenuDash2.Size = new System.Drawing.Size(200, 6);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Checked = true;
            this.gridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.gridToolStripMenuItem.Text = "&Grid Padding";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // optionsStripMenuDash3
            // 
            this.optionsStripMenuDash3.Name = "optionsStripMenuDash3";
            this.optionsStripMenuDash3.Size = new System.Drawing.Size(200, 6);
            // 
            // verticalLayoutToolStripMenuItem
            // 
            this.verticalLayoutToolStripMenuItem.Checked = true;
            this.verticalLayoutToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.verticalLayoutToolStripMenuItem.Name = "verticalLayoutToolStripMenuItem";
            this.verticalLayoutToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.verticalLayoutToolStripMenuItem.Text = "&Vertical layout";
            this.verticalLayoutToolStripMenuItem.Click += new System.EventHandler(this.verticalLayoutToolStripMenuItem_Click);
            // 
            // horizontalLayoutToolStripMenuItem
            // 
            this.horizontalLayoutToolStripMenuItem.Name = "horizontalLayoutToolStripMenuItem";
            this.horizontalLayoutToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.horizontalLayoutToolStripMenuItem.Text = "H&orizontal layout";
            this.horizontalLayoutToolStripMenuItem.Click += new System.EventHandler(this.horizontalLayoutToolStripMenuItem_Click);
            // 
            // optionsStripMenuDash4
            // 
            this.optionsStripMenuDash4.Name = "optionsStripMenuDash4";
            this.optionsStripMenuDash4.Size = new System.Drawing.Size(200, 6);
            // 
            // twiddleZToolStripMenuItem
            // 
            this.twiddleZToolStripMenuItem.Name = "twiddleZToolStripMenuItem";
            this.twiddleZToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.twiddleZToolStripMenuItem.Text = "Twiddle &Z";
            this.twiddleZToolStripMenuItem.Click += new System.EventHandler(this.twiddleZToolStripMenuItem_Click);
            // 
            // twiddleNToolStripMenuItem
            // 
            this.twiddleNToolStripMenuItem.Name = "twiddleNToolStripMenuItem";
            this.twiddleNToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.twiddleNToolStripMenuItem.Text = "Twiddle &N";
            this.twiddleNToolStripMenuItem.Click += new System.EventHandler(this.twiddleNToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tableTop
            // 
            this.tableTop.AutoSize = true;
            this.tableTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableTop.ColumnCount = 3;
            this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableTop.Controls.Add(this.groupPacking, 1, 0);
            this.tableTop.Controls.Add(this.groupPalette, 2, 0);
            this.tableTop.Controls.Add(this.tablePosPlane, 0, 0);
            this.tableTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTop.Location = new System.Drawing.Point(0, 0);
            this.tableTop.Margin = new System.Windows.Forms.Padding(0);
            this.tableTop.Name = "tableTop";
            this.tableTop.RowCount = 1;
            this.tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTop.Size = new System.Drawing.Size(797, 233);
            this.tableTop.TabIndex = 0;
            // 
            // groupPacking
            // 
            this.groupPacking.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupPacking.Controls.Add(this.buttonPixel);
            this.groupPacking.Controls.Add(this.buttonRow);
            this.groupPacking.Controls.Add(this.buttonNext);
            this.groupPacking.Controls.Add(this.checkAutoNext);
            this.groupPacking.Controls.Add(this.checkAutoRow);
            this.groupPacking.Controls.Add(this.checkAutoPixel);
            this.groupPacking.Controls.Add(this.buttonSavePreset);
            this.groupPacking.Controls.Add(this.buttonLoadPreset);
            this.groupPacking.Controls.Add(this.buttonDefaultPreset);
            this.groupPacking.Controls.Add(this.numericRowStrideBit);
            this.groupPacking.Controls.Add(this.numericNextStrideBit);
            this.groupPacking.Controls.Add(this.numericPixelStrideBit);
            this.groupPacking.Controls.Add(this.numericRowStrideByte);
            this.groupPacking.Controls.Add(this.numericNextStrideByte);
            this.groupPacking.Controls.Add(this.numericPixelStrideByte);
            this.groupPacking.Controls.Add(this.numericWidth);
            this.groupPacking.Controls.Add(this.numericHeight);
            this.groupPacking.Controls.Add(this.labelHeight);
            this.groupPacking.Controls.Add(this.labelWidth);
            this.groupPacking.Controls.Add(this.labelBPP);
            this.groupPacking.Controls.Add(this.numericBPP);
            this.groupPacking.Controls.Add(this.checkChunky);
            this.groupPacking.Controls.Add(this.checkEndian);
            this.groupPacking.Controls.Add(this.dataGridPixel);
            this.groupPacking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPacking.Location = new System.Drawing.Point(172, 3);
            this.groupPacking.Name = "groupPacking";
            this.groupPacking.Size = new System.Drawing.Size(332, 227);
            this.groupPacking.TabIndex = 1;
            this.groupPacking.TabStop = false;
            this.groupPacking.Text = "Packing";
            // 
            // buttonPixel
            // 
            this.buttonPixel.Location = new System.Drawing.Point(6, 89);
            this.buttonPixel.Name = "buttonPixel";
            this.buttonPixel.Size = new System.Drawing.Size(53, 24);
            this.buttonPixel.TabIndex = 5;
            this.buttonPixel.Text = "Pi&xel";
            this.toolTip.SetToolTip(this.buttonPixel, "Left click to advance pixel\r\nRight/shift click to retreat");
            this.buttonPixel.UseVisualStyleBackColor = true;
            this.buttonPixel.Click += new System.EventHandler(this.buttonPixel_Click);
            this.buttonPixel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPixel_MouseDown);
            // 
            // buttonRow
            // 
            this.buttonRow.Location = new System.Drawing.Point(64, 89);
            this.buttonRow.Name = "buttonRow";
            this.buttonRow.Size = new System.Drawing.Size(53, 24);
            this.buttonRow.TabIndex = 6;
            this.buttonRow.Text = "&Row";
            this.toolTip.SetToolTip(this.buttonRow, "Left click to advance row\r\nRight/shift click to retreat");
            this.buttonRow.UseVisualStyleBackColor = true;
            this.buttonRow.Click += new System.EventHandler(this.buttonRow_Click);
            this.buttonRow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRow_MouseDown);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(121, 89);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(53, 24);
            this.buttonNext.TabIndex = 7;
            this.buttonNext.Text = "&Next";
            this.toolTip.SetToolTip(this.buttonNext, "Left click to advance next image\r\nRight/shift click to retreat");
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            this.buttonNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonNext_MouseDown);
            // 
            // checkAutoNext
            // 
            this.checkAutoNext.AutoSize = true;
            this.checkAutoNext.Checked = true;
            this.checkAutoNext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoNext.Location = new System.Drawing.Point(122, 168);
            this.checkAutoNext.Name = "checkAutoNext";
            this.checkAutoNext.Size = new System.Drawing.Size(48, 17);
            this.checkAutoNext.TabIndex = 16;
            this.checkAutoNext.Text = "Auto";
            this.checkAutoNext.UseVisualStyleBackColor = true;
            this.checkAutoNext.CheckedChanged += new System.EventHandler(this.checkAutoNext_CheckedChanged);
            // 
            // checkAutoRow
            // 
            this.checkAutoRow.AutoSize = true;
            this.checkAutoRow.Checked = true;
            this.checkAutoRow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoRow.Location = new System.Drawing.Point(65, 168);
            this.checkAutoRow.Name = "checkAutoRow";
            this.checkAutoRow.Size = new System.Drawing.Size(48, 17);
            this.checkAutoRow.TabIndex = 15;
            this.checkAutoRow.Text = "Auto";
            this.checkAutoRow.UseVisualStyleBackColor = true;
            this.checkAutoRow.CheckedChanged += new System.EventHandler(this.checkAutoRow_CheckedChanged);
            // 
            // checkAutoPixel
            // 
            this.checkAutoPixel.AutoSize = true;
            this.checkAutoPixel.Checked = true;
            this.checkAutoPixel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoPixel.Location = new System.Drawing.Point(9, 168);
            this.checkAutoPixel.Name = "checkAutoPixel";
            this.checkAutoPixel.Size = new System.Drawing.Size(48, 17);
            this.checkAutoPixel.TabIndex = 14;
            this.checkAutoPixel.Text = "Auto";
            this.checkAutoPixel.UseVisualStyleBackColor = true;
            this.checkAutoPixel.CheckedChanged += new System.EventHandler(this.checkAutoPixel_CheckedChanged);
            // 
            // buttonSavePreset
            // 
            this.buttonSavePreset.Location = new System.Drawing.Point(122, 191);
            this.buttonSavePreset.Name = "buttonSavePreset";
            this.buttonSavePreset.Size = new System.Drawing.Size(51, 24);
            this.buttonSavePreset.TabIndex = 19;
            this.buttonSavePreset.Text = "Save...";
            this.buttonSavePreset.UseVisualStyleBackColor = true;
            this.buttonSavePreset.Click += new System.EventHandler(this.buttonSavePreset_Click);
            // 
            // buttonLoadPreset
            // 
            this.buttonLoadPreset.Location = new System.Drawing.Point(65, 191);
            this.buttonLoadPreset.Name = "buttonLoadPreset";
            this.buttonLoadPreset.Size = new System.Drawing.Size(51, 24);
            this.buttonLoadPreset.TabIndex = 18;
            this.buttonLoadPreset.Text = "Load...";
            this.buttonLoadPreset.UseVisualStyleBackColor = true;
            this.buttonLoadPreset.Click += new System.EventHandler(this.buttonLoadPreset_Click);
            // 
            // buttonDefaultPreset
            // 
            this.buttonDefaultPreset.Location = new System.Drawing.Point(7, 191);
            this.buttonDefaultPreset.Name = "buttonDefaultPreset";
            this.buttonDefaultPreset.Size = new System.Drawing.Size(51, 24);
            this.buttonDefaultPreset.TabIndex = 17;
            this.buttonDefaultPreset.Text = "Default";
            this.buttonDefaultPreset.UseVisualStyleBackColor = true;
            this.buttonDefaultPreset.Click += new System.EventHandler(this.buttonDefaultPreset_Click);
            // 
            // numericRowStrideBit
            // 
            this.numericRowStrideBit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.numericRowStrideBit.Location = new System.Drawing.Point(65, 142);
            this.numericRowStrideBit.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericRowStrideBit.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericRowStrideBit.Name = "numericRowStrideBit";
            this.numericRowStrideBit.Size = new System.Drawing.Size(51, 20);
            this.numericRowStrideBit.TabIndex = 12;
            this.numericRowStrideBit.ValueChanged += new System.EventHandler(this.numericRowStrideBit_ValueChanged);
            // 
            // numericNextStrideBit
            // 
            this.numericNextStrideBit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.numericNextStrideBit.Location = new System.Drawing.Point(122, 142);
            this.numericNextStrideBit.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericNextStrideBit.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericNextStrideBit.Name = "numericNextStrideBit";
            this.numericNextStrideBit.Size = new System.Drawing.Size(51, 20);
            this.numericNextStrideBit.TabIndex = 13;
            this.numericNextStrideBit.ValueChanged += new System.EventHandler(this.numericNextStrideBit_ValueChanged);
            // 
            // numericPixelStrideBit
            // 
            this.numericPixelStrideBit.BackColor = System.Drawing.SystemColors.Window;
            this.numericPixelStrideBit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.numericPixelStrideBit.Location = new System.Drawing.Point(7, 142);
            this.numericPixelStrideBit.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericPixelStrideBit.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericPixelStrideBit.Name = "numericPixelStrideBit";
            this.numericPixelStrideBit.Size = new System.Drawing.Size(51, 20);
            this.numericPixelStrideBit.TabIndex = 11;
            this.numericPixelStrideBit.ValueChanged += new System.EventHandler(this.numericPixelStrideBit_ValueChanged);
            // 
            // numericRowStrideByte
            // 
            this.numericRowStrideByte.Location = new System.Drawing.Point(65, 116);
            this.numericRowStrideByte.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericRowStrideByte.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericRowStrideByte.Name = "numericRowStrideByte";
            this.numericRowStrideByte.Size = new System.Drawing.Size(51, 20);
            this.numericRowStrideByte.TabIndex = 9;
            this.numericRowStrideByte.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericRowStrideByte.ValueChanged += new System.EventHandler(this.numericRowStrideByte_ValueChanged);
            // 
            // numericNextStrideByte
            // 
            this.numericNextStrideByte.Location = new System.Drawing.Point(122, 116);
            this.numericNextStrideByte.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericNextStrideByte.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericNextStrideByte.Name = "numericNextStrideByte";
            this.numericNextStrideByte.Size = new System.Drawing.Size(51, 20);
            this.numericNextStrideByte.TabIndex = 10;
            this.numericNextStrideByte.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericNextStrideByte.ValueChanged += new System.EventHandler(this.numericNextStrideByte_ValueChanged);
            // 
            // numericPixelStrideByte
            // 
            this.numericPixelStrideByte.Location = new System.Drawing.Point(7, 116);
            this.numericPixelStrideByte.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericPixelStrideByte.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericPixelStrideByte.Name = "numericPixelStrideByte";
            this.numericPixelStrideByte.Size = new System.Drawing.Size(51, 20);
            this.numericPixelStrideByte.TabIndex = 8;
            this.numericPixelStrideByte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPixelStrideByte.ValueChanged += new System.EventHandler(this.numericPixelStrideByte_ValueChanged);
            // 
            // numericWidth
            // 
            this.numericWidth.Location = new System.Drawing.Point(65, 66);
            this.numericWidth.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(51, 20);
            this.numericWidth.TabIndex = 3;
            this.numericWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericWidth.ValueChanged += new System.EventHandler(this.numericWidth_ValueChanged);
            // 
            // numericHeight
            // 
            this.numericHeight.Location = new System.Drawing.Point(122, 66);
            this.numericHeight.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(51, 20);
            this.numericHeight.TabIndex = 4;
            this.numericHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeight.ValueChanged += new System.EventHandler(this.numericHeight_ValueChanged);
            // 
            // labelHeight
            // 
            this.labelHeight.Location = new System.Drawing.Point(122, 39);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(51, 24);
            this.labelHeight.TabIndex = 20;
            this.labelHeight.Text = "Height";
            this.labelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWidth
            // 
            this.labelWidth.Location = new System.Drawing.Point(65, 39);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(51, 24);
            this.labelWidth.TabIndex = 21;
            this.labelWidth.Text = "Width";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBPP
            // 
            this.labelBPP.Location = new System.Drawing.Point(6, 39);
            this.labelBPP.Name = "labelBPP";
            this.labelBPP.Size = new System.Drawing.Size(51, 24);
            this.labelBPP.TabIndex = 22;
            this.labelBPP.Text = "BPP";
            this.labelBPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericBPP
            // 
            this.numericBPP.Location = new System.Drawing.Point(7, 66);
            this.numericBPP.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericBPP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBPP.Name = "numericBPP";
            this.numericBPP.Size = new System.Drawing.Size(51, 20);
            this.numericBPP.TabIndex = 2;
            this.numericBPP.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericBPP.ValueChanged += new System.EventHandler(this.numericBPP_ValueChanged);
            // 
            // checkChunky
            // 
            this.checkChunky.AutoSize = true;
            this.checkChunky.Checked = true;
            this.checkChunky.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkChunky.Location = new System.Drawing.Point(98, 19);
            this.checkChunky.Name = "checkChunky";
            this.checkChunky.Size = new System.Drawing.Size(62, 17);
            this.checkChunky.TabIndex = 1;
            this.checkChunky.Text = "Chunky";
            this.checkChunky.UseVisualStyleBackColor = true;
            this.checkChunky.CheckedChanged += new System.EventHandler(this.checkChunky_CheckedChanged);
            // 
            // checkEndian
            // 
            this.checkEndian.AutoSize = true;
            this.checkEndian.Location = new System.Drawing.Point(7, 19);
            this.checkEndian.Name = "checkEndian";
            this.checkEndian.Size = new System.Drawing.Size(90, 17);
            this.checkEndian.TabIndex = 0;
            this.checkEndian.Text = "Reverse Byte";
            this.checkEndian.UseVisualStyleBackColor = true;
            this.checkEndian.CheckedChanged += new System.EventHandler(this.checkEndian_CheckedChanged);
            // 
            // dataGridPixel
            // 
            this.dataGridPixel.AllowUserToAddRows = false;
            this.dataGridPixel.AllowUserToDeleteRows = false;
            this.dataGridPixel.AllowUserToResizeColumns = false;
            this.dataGridPixel.AllowUserToResizeRows = false;
            this.dataGridPixel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPixel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order,
            this.offByte,
            this.offBit});
            this.dataGridPixel.Enabled = false;
            this.dataGridPixel.Location = new System.Drawing.Point(179, 19);
            this.dataGridPixel.MultiSelect = false;
            this.dataGridPixel.Name = "dataGridPixel";
            this.dataGridPixel.RowHeadersVisible = false;
            this.dataGridPixel.Size = new System.Drawing.Size(147, 196);
            this.dataGridPixel.TabIndex = 20;
            this.dataGridPixel.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridPixel_CellValidating);
            this.dataGridPixel.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPixel_CellValueChanged);
            // 
            // order
            // 
            this.order.HeaderText = "Order";
            this.order.Name = "order";
            this.order.ReadOnly = true;
            this.order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.order.Width = 42;
            // 
            // offByte
            // 
            this.offByte.HeaderText = "Byte";
            this.offByte.Name = "offByte";
            this.offByte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.offByte.Width = 42;
            // 
            // offBit
            // 
            this.offBit.HeaderText = "Bit";
            this.offBit.Name = "offBit";
            this.offBit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.offBit.Width = 42;
            // 
            // groupPalette
            // 
            this.groupPalette.AutoSize = true;
            this.groupPalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupPalette.Controls.Add(this.buttonGrey);
            this.groupPalette.Controls.Add(this.labelInfoPal);
            this.groupPalette.Controls.Add(this.buttonSavePal);
            this.groupPalette.Controls.Add(this.buttonLoadPal);
            this.groupPalette.Controls.Add(this.buttonRGBPal);
            this.groupPalette.Controls.Add(this.buttonRandomPal);
            this.groupPalette.Controls.Add(this.bgLabel);
            this.groupPalette.Controls.Add(this.bgBox);
            this.groupPalette.Controls.Add(this.paletteBox);
            this.groupPalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPalette.Location = new System.Drawing.Point(510, 3);
            this.groupPalette.Name = "groupPalette";
            this.groupPalette.Size = new System.Drawing.Size(284, 227);
            this.groupPalette.TabIndex = 2;
            this.groupPalette.TabStop = false;
            this.groupPalette.Text = "Palette";
            // 
            // buttonGrey
            // 
            this.buttonGrey.Location = new System.Drawing.Point(238, 57);
            this.buttonGrey.Name = "buttonGrey";
            this.buttonGrey.Size = new System.Drawing.Size(39, 24);
            this.buttonGrey.TabIndex = 2;
            this.buttonGrey.Text = "Grey";
            this.buttonGrey.UseVisualStyleBackColor = true;
            this.buttonGrey.Click += new System.EventHandler(this.buttonGrey_Click);
            // 
            // labelInfoPal
            // 
            this.labelInfoPal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelInfoPal.Location = new System.Drawing.Point(6, 152);
            this.labelInfoPal.Name = "labelInfoPal";
            this.labelInfoPal.Size = new System.Drawing.Size(271, 43);
            this.labelInfoPal.TabIndex = 3;
            this.labelInfoPal.Text = "(Palette Info)";
            this.labelInfoPal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSavePal
            // 
            this.buttonSavePal.Location = new System.Drawing.Point(213, 87);
            this.buttonSavePal.Name = "buttonSavePal";
            this.buttonSavePal.Size = new System.Drawing.Size(64, 24);
            this.buttonSavePal.TabIndex = 4;
            this.buttonSavePal.Text = "Save...";
            this.buttonSavePal.UseVisualStyleBackColor = true;
            this.buttonSavePal.Click += new System.EventHandler(this.buttonSavePal_Click);
            // 
            // buttonLoadPal
            // 
            this.buttonLoadPal.Location = new System.Drawing.Point(143, 87);
            this.buttonLoadPal.Name = "buttonLoadPal";
            this.buttonLoadPal.Size = new System.Drawing.Size(64, 24);
            this.buttonLoadPal.TabIndex = 3;
            this.buttonLoadPal.Text = "Load...";
            this.buttonLoadPal.UseVisualStyleBackColor = true;
            this.buttonLoadPal.Click += new System.EventHandler(this.buttonLoadPal_Click);
            // 
            // buttonRGBPal
            // 
            this.buttonRGBPal.Location = new System.Drawing.Point(192, 57);
            this.buttonRGBPal.Name = "buttonRGBPal";
            this.buttonRGBPal.Size = new System.Drawing.Size(40, 24);
            this.buttonRGBPal.TabIndex = 1;
            this.buttonRGBPal.Text = "RGB";
            this.buttonRGBPal.UseVisualStyleBackColor = true;
            this.buttonRGBPal.Click += new System.EventHandler(this.buttonRGBPal_Click);
            // 
            // buttonRandomPal
            // 
            this.buttonRandomPal.Location = new System.Drawing.Point(143, 57);
            this.buttonRandomPal.Name = "buttonRandomPal";
            this.buttonRandomPal.Size = new System.Drawing.Size(43, 24);
            this.buttonRandomPal.TabIndex = 0;
            this.buttonRandomPal.Text = "Rand";
            this.buttonRandomPal.UseVisualStyleBackColor = true;
            this.buttonRandomPal.Click += new System.EventHandler(this.buttonRandomPal_Click);
            // 
            // bgLabel
            // 
            this.bgLabel.Location = new System.Drawing.Point(181, 19);
            this.bgLabel.Name = "bgLabel";
            this.bgLabel.Size = new System.Drawing.Size(96, 32);
            this.bgLabel.TabIndex = 2;
            this.bgLabel.Text = "Background";
            this.bgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bgBox
            // 
            this.bgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bgBox.Location = new System.Drawing.Point(143, 19);
            this.bgBox.Name = "bgBox";
            this.bgBox.Size = new System.Drawing.Size(32, 32);
            this.bgBox.TabIndex = 5;
            this.bgBox.TabStop = false;
            this.bgBox.Click += new System.EventHandler(this.bgBox_Click);
            // 
            // paletteBox
            // 
            this.paletteBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paletteBox.Location = new System.Drawing.Point(6, 19);
            this.paletteBox.Name = "paletteBox";
            this.paletteBox.Size = new System.Drawing.Size(130, 130);
            this.paletteBox.TabIndex = 6;
            this.paletteBox.TabStop = false;
            this.paletteBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.paletteBox_MouseClick);
            this.paletteBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paletteBox_MouseMove);
            // 
            // tablePosPlane
            // 
            this.tablePosPlane.AutoSize = true;
            this.tablePosPlane.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablePosPlane.ColumnCount = 1;
            this.tablePosPlane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePosPlane.Controls.Add(this.groupPosition, 0, 0);
            this.tablePosPlane.Controls.Add(this.groupTile, 0, 1);
            this.tablePosPlane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePosPlane.Location = new System.Drawing.Point(0, 0);
            this.tablePosPlane.Margin = new System.Windows.Forms.Padding(0);
            this.tablePosPlane.Name = "tablePosPlane";
            this.tablePosPlane.RowCount = 2;
            this.tablePosPlane.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePosPlane.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePosPlane.Size = new System.Drawing.Size(169, 233);
            this.tablePosPlane.TabIndex = 0;
            // 
            // groupPosition
            // 
            this.groupPosition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupPosition.Controls.Add(this.buttonZero);
            this.groupPosition.Controls.Add(this.buttonBitPos);
            this.groupPosition.Controls.Add(this.buttonZoom);
            this.groupPosition.Controls.Add(this.buttonBytePos);
            this.groupPosition.Controls.Add(this.numericZoom);
            this.groupPosition.Controls.Add(this.labelInfoPixel);
            this.groupPosition.Controls.Add(this.numericPosBit);
            this.groupPosition.Controls.Add(this.numericPosByte);
            this.groupPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPosition.Location = new System.Drawing.Point(3, 3);
            this.groupPosition.Name = "groupPosition";
            this.groupPosition.Size = new System.Drawing.Size(163, 105);
            this.groupPosition.TabIndex = 0;
            this.groupPosition.TabStop = false;
            this.groupPosition.Text = "Position";
            // 
            // buttonZero
            // 
            this.buttonZero.Location = new System.Drawing.Point(6, 67);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(36, 34);
            this.buttonZero.TabIndex = 6;
            this.buttonZero.Text = "&0";
            this.toolTip.SetToolTip(this.buttonZero, "Return position to 0");
            this.buttonZero.UseVisualStyleBackColor = true;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // buttonBitPos
            // 
            this.buttonBitPos.Location = new System.Drawing.Point(6, 42);
            this.buttonBitPos.Name = "buttonBitPos";
            this.buttonBitPos.Size = new System.Drawing.Size(36, 22);
            this.buttonBitPos.TabIndex = 2;
            this.buttonBitPos.Text = "B&it";
            this.toolTip.SetToolTip(this.buttonBitPos, "Left click to advance bit\r\nRight/shift click to retreat");
            this.buttonBitPos.UseVisualStyleBackColor = true;
            this.buttonBitPos.Click += new System.EventHandler(this.buttonBitPos_Click);
            this.buttonBitPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBitPos_MouseDown);
            // 
            // buttonZoom
            // 
            this.buttonZoom.Location = new System.Drawing.Point(114, 18);
            this.buttonZoom.Name = "buttonZoom";
            this.buttonZoom.Size = new System.Drawing.Size(44, 22);
            this.buttonZoom.TabIndex = 4;
            this.buttonZoom.Text = "&Zoom";
            this.toolTip.SetToolTip(this.buttonZoom, "Left click to increse zoom\r\nRight/shift click to decrease");
            this.buttonZoom.UseVisualStyleBackColor = true;
            this.buttonZoom.Click += new System.EventHandler(this.buttonZoom_Click);
            this.buttonZoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoom_MouseDown);
            // 
            // buttonBytePos
            // 
            this.buttonBytePos.Location = new System.Drawing.Point(6, 18);
            this.buttonBytePos.Name = "buttonBytePos";
            this.buttonBytePos.Size = new System.Drawing.Size(36, 22);
            this.buttonBytePos.TabIndex = 0;
            this.buttonBytePos.Text = "&Byte";
            this.toolTip.SetToolTip(this.buttonBytePos, "Left click to advance byte\r\nRight/shift click to retreat");
            this.buttonBytePos.UseVisualStyleBackColor = true;
            this.buttonBytePos.Click += new System.EventHandler(this.buttonBytePos_Click);
            this.buttonBytePos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBytePos_MouseDown);
            // 
            // numericZoom
            // 
            this.numericZoom.Location = new System.Drawing.Point(115, 43);
            this.numericZoom.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericZoom.Name = "numericZoom";
            this.numericZoom.Size = new System.Drawing.Size(42, 20);
            this.numericZoom.TabIndex = 5;
            this.numericZoom.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericZoom.ValueChanged += new System.EventHandler(this.numericZoom_ValueChanged);
            // 
            // labelInfoPixel
            // 
            this.labelInfoPixel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelInfoPixel.Location = new System.Drawing.Point(42, 68);
            this.labelInfoPixel.Name = "labelInfoPixel";
            this.labelInfoPixel.Size = new System.Drawing.Size(115, 32);
            this.labelInfoPixel.TabIndex = 7;
            this.labelInfoPixel.Text = "(Pixel Info)";
            this.labelInfoPixel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericPosBit
            // 
            this.numericPosBit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.numericPosBit.Location = new System.Drawing.Point(42, 43);
            this.numericPosBit.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericPosBit.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.numericPosBit.Name = "numericPosBit";
            this.numericPosBit.Size = new System.Drawing.Size(70, 20);
            this.numericPosBit.TabIndex = 3;
            this.numericPosBit.ValueChanged += new System.EventHandler(this.numericPosBit_ValueChanged);
            // 
            // numericPosByte
            // 
            this.numericPosByte.Hexadecimal = true;
            this.numericPosByte.Location = new System.Drawing.Point(42, 19);
            this.numericPosByte.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericPosByte.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericPosByte.Name = "numericPosByte";
            this.numericPosByte.Size = new System.Drawing.Size(70, 20);
            this.numericPosByte.TabIndex = 1;
            this.numericPosByte.ValueChanged += new System.EventHandler(this.numericPosByte_ValueChanged);
            // 
            // groupTile
            // 
            this.groupTile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupTile.Controls.Add(this.labelTileStride);
            this.groupTile.Controls.Add(this.labelTileSize);
            this.groupTile.Controls.Add(this.labelTileY);
            this.groupTile.Controls.Add(this.numericTileSizeY);
            this.groupTile.Controls.Add(this.numericTileStrideBitY);
            this.groupTile.Controls.Add(this.numericTileStrideByteY);
            this.groupTile.Controls.Add(this.labelTileX);
            this.groupTile.Controls.Add(this.numericTileSizeX);
            this.groupTile.Controls.Add(this.numericTileStrideBitX);
            this.groupTile.Controls.Add(this.numericTileStrideByteX);
            this.groupTile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTile.Location = new System.Drawing.Point(3, 114);
            this.groupTile.Name = "groupTile";
            this.groupTile.Size = new System.Drawing.Size(163, 116);
            this.groupTile.TabIndex = 1;
            this.groupTile.TabStop = false;
            this.groupTile.Text = "Tiling";
            // 
            // labelTileStride
            // 
            this.labelTileStride.Location = new System.Drawing.Point(3, 57);
            this.labelTileStride.Name = "labelTileStride";
            this.labelTileStride.Size = new System.Drawing.Size(45, 43);
            this.labelTileStride.TabIndex = 27;
            this.labelTileStride.Text = "Stride";
            this.labelTileStride.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTileSize
            // 
            this.labelTileSize.Location = new System.Drawing.Point(3, 34);
            this.labelTileSize.Name = "labelTileSize";
            this.labelTileSize.Size = new System.Drawing.Size(45, 20);
            this.labelTileSize.TabIndex = 26;
            this.labelTileSize.Text = "Size";
            this.labelTileSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTileY
            // 
            this.labelTileY.Location = new System.Drawing.Point(106, 16);
            this.labelTileY.Name = "labelTileY";
            this.labelTileY.Size = new System.Drawing.Size(51, 15);
            this.labelTileY.TabIndex = 25;
            this.labelTileY.Text = "Y";
            this.labelTileY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericTileSizeY
            // 
            this.numericTileSizeY.Location = new System.Drawing.Point(106, 34);
            this.numericTileSizeY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericTileSizeY.Name = "numericTileSizeY";
            this.numericTileSizeY.Size = new System.Drawing.Size(51, 20);
            this.numericTileSizeY.TabIndex = 1;
            this.numericTileSizeY.ValueChanged += new System.EventHandler(this.numericTileSizeY_ValueChanged);
            // 
            // numericTileStrideBitY
            // 
            this.numericTileStrideBitY.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.numericTileStrideBitY.Location = new System.Drawing.Point(106, 80);
            this.numericTileStrideBitY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericTileStrideBitY.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericTileStrideBitY.Name = "numericTileStrideBitY";
            this.numericTileStrideBitY.Size = new System.Drawing.Size(51, 20);
            this.numericTileStrideBitY.TabIndex = 5;
            this.numericTileStrideBitY.ValueChanged += new System.EventHandler(this.numericTileStrideBitY_ValueChanged);
            // 
            // numericTileStrideByteY
            // 
            this.numericTileStrideByteY.Location = new System.Drawing.Point(106, 57);
            this.numericTileStrideByteY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericTileStrideByteY.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericTileStrideByteY.Name = "numericTileStrideByteY";
            this.numericTileStrideByteY.Size = new System.Drawing.Size(51, 20);
            this.numericTileStrideByteY.TabIndex = 3;
            this.numericTileStrideByteY.ValueChanged += new System.EventHandler(this.numericTileStrideByteY_ValueChanged);
            // 
            // labelTileX
            // 
            this.labelTileX.Location = new System.Drawing.Point(49, 16);
            this.labelTileX.Name = "labelTileX";
            this.labelTileX.Size = new System.Drawing.Size(51, 15);
            this.labelTileX.TabIndex = 21;
            this.labelTileX.Text = "X";
            this.labelTileX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericTileSizeX
            // 
            this.numericTileSizeX.Location = new System.Drawing.Point(49, 34);
            this.numericTileSizeX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericTileSizeX.Name = "numericTileSizeX";
            this.numericTileSizeX.Size = new System.Drawing.Size(51, 20);
            this.numericTileSizeX.TabIndex = 0;
            this.numericTileSizeX.ValueChanged += new System.EventHandler(this.numericTileSizeX_ValueChanged);
            // 
            // numericTileStrideBitX
            // 
            this.numericTileStrideBitX.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.numericTileStrideBitX.Location = new System.Drawing.Point(49, 80);
            this.numericTileStrideBitX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericTileStrideBitX.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericTileStrideBitX.Name = "numericTileStrideBitX";
            this.numericTileStrideBitX.Size = new System.Drawing.Size(51, 20);
            this.numericTileStrideBitX.TabIndex = 4;
            this.numericTileStrideBitX.ValueChanged += new System.EventHandler(this.numericTileStrideBitX_ValueChanged);
            // 
            // numericTileStrideByteX
            // 
            this.numericTileStrideByteX.Location = new System.Drawing.Point(49, 57);
            this.numericTileStrideByteX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericTileStrideByteX.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericTileStrideByteX.Name = "numericTileStrideByteX";
            this.numericTileStrideByteX.Size = new System.Drawing.Size(51, 20);
            this.numericTileStrideByteX.TabIndex = 2;
            this.numericTileStrideByteX.ValueChanged += new System.EventHandler(this.numericTileStrideByteX_ValueChanged);
            // 
            // tableBase
            // 
            this.tableBase.AutoSize = true;
            this.tableBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableBase.ColumnCount = 1;
            this.tableBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.Controls.Add(this.tableTop, 0, 0);
            this.tableBase.Controls.Add(this.tableBottom, 0, 1);
            this.tableBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBase.Location = new System.Drawing.Point(0, 24);
            this.tableBase.Margin = new System.Windows.Forms.Padding(0);
            this.tableBase.Name = "tableBase";
            this.tableBase.RowCount = 2;
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.Size = new System.Drawing.Size(797, 647);
            this.tableBase.TabIndex = 1;
            // 
            // tableBottom
            // 
            this.tableBottom.ColumnCount = 2;
            this.tableBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableBottom.Controls.Add(this.pixelBox, 0, 0);
            this.tableBottom.Controls.Add(this.pixelScroll, 1, 0);
            this.tableBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBottom.Location = new System.Drawing.Point(0, 233);
            this.tableBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tableBottom.Name = "tableBottom";
            this.tableBottom.RowCount = 1;
            this.tableBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBottom.Size = new System.Drawing.Size(797, 414);
            this.tableBottom.TabIndex = 1;
            // 
            // pixelBox
            // 
            this.pixelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pixelBox.ContextMenuStrip = this.contextMenuPixel;
            this.pixelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelBox.Location = new System.Drawing.Point(3, 3);
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.Size = new System.Drawing.Size(767, 408);
            this.pixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pixelBox.TabIndex = 0;
            this.pixelBox.TabStop = false;
            this.pixelBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pixelBox_MouseMove);
            this.pixelBox.Resize += new System.EventHandler(this.pixelBox_Resize);
            // 
            // contextMenuPixel
            // 
            this.contextMenuPixel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.positionToPixelToolStripMenuItem});
            this.contextMenuPixel.Name = "contextMenuPixel";
            this.contextMenuPixel.Size = new System.Drawing.Size(160, 70);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Enabled = false;
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveImageToolStripMenuItem.Text = "&Save &Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageContextItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveAllToolStripMenuItem.Text = "Save &All Visible";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllVisibleContextItem_Click);
            // 
            // positionToPixelToolStripMenuItem
            // 
            this.positionToPixelToolStripMenuItem.Name = "positionToPixelToolStripMenuItem";
            this.positionToPixelToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.positionToPixelToolStripMenuItem.Text = "&Position to Pixel";
            this.positionToPixelToolStripMenuItem.Click += new System.EventHandler(this.positionToPixelToolContextItem_Click);
            // 
            // pixelScroll
            // 
            this.pixelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelScroll.LargeChange = 1;
            this.pixelScroll.Location = new System.Drawing.Point(773, 0);
            this.pixelScroll.Maximum = 0;
            this.pixelScroll.Name = "pixelScroll";
            this.pixelScroll.Size = new System.Drawing.Size(24, 414);
            this.pixelScroll.TabIndex = 1;
            this.pixelScroll.TabStop = true;
            this.pixelScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pixelScroll_Scroll);
            // 
            // BinxelviewForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 671);
            this.Controls.Add(this.tableBase);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "BinxelviewForm";
            this.Text = "Binxelview";
            this.Load += new System.EventHandler(this.BinxelviewForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.BinxelviewForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.BinxelviewForm_DragEnter);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tableTop.ResumeLayout(false);
            this.tableTop.PerformLayout();
            this.groupPacking.ResumeLayout(false);
            this.groupPacking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRowStrideBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNextStrideBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPixelStrideBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRowStrideByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNextStrideByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPixelStrideByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPixel)).EndInit();
            this.groupPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteBox)).EndInit();
            this.tablePosPlane.ResumeLayout(false);
            this.groupPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPosBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPosByte)).EndInit();
            this.groupTile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericTileSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileStrideBitY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileStrideByteY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileStrideBitX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileStrideByteX)).EndInit();
            this.tableBase.ResumeLayout(false);
            this.tableBase.PerformLayout();
            this.tableBottom.ResumeLayout(false);
            this.tableBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.contextMenuPixel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableTop;
        private System.Windows.Forms.GroupBox groupPacking;
        private System.Windows.Forms.GroupBox groupPalette;
        private System.Windows.Forms.TableLayoutPanel tableBase;
        private System.Windows.Forms.TableLayoutPanel tableBottom;
        private System.Windows.Forms.PictureBox pixelBox;
        private System.Windows.Forms.VScrollBar pixelScroll;
        private System.Windows.Forms.PictureBox paletteBox;
        private System.Windows.Forms.Button buttonSavePal;
        private System.Windows.Forms.Button buttonLoadPal;
        private System.Windows.Forms.Button buttonRGBPal;
        private System.Windows.Forms.Button buttonRandomPal;
        private System.Windows.Forms.Label bgLabel;
        private System.Windows.Forms.PictureBox bgBox;
        private System.Windows.Forms.Label labelInfoPal;
        private System.Windows.Forms.Button buttonGrey;
        private System.Windows.Forms.GroupBox groupPosition;
        private System.Windows.Forms.DataGridView dataGridPixel;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelBPP;
        private System.Windows.Forms.NumericUpDown numericBPP;
        private System.Windows.Forms.CheckBox checkChunky;
        private System.Windows.Forms.CheckBox checkEndian;
        private System.Windows.Forms.NumericUpDown numericRowStrideBit;
        private System.Windows.Forms.NumericUpDown numericNextStrideBit;
        private System.Windows.Forms.NumericUpDown numericPixelStrideBit;
        private System.Windows.Forms.NumericUpDown numericRowStrideByte;
        private System.Windows.Forms.NumericUpDown numericNextStrideByte;
        private System.Windows.Forms.NumericUpDown numericPixelStrideByte;
        private System.Windows.Forms.Button buttonSavePreset;
        private System.Windows.Forms.Button buttonLoadPreset;
        private System.Windows.Forms.Button buttonDefaultPreset;
        private System.Windows.Forms.ToolStripMenuItem presetToolStripMenuItem;
        private System.Windows.Forms.Label labelInfoPixel;
        private System.Windows.Forms.NumericUpDown numericPosBit;
        private System.Windows.Forms.NumericUpDown numericPosByte;
        private System.Windows.Forms.NumericUpDown numericZoom;
        private System.Windows.Forms.ToolStripMenuItem reloadPresetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator presetStripMenuDash;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
        private System.Windows.Forms.DataGridViewTextBoxColumn offByte;
        private System.Windows.Forms.DataGridViewTextBoxColumn offBit;
        private System.Windows.Forms.ContextMenuStrip contextMenuPixel;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllVisibleToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkAutoNext;
        private System.Windows.Forms.CheckBox checkAutoRow;
        private System.Windows.Forms.CheckBox checkAutoPixel;
        private System.Windows.Forms.TableLayoutPanel tablePosPlane;
        private System.Windows.Forms.GroupBox groupTile;
        private System.Windows.Forms.Label labelTileY;
        private System.Windows.Forms.NumericUpDown numericTileSizeY;
        private System.Windows.Forms.NumericUpDown numericTileStrideBitY;
        private System.Windows.Forms.NumericUpDown numericTileStrideByteY;
        private System.Windows.Forms.Label labelTileX;
        private System.Windows.Forms.NumericUpDown numericTileSizeX;
        private System.Windows.Forms.NumericUpDown numericTileStrideBitX;
        private System.Windows.Forms.NumericUpDown numericTileStrideByteX;
        private System.Windows.Forms.Label labelTileStride;
        private System.Windows.Forms.Label labelTileSize;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decimalPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexadecimalPositionToolStripMenuItem;
        private System.Windows.Forms.Button buttonBytePos;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPixel;
        private System.Windows.Forms.Button buttonRow;
        private System.Windows.Forms.Button buttonBitPos;
        private System.Windows.Forms.Button buttonZoom;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.ToolStripSeparator optionsStripMenuDash1;
        private System.Windows.Forms.ToolStripMenuItem snapScrollToNextStrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator optionsStripMenuDash3;
        private System.Windows.Forms.ToolStripMenuItem verticalLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twiddleZToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator optionsStripMenuDash4;
        private System.Windows.Forms.ToolStripMenuItem twiddleNToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator optionsStripMenuDash2;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportBinaryChunkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem positionToPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadFileToolStripMenuItem;
    }
}

