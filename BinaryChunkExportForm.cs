using System;
using System.IO;
using System.Windows.Forms;

namespace Binxelview
{
    public partial class BinaryChunkExportForm : Form
    {
        byte[] data;

        public BinaryChunkExportForm(int startPosition, bool hex, byte[] data)
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
                    int start = (int)startNumericUpDown.Value;
                    int length = (int)lengthNumericUpDown.Value;
                    if (start < 0) start = 0;
                    if ((start+length) > data.Length) length = data.Length-start;
                    if (length > 0)
                    {
                        binaryExportFile.Write(data, (int)startNumericUpDown.Value, (int)lengthNumericUpDown.Value);
                    }
                }
                Close();
            }
        }
    }
}
