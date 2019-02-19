using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data.Odbc;
using System.Text;
using System.Data;
using System.IO;
using System.Web.Mvc;


namespace UserQueries
{
   /* connection string fully configured on this box's "ODBC Data Sources (32-bit)" window */
   public partial class WebFormUI : System.Web.UI.Page
   {
      // static readonly string QUERY_BY_EMAIL = "select customer_id, login_name, first_name, last_name from prod.prod_customers where email = " ;  
      static readonly string QUERY_BY_EMAIL = "select customer_id, login_name, first_name, last_name from prod.prod_customers where email like "; //sd%@drf.com' debug
      protected void Page_Load(object sender, EventArgs e)
      {
         Debug.WriteLine("WebFormUI getting loaded...");
      }

      protected void BtnViewMSWord_Click(object sender, EventArgs e)
      {
         Debug.WriteLine("In BtnViewMSWord_Click() clicked . . . ");
         string filepath = @"C:\Users\sdass\Documents\Visual Studio 2015\Projects\UserQueries\UserQueries\data\Sunday - 12-9-2018 SSTF Notes.docx";
         FileInfo finfo = new FileInfo(filepath);
         
         if (File.Exists(filepath))
         {
            Debug.WriteLine("file exists . . . ");
            FileStream fs = (new FileStream(filepath, FileMode.Open, FileAccess.Read));
            Response.ContentType = "Application/msword";
            Response.AppendHeader("Content-Disposition", "inline; filename=" + finfo.Name); //gives proper filename on download
            Response.AppendHeader("Content-Length", "inline; filename=" + finfo.Length.ToString());
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

            Response.End(); //gracefully signaling to browser transfer ended
         }

      }


      protected void BtnViewPdf_Click(object sender, EventArgs e)
      {
         Debug.WriteLine("In BtnViewPdf_Click() clicked . . . ");
           Response.Redirect("~/WebFormPdfView.aspx?PDF=HAW0920_0710P.pdf");     //  redirect 302 involved
        // Server.Transfer("~/WebFormPdfView.aspx?PDF=HAW0920_0710P.pdf"); //forward equivalent

        // ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "changeUrlAddressAndHistory()", true); not affecting
      }
      protected void BtnSubmit_Click(object sender, EventArgs e)
      {
         if (TxtBxSearchInput.Text == null || TxtBxSearchInput.Text == "")
         {
            divMessage.InnerText = "enter valid email address";
            GridView1.Visible = false;
            return;
         }
         else
         {
            Debug.WriteLine("WebFormUI BtnSubmit_Click() entered else()...");
            divMessage.InnerText = "";
         }
         Debug.WriteLine("WebFormUI BtnSubmit_Click() entered..." + TxtBxSearchInput.Text);

         string searchInput = string.Format( "'{0}'",TxtBxSearchInput.Text);
         string userQuery = string.Format("{0}{1}", QUERY_BY_EMAIL, searchInput);

         Debug.WriteLine("query=" + userQuery);

         DataTable retTable = getdataFromDb(userQuery, getConnectString()); 
         
         if ( (retTable == null) || ( (retTable != null) && (retTable.Rows.Count == 0) ) )
         {
            divMessage.InnerText = "No records available for this email";
         }
         else
         {
            foreach (DataRow row in retTable.Rows)
            {
               Debug.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3] + "<");
            }

            GridView1.DataSource = retTable;
            GridView1.DataBind();
            GridView1.Visible = true;
         }
      }



      /* works  on error returns null else returns datatable filled with data */
      protected DataTable getdataFromDb(string userQuery, string connectString)
      {

         Debug.WriteLine("WebFormUI getting loaded...");
         //https://docs.microsoft.com/en-us/dotnet/api/system.data.odbc.odbcdatareader?view=netframework-4.7.2
         Debug.WriteLine("connectString={0}. userQuery={1}", connectString, userQuery);

         DataTable retTable = new DataTable();
         retTable.Columns.Add("ID", typeof(string));
         retTable.Columns.Add("First Name", typeof(string));
         retTable.Columns.Add("Last Name", typeof(string));
         retTable.Columns.Add("Login Id", typeof(string));

         try
         {
            using (OdbcConnection conn = new OdbcConnection(connectString))
            {
               OdbcCommand command = new OdbcCommand(userQuery, conn);
               conn.Open();
               using (OdbcDataReader reader = command.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     StringBuilder sb = new StringBuilder("arow=");
                     for (int i = 0; i < reader.FieldCount; i++)
                     {
                        string delimit = (i < (reader.FieldCount - 1)) ? ", " : ".";
                        sb.Append(reader[i] + delimit);
                     }
                     retTable.Rows.Add(reader[0], reader[1], reader[2], reader[3]); //getting fourcolumns
                     Debug.WriteLine(sb.ToString());
                  }
               }

            }
            return retTable;
         }
         catch (Exception e)
         {
            Debug.WriteLine("Exception: " + e.Message);
            return null; 
         }
 
      }

         /* advanced way does not work problem in creating sqlConnection  must use ODBC
      protected void getdataFromDb(string userQuery, string connectString)
      {
         //https://docs.microsoft.com/en-us/dotnet/api/system.data.odbc.odbcdatareader?view=netframework-4.7.2
         Debug.WriteLine("connectString={0}. userQuery={1}", connectString, userQuery);

         DataTable retTable = new DataTable();
         retTable.Columns.Add("ID", typeof(string));
         retTable.Columns.Add("First Name", typeof(string));
         retTable.Columns.Add("Last Name", typeof(string));
         retTable.Columns.Add("Login Id", typeof(string));

         DataSet retDataSet = new DataSet(); //as if a database while each inside is a DataTable

         using (OdbcConnection conn = new OdbcConnection(connectString))
         {
            //OdbcCommand command = new OdbcCommand(userQuery, conn);
            SqlCommand sqlCommand = new SqlCommand(userQuery, new SqlConnection(connectString));
            //conn.Open(); //implicit open in fill() call // /implicit open in fill() call
            https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter
            using (SqlDataAdapter sqladapter = new SqlDataAdapter(sqlCommand))
            {
               sqladapter.Fill(retDataSet, "RetTable");
               retTable = retDataSet.Tables["RetTable"];
            }

         }//using ends

         foreach (DataRow row in retTable.Rows)
         {
            Debug.WriteLine(row["ID"] + "<>" + row["First Name"]);
         }
      }
      */

      private string getConnectString()
      {

         bool isProd = ("False" == (string)Properties.Settings.Default.Properties["IsProduction"].DefaultValue) ? false : true;
         Debug.WriteLine("IsProduction=" + Properties.Settings.Default.Properties["IsProduction"].DefaultValue);

         string connectString = "";
         // isProd = true; //debug
         if (isProd)
         {
            connectString = "" + Properties.Settings.Default.Properties["SybaseConnectionString1"].DefaultValue;
         }
         else
         {
            connectString = "" + Properties.Settings.Default.Properties["SybaseStageConnection"].DefaultValue;
         }

         //SybaseConnectionString1
        // Debug.WriteLine("SybaseConnectionString1=" + Properties.Settings.Default.Properties["SybaseConnectionString1"].DefaultValue);
        // Debug.WriteLine("SybaseStageConnection=" + Properties.Settings.Default.Properties["SybaseStageConnection"].DefaultValue);
        // Debug.WriteLine("Picked connectString=" + connectString);
         return connectString;
      }
   }
}