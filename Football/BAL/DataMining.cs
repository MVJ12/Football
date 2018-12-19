using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.DAL.TableObjects;
using System.Data;


namespace Football.BAL
{
    public class DataMining
    {
        public void GetTeamsWithMinDiffForAndAgainstGoals(DataTable footballTeams)
        {
            List<String> returnValue = new List<String>();       
            var teamsInitial = (from f in footballTeams.AsEnumerable()
                                where f.Field<Int32>("matchesPlayed") > 0
                         select new
                         {
                             TeamName = f.Field<String>("teamName"),
                             Diff = Math.Abs(f.Field<Int32>("goalsFor") - f.Field<Int32>("goalsAgainst"))
                         });
         
            var teams = (from t in teamsInitial
                         let minDiff = teamsInitial.Min(m => m.Diff)
                         where t.Diff == minDiff
                         select t).ToList();
            Console.WriteLine("Team/s with a minimum difference between goals for and goals against:");
            foreach(var team in teams)
            {
                Console.WriteLine(team.TeamName);
            }
            Console.ReadLine();
        }
    }
}
