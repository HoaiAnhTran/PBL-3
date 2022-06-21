using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClothShop.BLL;
using ClothShop.DTO;

namespace ClothShop.View.MyForms
{
    public partial class Form_AddNhomSP : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        int ID = -1;
        public Form_AddNhomSP()
        {
            InitializeComponent();
            ReLoad();
        }

        private void butNo_Click(object sender, EventArgs e)
        {
            this.Close();
            ID = -1;
        }
        public void ReLoad()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllNhomSP();
        }
        private void butYes_Click(object sender, EventArgs e)// thêm check trùng
        {
            if (tbNhomSP.Text != "" && tbNhomSP.Text != null)
            {
                if (BLLClothShop.Instance.GetNhomSPByName(tbNhomSP.Text) == null)
                {
                    NhomSP s = new NhomSP()
                    {
                        ID_NhomSP = ID,
                        Ten_NhomSP = tbNhomSP.Text,
                    };
                    BLLClothShop.Instance.AddNhomSP(s);
                }
                else
                    MessageBox.Show("Không thể thêm nhóm trùng");
            }
            else
                MessageBox.Show("Không thể thêm nhóm rỗng");
            tbNhomSP.Text = "";
            ReLoad();
        }

        private void butNo_Click_1(object sender, EventArgs e)
        {
            d();
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                tbNhomSP.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }    
        }
    }
}
