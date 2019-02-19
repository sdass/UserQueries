using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;

namespace UserQueries
{
   public partial class WebFormPdfView : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Debug.WriteLine("WebFormPdfView. Page_Load() . . . executed ");
         if( Request.QueryString["PDF"] == null)
         {
            Debug.WriteLine("ERROR ERROR");
            return;
         }
            Debug.WriteLine("filename" + Request.QueryString["PDF"]);

            //string filepath = @"C:\Users\sdass\Documents\Visual Studio 2015\Projects\UserQueries\UserQueries\data\HAW0920_0710P.pdf";
            string dirpath = @"C:\Users\sdass\Documents\Visual Studio 2015\Projects\UserQueries\UserQueries\data\"; // HAW0920_0710P.pdf";
            string filepath = Path.Combine(dirpath, Request.QueryString["PDF"]);
            // File f = new File()
            if (File.Exists(filepath))
            {
               Debug.WriteLine("file exists . . . ");
               FileStream fs = (new FileStream(filepath, FileMode.Open, FileAccess.Read));
               Response.ContentType = "application/pdf";
               Response.Buffer = true;

               const int buffersize = 64 * 1024;
               byte[] buffer = new byte[buffersize];

               int count = fs.Read(buffer, 0, buffersize);
               while (count > 0)
               {
                  Response.OutputStream.Write(buffer, 0, count);
                  Array.Clear(buffer, 0, buffersize);
                  count = fs.Read(buffer, 0, buffersize);
               }


            }
            // no use ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "changeUrlAddressAndHistory()", true);
         
      }
      }
   
}