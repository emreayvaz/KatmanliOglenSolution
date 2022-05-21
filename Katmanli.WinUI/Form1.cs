using Katmanli.BLL.Repositories;
using Katmanli.DAL;
using Katmanli.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Katmanli.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CategoryRepository cr = new CategoryRepository();

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KategorileriGetir();
            
        }

        private void KategorileriGetir()
        {
            dataGridView1.DataSource = cr.GetAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox3.Text);
            List<Category> c = new List<Category>();
            c.Add(cr.Get(id));
            dataGridView1.DataSource = c;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                cr.Delete(id);
                KategorileriGetir();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("KUTULARI DOLDURUNUZ");
                return;
            }
            cr.Insert(new CategoryDTO
            {
                CategoryName = textBox1.Text,
                Description= textBox2.Text
            });

            KategorileriGetir();
            Temizle();
        }

        private void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
            }
        }

        Category guncellenecek;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                int id =Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                guncellenecek = cr.Get(id);
                textBox1.Text = guncellenecek.CategoryName;
                textBox2.Text = guncellenecek.Description;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guncellenecek.CategoryName = textBox1.Text;
            guncellenecek.Description = textBox2.Text;
            cr.Update(guncellenecek);
            Temizle();
            KategorileriGetir();
        }
    }
}
