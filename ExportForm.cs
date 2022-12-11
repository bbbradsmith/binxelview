using System;
using System.IO;
using System.Windows.Forms;

namespace Binxelview
{
    public partial class ExportForm : Form
    {
        byte[] data;

        public ExportForm(int startPosition, bool hex, byte[] data)
        {
            InitializeComponent();

            this.data = data;
            startNumericUpDown.Value = startPosition;
            startNumericUpDown.Hexadecimal = hex;
            lengthNumericUpDown.Hexadecimal = hex;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveBinaryFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream binaryExportFile = File.OpenWrite(saveBinaryFileDialog.FileName))
                {
                    binaryExportFile.Write(data, (int)startNumericUpDown.Value, (int)lengthNumericUpDown.Value);
                }
                Close();
            }
        }
    }
}
