﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseValueObjectAsIdentifier.Persistence.DbContexts;

namespace UseValueObjectAsIdentifier
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            
            var dbContext = UniversityDbContextFactory.GetSqlContext();



        }
    }
}
