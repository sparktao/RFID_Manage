using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Tao.DB.Data
{
    public class CommonDbFactory
    {
        private static CommonDataContext dbContext;

        public static CommonDataContext CreateDbContext() 
        {
            if (dbContext == null) {
                dbContext = new CommonDataContext();
            }
            return dbContext;
        }

        public static void RemoveDbContext() 
        {
            if (dbContext != null) 
            {
                dbContext.Dispose();
                dbContext = null;
            }
        
        }

    }
}
