using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // 1. create a session
            if( (Session["logged"] != null) &&  (Convert.ToString(Session["logged"]) == "Yes") )
            {
                Response.Redirect("test2");
            }
            else {

                /*
                if ((Request.Form["userid"] != null) &&
                    (Request.Form["passwd"] != null)    )
                { 
                    if((Request.Form["userid"] == "lccnet") && 
                        (Request.Form["passwd"] == "123456"))
                    {
                        // 2. set session        
                        Application.Lock();
                        Session["login_name"] = _userName.Text;
                        Session["logged"] = "Yes";
                        int nPeople = Convert.ToInt32(Application["cPeople"]) + 1;
                        Application["cPeople"] = nPeople;
                        Application["msgStore"] = new List<string>();
                        Application.UnLock();
                        Response.Redirect("test2");  // 
                        // Response.Redirect("Handler1.ashx");  // 
                    }
                    else
                    {
                        if (Request.Form["userid"] != "lccnet")
                        {
                            _veri_userid.Text = "帳號錯誤！";
                        }
                        else
                        {
                            _veri_userid.Text = "";
                        }
                        if (Request.Form["passwd"] != "123456")
                        {
                            _veri_passwd.Text = "密碼錯誤！";
                        }
                        else
                        {
                            _veri_passwd.Text = "";
                        }
                        // Response.Redirect("http://www.google.com.tw/");
                    }
                }// 
                */
                string s_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AccountsConnectionString"].ConnectionString;

                //new一個SqlConnection物件，是與資料庫連結的通道(其名為Connection)，以s_data內的連接字串連接所對應的資料庫。
                SqlConnection connection = new SqlConnection(s_data);
                string v = "select * from AccTable where name ='" + Request.Form["userid"];
                string sqlText = v + "'";

                //new一個SqlCommand告訴這個物件準備要執行什麼SQL指令
                SqlCommand Command = new SqlCommand(sqlText, connection);

                //與資料庫連接的通道開啟
                connection.Open();

                //new一個DataReader接取Execute所回傳的資料。
                SqlDataReader Reader = Command.ExecuteReader();

                //檢查是否有資料列
                if (Reader.HasRows)
                {
                    //使用Read方法把資料讀進Reader，讓Reader一筆一筆順向指向資料列，並回傳是否成功。
                    if (Reader.Read())
                    {
                        //DataReader讀出欄位內資料的方式，通常也可寫Reader[0]、[1]...[N]代表第一個欄位到N個欄位。
                        // Label1.Text = Reader["name"].ToString();
                        if (Reader["passwd"].ToString() == Request.Form["passwd"])
                        {
                            Application["count"] = Convert.ToInt32(Application["count"]) + 1;
                            Session["name"] = Request.Form["name"];
                            Session["logined"] = "1";
                            Server.Transfer("test2.aspx");
                        }
                        else
                        {
                            _veri_passwd.Text = "密碼錯誤！";
                        }
                        
                    }
                }
                else
                {
                    // account miss
                    _veri_userid.Text = "帳號錯誤！";
                }

                //關閉與資料庫連接的通道
                connection.Close();

            }// non logged
            

        }// Page_Load


    }
}