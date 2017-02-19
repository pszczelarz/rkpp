using System;
using System.Data.Entity;
using MongoDB.Bson;

namespace RKPP.Models
{
    public class New
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }

    public class NewDBContext : DbContext
    {
        public DbSet<New> Movies { get; set; }
    }
}