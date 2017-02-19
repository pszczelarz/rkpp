using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RKPP.Models
{
    public class New
    {
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public string Date { get; set; }
    }

    public class NewDBContext : DbContext
    {
        public DbSet<New> News { get; set; }
    }
}