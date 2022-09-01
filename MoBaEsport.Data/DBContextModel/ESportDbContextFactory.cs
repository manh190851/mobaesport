﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.DBContextModel
{
    public class ESportDbContextFactory : IDesignTimeDbContextFactory<ESportDbContext>
    {
        public ESportDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionstring = configuration.GetConnectionString("ESportDbContext");

            var optionsBuilder = new DbContextOptionsBuilder<ESportDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            return new ESportDbContext(optionsBuilder.Options);
        }
    }
}
