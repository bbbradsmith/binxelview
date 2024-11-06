using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Binxelview.Dialogs
{
    public partial class ViewForm : Form
    {
        BinxelviewForm binxelview_form;

        public ViewForm(BinxelviewForm parent_form, ContextMenuStrip context_strip)
        {
            binxelview_form = parent_form;
            InitializeComponent();
            pixelBox.ContextMenuStrip = context_strip;
        }

        private void pixelBox_MouseMove(object sender, MouseEventArgs e)
        {
            binxelview_form.pixelBox_MouseMove(sender, e);
        }

        private void pixelBox_Resize(object sender, EventArgs e)
        {
            binxelview_form.pixelBox_Resize(sender, e);
        }

        private void ViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // cancel the close, let the parent hide this window instead
            e.Cancel = true;
            binxelview_form.splitviewClose();
        }

        public PictureBox getPixelBox()
        {
            return pixelBox;
        }

        public VScrollBar getPixelScroll()
        {
            return pixelScroll;
        }

        private void pixelScroll_Scroll(object sender, ScrollEventArgs e)
        {
            binxelview_form.pixelScroll_Scroll(sender, e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (binxelview_form.handleHotkeys(ref msg,keyData)) return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ViewForm_DragDrop(object sender, DragEventArgs e)
        {
            binxelview_form.BinxelviewForm_DragDrop(sender, e);
        }

        private void ViewForm_DragEnter(object sender, DragEventArgs e)
        {
            binxelview_form.BinxelviewForm_DragEnter(sender, e);
        }
    }
}
