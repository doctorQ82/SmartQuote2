
using SmartQuote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Services
{
    public abstract class BaseService 
    {
        public virtual ApplicationDbContext GetContext()
        {
            return new ApplicationDbContext();
        }
    }
}
