using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace coaching
{
    public partial class Form1 : Form
    {
        private String name,pwd;
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            name=username.Text;
            pwd = password.Text;
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=localhost;Database=Coaching institute;uid=root;pwd=;";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText="select * from user where uname='"+name+"' and pwd='"+pwd+"'";
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                char c = name[0];

                switch (c)
                {
                    case 'S':
                       // MessageBox.Show("Login success");
                        String id = name.Substring(1);
                        Form2 f2=new Form2(id);
                        f2.Show();
                        break;

                    case 'T':
                        //load teacher form
                        break;
                    
                }
            }
            else
                MessageBox.Show("Invalid login");
            
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            username.Text = "S1234";
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.Text = "1234";
        }
        
    }
}
