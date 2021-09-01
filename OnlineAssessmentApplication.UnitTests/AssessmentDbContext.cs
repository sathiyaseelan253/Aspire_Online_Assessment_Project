using OnlineAssessmentApplication.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApplication.UnitTests
{
    public class AssessmentDbContext : DbContext
    {
        public AssessmentDbContext() : base("connectionStringToDB")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
