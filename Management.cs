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
                    if (c.ColumnName == "id") continue;

                    //first letter to uppercase
                    string name = c.ColumnName.Substring(0, 1).ToUpper() + c.ColumnName.Substring(1);
                    lst.Columns.Add(name);
                }


                lst.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(r[1].ToString());
                    for (int i = 2; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(r[i]+"");
                    }
                    lst.Items.Add(item);
                }

                lst.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                //da.Dispose();
            }
        }

        private void reset_input()
        {
            tbTitle.Text = null;
            tbCategory.Text = null;
            tbPrice.Text = null;
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

            var frm = new Sales();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };

            this.Hide();
            frm.ShowDialog();
            this.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var idx = listView1.SelectedItems[0].Index;
                var id = dt.Rows[idx].ItemArray[0].ToString();
                var category = dt.Rows[idx].ItemArray[1].ToString();
                var title = dt.Rows[idx].ItemArray[2].ToString();
                var price = dt.Rows[idx].ItemArray[3].ToString();

                product_id.Text = id.ToString();
                tbCategory.Text = category;
                tbTitle.Text = title;
                tbPrice.Text = price;
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var id = product_id.Text.ToString();
                var category = tbCategory.Text.ToString();
                var title = tbTitle.Text.ToString();
                var price = tbPrice.Text.ToString();

                // update the records in database
                con.Open();
                sql = "update product set category='" + category + "',title='" + title + "',price=" + price + " where id="+id;
                da.UpdateCommand = new OleDbCommand(sql, con);
                if (da.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Update successful.");
                }
                con.Close();

                // refresh
                Management_Load(sender, e);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var category = tbCategory.Text.ToString();
            var title = tbTitle.Text.ToString();
            var price = tbPrice.Text.ToString();

            // add records to database
            con.Open();
            sql = "insert into product(category,title,price) values('" + category + "','" + title + "'," + price + ")";
            da.InsertCommand = new OleDbCommand(sql,con);
            if(da.InsertCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Create successful.");
            }
            con.Close();

            // refresh
            Management_Load(sender,e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = product_id.Text.ToString();

            // delete records in database
            con.Open();
            sql = "delete * from product where id=" + id;
            da.DeleteCommand = new OleDbCommand(sql, con);
            if (da.DeleteCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Delete successful.");
            }
            con.Close();

            // refresh
            Management_Load(sender, e);
            reset_input();
        }
    }
}
