using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HomeWork
{
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string date = txtDate.Text;
                string title = txtHomework.Text;
                string homework = txtExplain.Text;

                string strConnect = "datasource=localhost;port=3306;uid=USERNAME;pwd=PASSWORD;SslMode=none;";
                string Query = string.Format("insert into homework.homework(date, homework_title, homework) values('{0}','{1}','{2}');", date, title, homework);

                MySqlConnection sqlConnection = new MySqlConnection(strConnect);
                MySqlCommand sqlCommand = new MySqlCommand(Query, sqlConnection);

                MySqlDataReader sqlReader;
                sqlConnection.Open();
                sqlReader = sqlCommand.ExecuteReader();
                sqlConnection.Close();
                MessageBox.Show("Homework added with title: " + title, "Homework Added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            calDate.MaxSelectionCount = 1;
            txtDate.Text = calDate.SelectionRange.Start.ToShortDateString();
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            calDate.MinDate = DateTime.Today;
        }
    }
}
