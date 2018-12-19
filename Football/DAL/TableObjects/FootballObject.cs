using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.DAL.TableObjects
{
    public static class FootballDS
    {
        //Team,P,W,L,D,F,A,Pts
       public static DataTable FootballTeams(DataTable initialTeamsTable)
        {
            DataTable teamsTable = FormulateTeamsTable();
            teamsTable = ValidateAndPoulateTeamsTable(initialTeamsTable, teamsTable);
            // can create more tables in data set for future....          
            
            return teamsTable;
        }

        private static DataTable FormulateTeamsTable()
        {
            DataTable teamsTable = new DataTable();
            teamsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "teamName",
                DataType = typeof(string)
            });
            teamsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "matchesPlayed",
                DataType = typeof(Int32),
                DefaultValue = 0
            });
            teamsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "matchesWon",
                DataType = typeof(Int32),
                DefaultValue = 0
            });
            teamsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "matchesLost",
                DataType = typeof(Int32),
                DefaultValue = 0
            });
            teamsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "matchesDrawn",
                DataType = typeof(Int32),
                DefaultValue = 0
            });
            teamsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "goalsFor",
                DataType = typeof(Int32),
                DefaultValue = 0
            });
            teamsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "goalsAgainst",
                DataType = typeof(Int32),
                DefaultValue = 0
            });
            teamsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "points",
                DataType = typeof(Int32),
                DefaultValue = 0
            });
            return teamsTable;
        }
        private static DataTable ValidateAndPoulateTeamsTable(DataTable initialTeamsTable, DataTable teamsTable)
        {
            foreach (DataRow teamRow in initialTeamsTable.Rows)
            {
                if(teamRow["Team"].ToString().Any(x => char.IsLetter(x))) // Check if we have one letter atleast to create a valid row
                {
                    DataColumn teamName = new DataColumn("teamName", System.Type.GetType("System.String"));
                    string initName = teamRow["Team"].ToString();                 
                    
                    // P,W,L,D,F,A,Pts    

                    int p = GetIntColumnValue(teamRow["P"].ToString());
                    int w = GetIntColumnValue(teamRow["W"].ToString());
                    int l = GetIntColumnValue(teamRow["L"].ToString());
                    int d = GetIntColumnValue(teamRow["D"].ToString());
                    int f = GetIntColumnValue(teamRow["F"].ToString());
                    int a = GetIntColumnValue(teamRow["A"].ToString());
                    int pts = GetIntColumnValue(teamRow["Pts"].ToString());
                    if(p == w+l+d) // check it total played is sum of won + lost + defeat
                    {
                        teamsTable.Rows.Add(new object[] { initName.Substring(initName.IndexOf('.') + 1),
                                                                                Convert.ToInt32(p),
                                                                                Convert.ToInt32(w),
                                                                                Convert.ToInt32(l),
                                                                                Convert.ToInt32(d),
                                                                                Convert.ToInt32(f),
                                                                                Convert.ToInt32(a),
                                                                                Convert.ToInt32(pts)});                    
                    }

                }
               
                }
                return teamsTable;
            }

        private static Int32 GetIntColumnValue(string columnValue)
        {
            Int32 test = 0;
            int.TryParse(columnValue, out test);
            return test;
        }
    }
    }

