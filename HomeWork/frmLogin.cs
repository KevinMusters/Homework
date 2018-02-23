using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace HomeWork
{
    public partial class frmLogin : Form
    {
        private MySqlConnection conn;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string connString;
            connString = "datasource=localhost;port=3306;uid=USERNAME;pwd=PASSWORD;Sslmode=none;";
            conn = new MySqlConnection(connString);
        }

        string hash = "uL1[6?ayuCIizj+V>s{vd5tGSiq9Yrr~Xnr)0wK4fY8iOm[u}#";

        public bool Register(string user, string pass)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(pass);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    pass = Convert.ToBase64String(result, 0, result.Length);
                }
            }

            string query = $"insert into homework.login (username, password) values ('{user}', '{pass}');";
            string check = $"select count(*) from homework.login where username='{user}';";

            if (OpenConnection())
            {
                MySqlCommand cmdcheck = new MySqlCommand(check, conn);
                int getValue = Convert.ToInt32(cmdcheck.ExecuteScalar());

                if (getValue > 0)
                {
                    MessageBox.Show("The username is already taken!", "Taken", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    conn.Close();
                    return false;
                }
                else
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            conn.Close();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
            else
            {
                conn.Close();
                return false;
            }
        }

            public bool IsLogin(string user, string pass)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(pass);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    pass = Convert.ToBase64String(result, 0, result.Length);
                }
            }

            string query = $"select * from homework.login where username='{user}' and password='{pass}';";

            try
            {
                if(OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();

                        frmMain main = new frmMain(user);
                        main.Show();
                        this.Hide();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch(Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0:
                        MessageBox.Show(ex.Message);
                        break;
                    case 1045:
                        MessageBox.Show("Server username or password is incorrect!");
                        break;
                }
                return false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            if (user != "" && pass != "")
            {
                if (Register(user, pass))
                {
                    MessageBox.Show("You are registered succesfully!", "Success");
                }
                else
                {
                    MessageBox.Show("There was an error while registering!", "ERROR!");
                }
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
            }
            else if(user == "" || pass == "")
            {
                MessageBox.Show("You did not fill in a username and/or password!", "ERROR!");
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
            }
            else
            {
                MessageBox.Show("You did not fill in a username and/or password!", "ERROR!");
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            if (user != "" && pass != "")
            {
                if (IsLogin(user, pass))
                {
                    MessageBox.Show("You are logged in succesfully!", "Success");
                }
                else
                {
                    MessageBox.Show("The username or password is wrong or there was an other error!", "ERROR!");
                }
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
            }
            else if(user == "" || pass == "")
            {
                MessageBox.Show("You did not fill in a username and/or password!", "ERROR!");
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
            }
            else
            {
                MessageBox.Show("You did not fill in a username and/or password!", "ERROR!");
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
