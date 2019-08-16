using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Blogs
    {

        public long Id { get; set; }

        public string Title { get; set; }

        //public string Content { get; set; }

        //public DateTime Time { get; set; }

        ///public JsonObject<List<string>> Tags { get; set; }
    }

    public class SampleContext : DbContext
    {
        public DbSet<Blogs> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseMyCat("server=127.0.0.1;port=8066;uid=root;pwd=123456;database=blog");
            //.UseDataNode("192.168.130.70", "chatrecord", "chatrecord_user", "q#@!123qaz")
            //.UseDataNode("192.168.130.70", "chatrecord", "chatrecord_user", "q#@!123qaz");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var DB = new SampleContext();
            //DB.Database.EnsureCreated();
            //for (var i = 0; i < 50; i++)
            DB.Blogs.Add(new Blogs { Id = 7878, Title = "Hello" });
            DB.SaveChanges();
            Console.WriteLine(DB.Blogs.Count());
            Console.Read();
        }
    }
}

