using GameId.Domain.Bizoffer.Interface;
using GameId.Domain.Interface;
using GameId.Infrastructure;
using GameId.Infrastructure.Repository;
using GameId.Service;
using GameId.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MediatR;
using System.Net;

namespace GameId.Test
{
    [TestClass]
    public class BizofferAppServiceTest
    {
        IBizofferAppService bizofferAppService;
        public BizofferAppServiceTest()
        {
            //var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            //{
            //    DataSource = "127.0.0.1",
            //    InitialCatalog = "GameId",
            //    UserID = "root",
            //    Password = "123456"
            //};


            var serviceProvider = new ServiceCollection()
            .AddMediatR()
            .AddHttpClient()
            .AddLogging()
            .AddScoped<IBizofferAppService, BizofferAppService>()
            .AddScoped<IBizofferRepository, BizofferRepository>()
            .AddScoped<ISellerRepository, SellerRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddDbContext<GameId.Infrastructure.AppContext>(options =>
                        {
                            options.UseMyCat("server=127.0.0.1; port=8066; uid=root; pwd=123456; database=blog");
                        })

            .BuildServiceProvider();

            bizofferAppService = serviceProvider.GetService<IBizofferAppService>();
        }

        [TestMethod]
        public void TestCreateBizoffer()
        {
            var result = bizofferAppService.CreateBizoffer("测试发布单",100,"G1452233","暗黑","US0002","tianka2");
            Assert.AreEqual(result,"ok");
        }
    }
}
