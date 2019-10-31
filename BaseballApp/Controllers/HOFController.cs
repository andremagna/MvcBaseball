using System.Web.Mvc;
using System.Data.SqlClient;
using static BaseballApp.Models.HallOfFameDTO;
using System.Collections.Generic;
using System.Data;

namespace BaseballApp.Controllers
{
    public class HOFController : Controller
    {
        public ActionResult Index(HallOfFame a)
        {
            string dataS = "ITEM-S86401"+@"\"+"SQLEXPRESS";

            HallOfFame prova = new HallOfFame();

            string connString = "Server= "+dataS+"; Database= BaseballData; Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connString))
            {

                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1* FROM[dbo].[HallOfFame] WHERE yearID = '2014'", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {

                            while (reader.Read())
                            {
                                prova._nome = "a";
                                prova._cognome = "b";
                                prova._giornoNascita = "c";
                                prova._meseNascita = "d";
                                prova._annoNascita = "e";
                                prova._nazionalita = "f";
                                prova._debutto = "g";
                                prova._manoGuantone = "h";
                                prova._manoMazza = "i";
                            }
                        }
                    } 

                } 

            }
            return View();
        }
    }
}