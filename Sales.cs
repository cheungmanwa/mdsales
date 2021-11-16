using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mdsales
{
    public partial class Sales : Form
    {
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\mdsales\mdsales\product.accdb
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/product.accdb");
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataTable dt;
        string sql;

        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            sql = "SELECT * FROM product";
            load_data(sql, listView1);
        }

        private void load_data(string sql, ListView lst)
        {
            try
            {

                con.Open();

                cmd = new OleDbCommand();
                da = new OleDbDataAdapter();
                dt = new DataTable();

                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);

                lst.Columns.Clear();
                foreach (DataColumn c in dt.Columns)
                {
                    lst.Columns.Add(c.ColumnName);
                }


                lst.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(r[0].ToString());
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(r[i].ToString());
                    }
                    lst.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }

        public double cost_of_items()
        {
            Double sum = 0;
            int i = 0;

            for (i = 0; i < (dataGridView1.Rows.Count); i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum;
        }

        private void AddDiscount()
        {
            Double discount, totalSum;
            discount = 10;

            if (dataGridView1.Rows.Count > 0)
            {
                totalSum = cost_of_items() + (1-(1/discount));
                total.Text = Convert.ToString(totalSum);
            }
        }

        private void Change()
        {
            Double total, cost, change;

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var idx = listView1.SelectedItems[0].Index;
                var title = dt.Rows[idx].ItemArray[0].ToString();
                var price = dt.Rows[idx].ItemArray[1].ToString();

            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            try
            {
                subTotal.Text = "0";
                total.Text = "0";
                discount.Text = "0";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pay_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Convert.ToDouble(change.Text) >= 0)
                {
                    MessageBox.Show("Payment Successful, The amount is " + total.Text + " HKD.", "Payment Successful Message");
                    subTotal.Text = "0";
                    total.Text = "0";
                    discount.Text = "0";
                    cost.Text = "0";
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                } 
                else
                {
                    MessageBox.Show("Wrong Change or cost", "Payment Fail Message");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NumbersOnly(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (cost.Text == "0")
            {
                cost.Text = "";
                cost.Text = b.Text;
            }
            else if (b.Text == ".")
            {
                if (! cost.Text.Contains("."))
                {
                    cost.Text = cost.Text + b.Text;
                }
            }
            else
            {
                cost.Text = cost.Text + b.Text;
            }

        }
        private void resetCost_Click(object sender, EventArgs e)
        {
            cost.Text = "0";
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void discount_Click(object sender, EventArgs e)
        {

        }

        private void btnMgm_Click(object sender, EventArgs e)
        {

            var frm = new Management();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };

            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {

        }
    }
}
