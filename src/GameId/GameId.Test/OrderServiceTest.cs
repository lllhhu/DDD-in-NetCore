using GameId.Domain.Bizoffer.Interface;
using GameId.Domain.Interface;
using GameId.Domain.Order;
using GameId.Domain.Order.Interface;
using GameId.Infrastructure;
using GameId.Infrastructure.Gateway;
using GameId.Infrastructure.Repository;
using GameId.Service;
using GameId.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Data.SqlClient;
using MediatR;
using Moq;

namespace GameId.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        IOrderAppService orderAppService;
        IPlaceOrderService placeOrderService;

        public OrderServiceTest()
        {
            //var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            //{
            //    DataSource = "(local)",
            //    InitialCatalog = "GameId",
            //    UserID = "sa",
            //    Password = "q#@!123q"
            //};

            var mockSecurityService = new Mock<ISecurityService>();
            mockSecurityService.Setup(foo => foo.IsExistsBlackList("us001")).Returns(false);

            var serviceProvider = new ServiceCollection()
     .AddLogging()
    .AddHttpClient()
    .AddMediatR()
    .AddScoped<IBizofferAppService, BizofferAppService>()
            .AddScoped<IBizofferRepository, BizofferRepository>()
            .AddScoped<IOrderAppService, OrderAppService>()
            .AddScoped<IPlaceOrderService, PlaceOrderService>()
            .AddScoped<IBizofferService, BizofferServiceClient>()
            .AddScoped<ISellerRepository,SellerRepository>()
            //.AddScoped<ISecurityService,SecurityServiceClient>()
            .AddScoped(typeof(ISecurityService), sp => mockSecurityService.Object)
             .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
                        .AddDbContext<GameId.Infrastructure.AppContext>(options =>
                        {
                            //options.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
                        })
     .BuildServiceProvider();

            orderAppService = serviceProvider.GetService<IOrderAppService>();
            placeOrderService = serviceProvider.GetService<IPlaceOrderService>();
        }

        [TestMethod]
        public void TestPlaceOrder()
        {
            //var mockSecurityService = new Mock<ISecurityService>();
            //mockSecurityService.Setup(foo => foo.IsExistsBlackList("us001")).Returns(false);

            var result = orderAppService.PlaceOrder("2645f14e-058b-4f46-96c7-50e0dc3dddbf", "us001","name1");
            StringAssert.Equals(result,"ok");
        }

        [TestMethod]
        public void TestPayedOrder()
        {
            orderAppService.PayedOrder("fds");
        }
    }
}
