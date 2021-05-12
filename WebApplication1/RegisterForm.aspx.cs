using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            //new一個SqlConnection物件，是與資料庫連結的通道(其名為Connection)，以s_data內的連接字串連接所對應的資料庫。
            SqlConnection connection = new SqlConnection(s_data);
            string sqlText = $"insert into [Accounts].[dbo].[AccTable](username,passwd,name) values('" + 
                                Request.Form["_username"]   + "', '" + 
                                Request.Form["_passwd"] +  "','" + 
                                Request.Form["_name"]   +  "')"  ;

            //new一個SqlCommand告訴這個物件準備要執行什麼SQL指令
            SqlCommand Command = new SqlCommand(sqlText, connection);

            // 2nd
            string     sqlTextP = $"insert into [Accounts].[dbo].[AccTable](username,passwd,name) values(@username, @passwd, @name)";
            SqlCommand CommandP = new SqlCommand(sqlText, connection);

            CommandP.Parameters.Add("@username", SqlDbType.NVarChar);
            CommandP.Parameters["@username"].Value = 


            //與資料庫連接的通道開啟
            connection.Open();

            //new一個DataReader接取Execute所回傳的資料。
            SqlDataReader Reader = Command.ExecuteReader();

            //關閉與資料庫連接的通道
            connection.Close();
        }
    }
}