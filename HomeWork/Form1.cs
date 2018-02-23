using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime;
using Windows;
using Windows.Foundation;
using Windows.UI;

namespace HomeWork
{
    public partial class frmMain : Form
    {
       

        public frmMain(string user)
        {
            InitializeComponent();
            user = user.ToUpper();
            lblName.Text = user;
            lblName.ForeColor = System.Drawing.Color.Green;
            lblName.Font = new Font(lblName.Font.Name, lblName.Font.SizeInPoints, FontStyle.Bold);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new frmAdd();
            frmAdd.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            load();
        }

        private void tmrInfo_Tick(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Export Homework";
            sfd.Filter = "Text File (.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            sw.WriteLine("ID {0}  -  {1} | {2}  -  {3}", item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text);
                        }
                        MessageBox.Show("File saved as: " + filename, "File Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            load();
            MessageBox.Show("Successfully reloaded items!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void load()
        {
            string strConnect = "datasource=localhost;port=3306;uid=USERNAME;pwd=PASSWORD;SslMode=none;";
            string Query = "select * from homework.homework";


            MySqlConnection sqlConnection = new MySqlConnection(strConnect);
            MySqlCommand cm = new MySqlCommand(Query, sqlConnection);

            try
            {
                listView1.Items.Clear();
                sqlConnection.Open();
                MySqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["ID"].ToString());
                    item.SubItems.Add(dr["date"].ToString());
                    item.SubItems.Add(dr["homework_title"].ToString());
                    item.SubItems.Add(dr["homework"].ToString());

                    listView1.Items.Add(item);
                }
                sqlConnection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            lblItems.Text = String.Format("You have {0} homework items ", listView1.Items.Count.ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string idItem = listView1.SelectedItems[0].Text;

                string delQuery = string.Format("DELETE FROM homework.homework WHERE ID = " + idItem);
                string strConnect = "datasource=localhost;port=3306;uid=USERNAME;pwd=PASSWORD;SslMode=none;";

                MySqlConnection sqlConnection = new MySqlConnection(strConnect);
                MySqlCommand cm = new MySqlCommand(delQuery, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    MySqlDataReader sqlReader;
                    sqlReader = cm.ExecuteReader();
                    sqlConnection.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "ERROR!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                lblDate.Text = "";
                lblTitle.Text = "";
                richTextBox1.Clear();
                lblExpired.Text = "";
                load();
            }
            else
            {
                MessageBox.Show("You didn't select an item to remove. Please select an item!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                richTextBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
                lblTitle.Text = listView1.SelectedItems[0].SubItems[2].Text;
                lblDate.Text = listView1.SelectedItems[0].SubItems[1].Text;
                if (HasExpired())
                {
                    lblExpired.Text = "Expired";
                    lblExpired.ForeColor = System.Drawing.Color.Red;
                    DialogResult dr = MessageBox.Show("Do you want to remove this item? It is expired.", "Expired", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        btnRemove.PerformClick();
                    }
                    else
                    {

                    }
                }
                else
                {
                    lblExpired.Text = "Not expired";
                    lblExpired.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                richTextBox1.Clear();
                lblTitle.Text = "";
                lblDate.Text = "";
                lblExpired.Text = "";
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public bool HasExpired()
        {
            string expires = listView1.SelectedItems[0].SubItems[1].Text;
            DateTime Expires = DateTime.Parse(expires);
            return DateTime.Now.CompareTo(Expires.Add(new TimeSpan(2, 0, 0))) > 0;
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
