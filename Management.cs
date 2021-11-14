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
    public partial class Management : Form
    {
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\mdsales\mdsales\product.accdb
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/product.accdb");
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataTable dt;
        string sql;

        public Management()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this, "Welcome to use McDonald Sales System!");

            sql = "SELECT * FROM product";
            load_data(sql, listView1);

            //groupBox1.Visible = false;
            //button3.Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = true;
            btnCreate.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var frm = new Sales();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var idx = listView1.SelectedItems[0].Index;
                var title = dt.Rows[idx].ItemArray[0].ToString();
                var price = dt.Rows[idx].ItemArray[1].ToString();
                tbTitle.Text = title;
                tbPrice.Text = price;
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var title = tbTitle.Text;
            var price = tbPrice.Text;


        }
    }
}
