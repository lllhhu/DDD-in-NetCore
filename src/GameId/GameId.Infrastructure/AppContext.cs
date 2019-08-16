using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Infrastructure
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            //开发环境开启自动创建表结构功能
            #if DEBUG
           // this.Database.EnsureCreated();
            #endif

        }

        public DbSet<GameId.Domain.Bizoffer.Bizoffer> Bizoffer { get; set; }
        public DbSet<GameId.Domain.Order.Order> Order { get; set; }
        public DbSet<GameId.Domain.Bizoffer.Seller> Seller { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseMyCat("server=127.0.0.1; port=8066; uid=root; pwd=123456; database=blog");
        //    //.UseMyCat("server=127.0.0.1;port=8066;uid=root;pwd=123456;database=blog");
        //    //.UseDataNode("192.168.130.70", "chatrecord", "chatrecord_user", "q#@!123qaz")
        //    //.UseDataNode("192.168.130.70", "chatrecord", "chatrecord_user", "q#@!123qaz");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region 
            modelBuilder.Entity<GameId.Domain.Bizoffer.Bizoffer>().ToTable("Bizoffer");
            modelBuilder.Entity<GameId.Domain.Bizoffer.Seller>().ToTable("Seller");

            modelBuilder.Entity<GameId.Domain.Order.Order>().ToTable("Order");
            modelBuilder.Entity<GameId.Domain.Order.OrderItem>().ToTable("OrderItem");
            //modelBuilder.Entity<GameId.Domain.Order.OrderItem>().OwnsOne(c => c.BizofferInfo);//（值对象）复杂类型映射
            modelBuilder.Entity<GameId.Domain.Order.Order>().HasMany(m => m.OrderItems);// 使用简单方式配置一对多关系
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
