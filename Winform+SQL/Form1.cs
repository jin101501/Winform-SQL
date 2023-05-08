using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Winform_SQL
{
    public partial class Form1 : Form
    {
        private DataTable data_table = null;
        public Form1()
        {
            InitializeComponent();
            try
            {
                lock (DBHelper.DBConn)
                {
                    if (!DBHelper.IsDBConnected)
                    {
                        MessageBox.Show("Database ������ Ȯ�����ּ���");
                        return;
                    }
                    else
                    {
                        // DB ������ �ǰ� �� ��  
                        SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Student", DBHelper.DBConn);
                        data_table = new DataTable();
                        try
                        {
                            adapter.Fill(data_table);
                            dataGridView1.DataSource = data_table;
                            //DataGridView ����� �°� �ڵ� ����
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "DataGridView_Load Error");
                        }
                        DBHelper.Close();
                    }
                }
            }
            catch (ArgumentException ane)
            {
                MessageBox.Show(ane.Message, "DataGridView_Load Error");
            }
        }
    }
}