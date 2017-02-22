using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace RKPP.Models
{
    public class Plan
    {
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }

    public class PlanDBContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
    }
}