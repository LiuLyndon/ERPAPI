using GlobalLib.Models.V_EIP;
using Microsoft.EntityFrameworkCore;

// Getting Started with Entity Framework Core: Building an ASP.NET Core Application with Web API and Code First Development
// https://social.technet.microsoft.com/wiki/contents/articles/50939.getting-started-with-entity-framework-core-building-an-asp-net-core-application-with-web-api-and-code-first-development.aspx

namespace GlobalLib.DataContext
{
    public class V_EIPContext : DbContext
    {
        public V_EIPContext(DbContextOptions<V_EIPContext> options) : base(options) 
        {
        }

        public DbSet<tblUser> tblUser { get; set; }
    }
}
