using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Info.Models
{
   public partial class cosenEntities : DbContext
    {
       public DbSet<research_application_tb> infos { get; set; }
    }
}