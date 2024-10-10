using System;
using System.IO;
using System.Windows.Forms;

namespace Binxelview
{
    public partial class BinaryChunkExportForm : Form
    {
        byte[] data;

        public BinaryChunkExportForm(long startPosition, bool hex, byte[] data)
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
                long start = (long)startNumericUpDown.Value;
                long length = (long)lengthNumericUpDown.Value;
                if (start < 0) start = 0;
                if ((start+length) > data.Length) length = data.Length-start;
                if (start > 0x7FFFFFFF || length > 0x7FFFFFFF)
                {
                    MessageBox.Show("Start address and length must be less than 2,147,483,648. (2^31)", "32-bit range error!");
                }
                else
                {
                    using (Stream binaryExportFile = File.OpenWrite(saveBinaryFileDialog.FileName))
                    {
                        if (length > 0)
                        {
                            binaryExportFile.Write(data, (int)start, (int)length);
                        }
                    }
                }
                Close();
            }
        }
    }
}
