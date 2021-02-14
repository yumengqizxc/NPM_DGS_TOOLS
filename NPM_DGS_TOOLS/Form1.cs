using NPM_DGS_TOOLS.MESDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NPM_DGS_TOOLS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mESDataSet.Licenses”中。您可以根据需要移动或删除它。
            this.licensesTableAdapter.Fill(this.mESDataSet.Licenses);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

            saveFileDialog1.FileName = "NPM_LiC.txt";
            saveFileDialog1.FilterIndex = 2;

            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                PrintTxt(dataGridView1, saveFileDialog1.FileName);
            }
        }
        private void PrintTxt(DataGridView dv, string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath, false, System.Text.Encoding.GetEncoding("GB2312"));
            string fs = " ";

            for (int i = 0; i < (dv.Rows.Count - 1); i++)
            {
                fs = "";
                for (int j = 0; j < dv.Columns.Count; j++)
                {
                    dv.CurrentCell = this.dataGridView1.Rows[i].Cells[j];
                    Clipboard.SetDataObject(dv.GetClipboardContent());
                    fs += Clipboard.GetText().ToString();
                    fs += " ";
                }
                sw.WriteLine(fs);
            }
            sw.Flush();
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserTableAdapter UserPW = new MESDataSetTableAdapters.UserTableAdapter();
             UserPW.UpdateAdminPW();
            MessageBox.Show("重置admin账号密码完成!","提示！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserTableAdapter UserPW = new MESDataSetTableAdapters.UserTableAdapter();
            UserPW.UpdatePfscPW();
            MessageBox.Show("重置Pfsc账号密码完成!", "提示！");
        }
    }
}
