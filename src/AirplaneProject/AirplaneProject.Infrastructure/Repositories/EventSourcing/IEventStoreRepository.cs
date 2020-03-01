using AirplaneProject.Core.Events;
using System;
using System.Collections.Generic;

namespace AirplaneProject.Infrastructure.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}