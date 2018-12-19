using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Football.DAL.TableObjects;
using Football.BAL;

namespace Football.DAL
{
    public class TeamDetails
    {
        public void ReadDATFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf("bin"));
            path = path + "DAL";
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";extended Properties=\"text;HDR=YES;FMT=Delimited\"";
            StringBuilder sb = new StringBuilder();
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT Team,P,W,L,D,F,A,Pts from [football.csv]", conn);
                DataSet dsFootball = new DataSet();
                da.Fill(dsFootball);
                DataTable dtFootball = dsFootball.Tables[0];
                dtFootball = FootballDS.FootballTeams(dtFootball);
                DataMining dm = new DataMining();
                dm.GetTeamsWithMinDiffForAndAgainstGoals(dtFootball);
            }
       }
}
}
    

