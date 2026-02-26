using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        void GridAyarla(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false; 
            dgv.ColumnHeadersVisible = false; 

            
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            
            dgv.ReadOnly = true;

           
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.AllowUserToAddRows = false; 
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            GridAyarla(dataGridView1);
            GridAyarla(dataGridView2);
            GridAyarla(dataGridView3);
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            groupBox2.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int aSatir = (int)numericUpDown5.Value;
            int aSutun = (int)numericUpDown3.Value;
            int bSatir = (int)numericUpDown2.Value;
            int bSutun = (int)numericUpDown4.Value;

            RastgeleMatrisOlustur(dataGridView1, aSatir, aSutun);
            RastgeleMatrisOlustur(dataGridView2, bSatir, bSutun);

            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            groupBox2.Visible = true;
            button1.Visible = true;
        }
        void RastgeleMatrisOlustur(DataGridView dgv, int satir, int sutun)
        {
            Random rnd = new Random();
            dgv.RowCount = satir;
            dgv.ColumnCount = sutun;

            for (int i = 0; i < satir; i++)
                for (int j = 0; j < sutun; j++)
                    dgv.Rows[i].Cells[j].Value = rnd.Next(1, 101);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                MatrisTopla();
            else if (radioButton1.Checked)
                MatrisCikar();
            else if (radioButton3.Checked)
                MatrisCarp();
            else if (radioButton4.Checked)
                MatrisTranspoz(dataGridView1);
            else if (radioButton5.Checked)
                MatrisTranspoz(dataGridView2);

            dataGridView3.Visible = true;
            label1.Visible = true;
        }
        void MatrisTopla()
        {
            int satir = dataGridView1.RowCount;
            int sutun = dataGridView1.ColumnCount;

            dataGridView3.RowCount = satir;
            dataGridView3.ColumnCount = sutun;

            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    int a = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    int b = Convert.ToInt32(dataGridView2.Rows[i].Cells[j].Value);
                    dataGridView3.Rows[i].Cells[j].Value = a + b;
                }
            }
        }
        void MatrisCikar()
        {
            int satir = dataGridView1.RowCount;
            int sutun = dataGridView1.ColumnCount;

            dataGridView3.RowCount = satir;
            dataGridView3.ColumnCount = sutun;

            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    int a = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    int b = Convert.ToInt32(dataGridView2.Rows[i].Cells[j].Value);
                    dataGridView3.Rows[i].Cells[j].Value = a - b;
                }
            }
        }
        void MatrisCarp()
        {
            int aSatir = dataGridView1.RowCount;
            int aSutun = dataGridView1.ColumnCount;
            int bSatir = dataGridView2.RowCount;
            int bSutun = dataGridView2.ColumnCount;

           
            if (aSutun != bSatir)
            {
                MessageBox.Show("Çarpma işlemi için A'nın sütun sayısı, B'nin satır sayısına eşit olmalı!");
                return;
            }

            dataGridView3.RowCount = aSatir;
            dataGridView3.ColumnCount = bSutun;

            for (int i = 0; i < aSatir; i++)
            {
                for (int j = 0; j < bSutun; j++)
                {
                    int toplam = 0;
                    for (int k = 0; k < aSutun; k++)
                    {
                        int a = Convert.ToInt32(dataGridView1.Rows[i].Cells[k].Value);
                        int b = Convert.ToInt32(dataGridView2.Rows[k].Cells[j].Value);
                        toplam += a * b;
                    }
                    dataGridView3.Rows[i].Cells[j].Value = toplam;
                }
            }
        }
        void MatrisTranspoz(DataGridView kaynak)
        {
            int satir = kaynak.RowCount;
            int sutun = kaynak.ColumnCount;

            dataGridView3.RowCount = sutun;
            dataGridView3.ColumnCount = satir;

            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    dataGridView3.Rows[j].Cells[i].Value = kaynak.Rows[i].Cells[j].Value;
                }
            }
        }



    }
}
