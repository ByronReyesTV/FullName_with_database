using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FullName_with_database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //1. address of SQL server and database
            String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=FullNameDB;Integrated Security=True";

            //2. establish connection
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection
            con.Open();

            //4. prepare query
            string label1 = textBox1.Text;
            string label2 = textBox2.Text;
            string label3 = textBox3.Text;

            string Query = "INSERT INTO FullName (FirstName, MiddleName, LastName) VALUES ('"+label1+"', '"+label2+"', '"+label3+"')";

            //5. execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            //6. close connection
            con.Close();

            MessageBox.Show("Data has been saved");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database (Connection String)
            String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=FullNameDB;Integrated Security=True";

            //2. establish connection (c# sqlconnection class)
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection (c# sqlconnection open)
            con.Open();

            //4. prepare query
            string Query = "SELECT * FROM FullName";
            SqlCommand cmd = new SqlCommand(Query, con);

            //5. execute query (c# sqlcommand class)
            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            dataGridView1.DataSource = table;

            //6. close connection (c# sqlcommand close)
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
