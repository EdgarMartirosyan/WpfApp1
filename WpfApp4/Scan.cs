using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WpfApp4
{
    class Scan
    {
        public static async Task<bool> Scan_Json(string sURL)

        {
            //--------< Scrape_List() >--------
            app.URL = sURL;
            //Uri baseUrl = new Uri(sURL);
            if (app.Check_Stop == true) return false;
            string sPage = sURL; //baseUrl.Query;
            clsSys.fx_Log("--< List: " + sPage + " >--");
            //< download >
            string sDownload_as_String = await clsWebReader.Web_Get_Download_as_String(sURL);
            if (sDownload_as_String == null) return false;
            //</ download >

            try
            {
                //------< Get Values as Json-Array >------
                //< convert to array >

                JsonObject jsonDownload = JsonObject.Parse(sDownload_as_String);

                JsonValue jsonResponse = jsonDownload["response"] as JsonValue;

                JsonArray jsonResonseArray = jsonResponse.GetArray();

                //</ convert to array >

                //----< @Loop: Json-Rows >----

                foreach (var jsonRow in jsonResonseArray)
                {
                    //----<  Json_Row >----
                    JsonObject jsonObject = jsonRow.GetObject();
                    //< values >
                    string sID = jsonObject["id"].GetString();
                    string sTitle = jsonObject["name"].GetString();
                    //</ values >
                    string sURL_Detail = app_settings.scan_List_Json_URL_Base + sID;

                    //< correct >
                    //sTitle = clsText.Encode(sTitle);
                    //</ correct >
                    //< add/update URL >

                    clsDB.Add_or_Update_Record_from_List(sURL_Detail, sTitle);

                    //</ add/update URL >
                    //< print >

                    clsSys.fx_Log(sTitle);

                    //</ print >

                   //----</  Json_Row >----
                }
                //----</ @Loop: Json-Rows >----
                //------</ Get Values as Json-Array >------
            }
            catch (Exception ex)
            {
                clsSys.fx_Error_Log(ex.Message);
            }

            clsSys.fx_Log("--</ List: " + sPage + " >--");
            clsSys.fx_Log("");

            //< out >

            return true;
            //</ out >
            //--------</ Scrape_List() >--------
        }
    }
}
