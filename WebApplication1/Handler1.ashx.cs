using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1
{
    /// <summary>
    /// Handler1 的摘要描述
    /// </summary>
    public class Handler1 : System.Web.UI.Page, IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            /*
            if(context.Response.Form["login_name"].ToString() == "123")
            {
                context.Response.Redirect("http://tw.yahoo.com/");
            }
            else
            {
                context.Response.Redirect("http://www.google.com.tw/");
            }
            */
            /*
             * 
            if(context.Session["myFile"] != null) { 
                HttpPostedFile myFile = (HttpPostedFile)context.Session["myfile"];
                int myFile_Length = myFile.ContentLength;
            }
            */

        }// public void ProcessRequest(HttpContext context)

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}