using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class test2 : System.Web.UI.Page
    {
        int     _userInp = 0;
        Random _rndCpt;
        static int _ncountDown = 30;
        List<string> _totalMsg = new List<string>();


        string[] result = new string[3] { "剪刀", "石頭", "布" };

        protected void Page_Load(object sender, EventArgs e)
        {
            // Usage: Application: Apache/ IIS/ Container
            // synchonize
            int nPeople = 0;
            if ( Convert.ToString(Session["logged"]) == "No")
                Response.Redirect("test");
            else
            {
                Application.Lock();
                nPeople = Convert.ToInt32(Application["cPeople"]) + 1;
                Application["cPeople"] = nPeople;
                Application.UnLock();
            }

            // logged people on web page
            _PeopleCount.Text = nPeople.ToString();

            /*
            if (_TextBoxAcc.Text == "lccnet" && _TextBoxAcc.Text == "123456")
            {
                Response.Redirect("http://tw.yahoo.com/");
            }
            else
            {
                Response.Redirect("http://www.google.com.tw/");
            }
            */
            _rndCpt = new Random((int)DateTime.Now.Millisecond);
            int niCptAnsOut = _rndCpt.Next(0, 3);
            if (niCptAnsOut == 0)
                _imageCpt.ImageUrl = "~/pics/scissor.jpg";
            else if (niCptAnsOut == 1)
                _imageCpt.ImageUrl = "~/pics/stone.jpg";
            else
                _imageCpt.ImageUrl = "~/pics/paper.jpg";

            /*
            Response.Write("Flush 之前</br>");
            Response.Flush();

            Response.Write("Flush 之後， ClearContent 之前</br>");
            Response.ClearContent();

            Response.Write("ClearContent 之後， End 之前</br>");
            Response.End();

            Response.Write("End 之後</br>");
            */
            /*
            Response.Write("9 * 9 乘法表 Web API");
            Response.Write("</br>");

            if ((Request.QueryString["rows"] != null) &&
                (Request.QueryString["cols"] != null))
            {
                int rows = int.Parse(Request.QueryString["rows"]);
                int cols = int.Parse(Request.QueryString["cols"]);

                // 9*9
                for (int row = 1; row < rows; row++)
                {
                    for (int col = 1; col < cols; col++)
                    {
                        string rowText, sResult = "";
                        int nResult = row * col;
                        sResult = nResult.ToString();
                        rowText = row.ToString() + " * " + col.ToString() + " = " + sResult.ToString();
                        Response.Write(rowText);
                        Response.Write(" , ");
                    }
                    Response.Write("</br>");
                }// for 
            }// if arguments exist
            */

            /*
            // != "" fail
            if ((Request.QueryString["height"] != null) &&
                (Request.QueryString["weight"] != null)) { 
                double ndheight = int.Parse(Request.QueryString["height"]);
                double ndweight = int.Parse(Request.QueryString["weight"]);
                ndheight /= 100.0;
                ndheight *= ndheight;
                ndweight /= ndheight;
                Label1.Text = ndweight.ToString();
                Response.Write("Server reponses text.");

                double ndBMI = ndweight / (ndweight * ndweight);
                Label1.Text = ndBMI.ToString();

            }
            */
        }// Load

        protected void Button_Click(object sender, EventArgs e)
        {
            /*
            if( (Request.Form["_TextBoxAcc"] != null) &&
                (Request.Form["_TextBoxPws"] != null))
            {
                if(Request.Form["_TextBoxAcc"] == "lccnet")
                {
                    if (Request.Form["_TextBoxPws"] == "123456")
                        Response.Redirect("http://tw.yahoo.com/");
                    else
                    {
                        PwsLabel1.Text = "密碼帳號輸入錯誤！";
                    }
                }
                else
                {
                    AccLabel.Text = "帳號輸入錯誤！";
                }
            }// 
            */
        }// protected void Button_Click(object sender, EventArgs e)

        private void setCmpPic(int n)
        {
            if (n == 0)
                _imageCpt.ImageUrl = "~/pics/scissor.jpg";
            else if (n == 1)
                _imageCpt.ImageUrl = "~/pics/stone.jpg";
            else
                _imageCpt.ImageUrl = "~/pics/paper.jpg";

        }

        private void decideResult(int user, int niCptAnsOut)
        {
            string outText = "";
            string outUserInp = result[user];
            string outCmpInp = result[niCptAnsOut];

            outText = "你出 " + outUserInp;
            outText += "，電腦出 ";
            outText += outCmpInp;

            if (niCptAnsOut > _userInp)
            {
                if ((niCptAnsOut == 2) && (_userInp == 0)) {
                    outText += "：你贏了！";
                    Label_pssResult.Text = outText;
                    Session["winTimes"] =  Convert.ToInt32(Session["winTimes"]) + 1;
                }
                else {
                    outText += "：你輸了！";
                    Label_pssResult.Text = outText;
                    Session["lossTimes"] = Convert.ToInt32(Session["lossTimes"]) + 1;
                }
            }
            else
            {
                if (niCptAnsOut == _userInp)
                {
                    outText += "：平手.";
                    Label_pssResult.Text = outText;
                }
                    
                else
                {
                    if ((niCptAnsOut == 0) && (_userInp == 2)) {
                        outText += "：你輸了！";
                        Label_pssResult.Text = outText;
                        Session["lossTimes"] = Convert.ToInt32(Session["lossTimes"]) + 1;
                    }
                    else {
                        outText += "：你贏了！";
                        Label_pssResult.Text = outText;
                        Session["winTimes"] = Convert.ToInt32(Session["winTimes"]) + 1;
                    }
                }
            }

        }// private void decideResult()

        protected void UserInpPaper(object sender, ImageClickEventArgs e)
        {
            _userInp = 2;

            int niCptAnsOut = _rndCpt.Next(0, 3);
            setCmpPic(niCptAnsOut);
            decideResult(2, niCptAnsOut);
            // _lossTimes.Text = int.Parse(s: (string)Session["lossTimes"]); // here
        }

        protected void _ImgBtnUser_scissor_Click(object sender, ImageClickEventArgs e)
        {
            _userInp = 0;
            int niCptAnsOut = _rndCpt.Next(0, 3);
            setCmpPic(niCptAnsOut);
            decideResult(0, niCptAnsOut);

        }

        protected void _ImgBtnUser_stone_Click(object sender, ImageClickEventArgs e)
        {
            _userInp = 1;
            int niCptAnsOut = _rndCpt.Next(0, 3);
            setCmpPic(niCptAnsOut);
            decideResult(1, niCptAnsOut);
        }

        protected void _BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("logged");
            Application["cPeople"] = 0;
            Session["logged"] = "No";
            Response.Redirect("test2");
        }

        protected void BrowserClose()
        {

        }// protected void BrowserClose()

        private void toParseTotalMsg(ref ListBox listBox,  string msg)
        {
            string eachLine = "";
            int nBegin = 0, nEnd = 0, i = 0;
            for (i = 0; i < msg.Length; i++)
            {
                eachLine = "";
                while (msg[nEnd] != '\n')
                {
                    nEnd++;
                }
                eachLine = msg.Substring(nBegin, (nEnd - nBegin));
                _ListBox.Items.Add(eachLine);
                //Console.WriteLine("gotten: {0}", eachLine);
                nBegin = nEnd;
                nEnd = i;

            }// for 

        }// private void toParseTotalMsg()

        protected void Timer1Tick(object sender, EventArgs e)
        {
            /*
            _ncountDown--;
            if(_ncountDown >= 0)
                _countDownText.Text = "剩餘時間：" + _ncountDown.ToString() + " 秒";
            */
            /*
                for (int i = 0; i < Application["msgStore"].Length; i++)
                {
                    _ListBox.Items.Add(Application["msgStore"][i]);
                }*/

            if (Application["totalMsg"] != null) {
                _ListBox.Items.Clear();
                _ListBox.Items.Add(Application["totalMsg"].ToString());
            }


        }

        protected void msgSent(object sender, EventArgs e)
        {
            // to get User name
            string userName = Session["login_name"].ToString();
            string msg = _sendMsg.Text;
            string total = userName + " >" + msg;
            _ListBox.Items.Add(total);
            //((List<string>)Application["msgStore"]).Add(total);
            Application["totalMsg"] = Application["totalMsg"] + total + "\\n";
            Application["msgStore"] += total;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(FileUpload1.PostedFile != null)
            {
                HttpPostedFile myFile = FileUpload1.PostedFile;
                Session["myFile"] = myFile;
                // set Image URL
                Image1.ImageUrl = "Handler1.ashx";
            }

            // store it to server
            string fileName;
            if (FileUpload1.HasFile)
            {
                if(FileUpload1.PostedFile.ContentType.IndexOf("Image") == -1)
                {
                    Message.Text = "File type error!";
                    return;
                }
                string Extension = FileUpload1.FileName.Split('.')[FileUpload1.FileName.Split('.').Length - 1];
                fileName = String.Format("{0:yyyyMMddhhmmss}.{1}", DateTime.Now, Extension);
                FileUpload1.SaveAs(Server.MapPath(String.Format("~/image/{0}", fileName)));
            }
        }
        /*            if( (Request.QueryString["number1"] != null) && 
(Request.QueryString["number2"] != null)   )
Label1.Text = ((int.Parse(Request.QueryString["number1"])) +
(int.Parse(Request.QueryString["number2"]))).ToString();*/
    }
}