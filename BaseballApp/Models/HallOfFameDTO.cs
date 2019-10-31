using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BaseballApp.Models
{
    public class HallOfFameDTO
    {
        public class HallOfFame
        {
            public string _nome { get; set; }
            public string _cognome { get; set; }
            public string _giornoNascita { get; set; }
            public string _meseNascita { get; set; }
            public string _annoNascita { get; set; }
            public string _nazionalita { get; set; }
            public string _debutto { get; set; }
            public string _manoGuantone { get; set; }
            public string _manoMazza { get; set; }
        }

    }

}