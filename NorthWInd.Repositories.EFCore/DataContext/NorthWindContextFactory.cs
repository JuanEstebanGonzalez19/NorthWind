using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.DataContext
{
    class NorthWindContextFactory : 
        IDesignTimeDbContextFactory<NorthWindContext>
    {
        public NorthWindContext CreateDbContext(string[] args)
        {
            //throw new NotImplementedException();
            var OptionsBuilder =
                new DbContextOptionsBuilder<NorthWindContext>();
            OptionsBuilder.UseSqlServer(
                "Serve = (localdb) \\ mssqllocaldb;Database=NorthWindDB");
            return new NorthWindContext(OptionsBuilder.Options);
        }
    } 
}
