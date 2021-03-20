using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace C969_Task1_SchedulingApp
{
    public class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        public static bool Login(string username, string psswrd)
        {
            //Connect to external database
            string conString = "SERVER=3.227.166.251;DATABASE=U059hb;Uid=U059hb;Pwd=53688440397;SslMode=None";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();

            //Attempt login
            try
            {
                //Query matching username/password
                string stm = "SELECT * FROM user WHERE userName=@username AND password=@password";
                MySqlCommand cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", psswrd);
                MySqlDataReader rdr = cmd.ExecuteReader();

                //If record exists
                bool reader = rdr.HasRows;
                rdr.Close();
                con.Close();

                return reader;
            }

            //Unsuccessful login
            catch (Exception)
            {
                throw;
            }

            finally
            {
                //Close if still open
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        //Generic retrieve data method
        public static ArrayList GetData(string stm)
        {
            ArrayList data = new ArrayList();

            string conString = "SERVER=3.227.166.251;DATABASE=U059hb;Uid=U059hb;Pwd=53688440397;SslMode=None";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            //Copy all queried data to a Collections Arraylist
            while (rdr.Read())
            {
                for (int i = 0; i < rdr.FieldCount; i++)
                    data.Add(rdr[i]);

                data.Add(Environment.NewLine);
            }

            rdr.Close();
            con.Close();

            return data;
        }

        public static void BindGridView(string stm, DataGridView grid)
        {
            //Bind all queried data to gridview
            using (MySqlConnection con = new MySqlConnection("SERVER=3.227.166.251;DATABASE=U059hb;Uid=U059hb;Pwd=53688440397;SslMode=None"))
            {
                con.Open();
                MySqlDataAdapter data = new MySqlDataAdapter();
                data.SelectCommand = new MySqlCommand(stm, con);

                DataTable table = new DataTable();
                data.Fill(table);

                //Convert dates to local time
                try
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        dr[7] = Convert.ToDateTime(dr[7]).ToLocalTime();
                        dr[8] = Convert.ToDateTime(dr[8]).ToLocalTime();
                    }
                }

                catch { }

                BindingSource bind = new BindingSource();
                bind.DataSource = table;

                grid.DataSource = bind;
                con.Close();
            }
        }

        //Generic set data method (UPDATE, INSERT, DELETE)
        public static void SetData(string stm)
        {
            string conString = "SERVER=3.227.166.251;DATABASE=U059hb;Uid=U059hb;Pwd=53688440397;SslMode=None";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
 