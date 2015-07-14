﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBF_Exporter.Model
{
    public class Problem
    {
        public int id { get; set; }
        public string probcod { get; set; }
        public string probdesc { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string name { get; set; }
        public int users_id { get; set; }
        public string users_name { get; set; }
        public int serial_id { get; set; }
        public string serial_sernum { get; set; }
    }
}
