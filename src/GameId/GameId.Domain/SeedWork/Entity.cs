using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.SeedWork
{
    public class Entity
    {
        private List<INotification> domainEvents;
        public List<INotification> DomainEvents => domainEvents;


        public void AddDomainEvent(INotification eventItem)
        {
            domainEvents = domainEvents ?? new List<INotification>();
            domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            if (domainEvents is null) return;
            domainEvents.Remove(eventItem);
        }
    }
}
