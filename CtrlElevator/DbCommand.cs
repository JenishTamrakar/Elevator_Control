using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace CtrlElevator
{
    class DbCommand
    {
        public void SaveLog(string act)
        {
            string sql = "INSERT INTO [ActionLogs]([DATE], [TIME], [ACTIONS]) VALUES(@DATE, @TIME, @ACTIONS)";
            OleDbCommand cmd = new OleDbCommand(sql, GlobalConnection.con);
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            cmd.Parameters.AddWithValue("@DATE", date);
            cmd.Parameters.AddWithValue("@TIME", time);
            cmd.Parameters.AddWithValue("@ACTIONS", act);
            cmd.ExecuteNonQuery();
        }

        public DataTable ViewActionLog()
        {
            string sql = "SELECT * FROM ActionLogs";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, GlobalConnection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "ActionLogs");
            return ds.Tables[0];
        }
    }
}
