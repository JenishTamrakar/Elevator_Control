﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CtrlElevator
{
    class GlobalConnection
    {
        public static OleDbConnection con;
        public static void DbConnection()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ElevatorLog.mdb");
            con.Open();
        }
    }
}
