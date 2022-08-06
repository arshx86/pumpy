#region

using System;
using System.IO;
using System.Windows.Forms;

#endregion

namespace Pumpy.GUI
{
    public partial class FormMain : Form
    {
        public enum SizeDefinition
        {
            BYTE = 1,
            KILOBYTE = 2,
            MEGABYTE = 3,
            GIGABYTE = 4
        }

        private static FileInfo file;

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opdd = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Everything |*.*",
                FilterIndex = 0,
                RestoreDirectory = true
            };

            if (opdd.ShowDialog() == DialogResult.OK)
            {
                file = new FileInfo(opdd.FileName);
                button1.Text = opdd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (file == null)
            {
                MessageBox.Show("No file selected.", "Wheres the file?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var size = numericUpDown1.Value;
            double val = 0;
            switch (unit.SelectedIndex)
            {
                case 0:
                    val = (double)size;
                    break;
                case 1:
                    val = ConvertAmount(decimal.ToInt32(size), SizeDefinition.GIGABYTE, SizeDefinition.MEGABYTE);
                    break;
            }

            button2.Text = $"Pumping {val} mb";
            Pumper.Pump(file.FullName, (int)val);
            MessageBox.Show("Pump success.", "PumpY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button2.Text = "Pump";
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            unit.SelectedIndex = 0;
        }

        public double ConvertAmount(int amount, SizeDefinition from, SizeDefinition to)
        {
            int difference = 0;

            if ((int)from > (int)to)
            {
                difference = (int)from - (int)to;
                return amount * (1024d * difference);
            }

            difference = (int)to - (int)from;
            return amount / (1024d * difference);
        }
    }
}