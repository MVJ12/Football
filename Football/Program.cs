﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.DAL;
namespace Football
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamDetails td = new TeamDetails();
            td.ReadDATFile();
        }
    }
}