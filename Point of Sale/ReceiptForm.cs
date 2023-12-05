using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_of_Sale
{
    public partial class ReceiptForm : Form
    {
        private ArrayList _listData;

        public ReceiptForm()
        {
            InitializeComponent();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            totalAmount.Text= UserForm.total.ToString();
            payment.Text= UserForm.payment.ToString() + ".00";
            change_Sukli.Text = UserForm.sukli.ToString();
        }
        

        public void SetListData(ArrayList listData)
        {
            _listData = listData;
            foreach (var item in _listData)
            {
                listbox1.Items.Add(item);
            }
        }

        private void ReceiptForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listbox1.Items.Clear(); 
        }

        
    }
}
