using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Models.DataContext
{
    public class IssueDataContext : DbContext
    {
        public IssueDataContext(DbContextOptions<IssueDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Issue> Issues { get; set; }
    }
}