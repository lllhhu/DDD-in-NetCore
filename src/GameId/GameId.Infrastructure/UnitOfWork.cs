using GameId.Domain.Interface;
using GameId.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GameId.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext appContext = null;
        private readonly IMediator mediator = null;

        public UnitOfWork(AppContext appContext, IMediator mediator)
        {
            this.appContext = appContext;
            this.mediator = mediator;
        }

        public void Dispose()
        {
            if (this.appContext != null)
            {
                this.appContext.Dispose();
            }
        }

        public int SaveChanges()
        {
            var domainEntities = this.appContext.ChangeTracker.Entries<Entity>().Where(m => m.Entity.DomainEvents != null && m.Entity.DomainEvents.Any());

            var domainEvents = domainEntities.SelectMany(m => m.Entity.DomainEvents).ToList();

            domainEntities.ToList().ForEach(m => m.Entity.DomainEvents.Clear());

            foreach (var domainEvent in domainEvents)
            {
                this.mediator.Publish(domainEvent);
            }
            return this.appContext.SaveChanges();
        }
    }
}
