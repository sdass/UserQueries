using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Drawing;

namespace UserQueries
{
   public partial class WebFormJQuery : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Debug.WriteLine("On button click does it reach Page_Load()");
      }

      protected void BtnProcess_Click(object sender, EventArgs e)
      {
         Debug.WriteLine("Reached BtnProcess_Click()");

         lblStatusId.Text = parseAndCreateTicket();
         lblStatusId.ForeColor = Color.Green;

      }

      private string parseAndCreateTicket()
      {
         string allInput = txtBoxAllINputId.Text;
         Debug.WriteLine("inputs: {0}", allInput );
         string msg = string.Format("Ticket created with information: {0}", allInput );
         //do conditional succes later

         string[] date_region_tracks = allInput.Split('|');
         string editionDate = date_region_tracks[0];
         string region = date_region_tracks[1];
         string trackList = date_region_tracks[2];
         Debug.WriteLine("inputs: edition date={0}, region={1} tracklist={2}", editionDate, region, trackList);

         return msg;
      }

     
   }
}