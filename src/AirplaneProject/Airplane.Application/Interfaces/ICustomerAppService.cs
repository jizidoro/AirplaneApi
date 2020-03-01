using System;
using System.Collections.Generic;
using AirplaneProject.Application.EventSourcedNormalizers;
using AirplaneProject.Application.ViewModels;

namespace AirplaneProject.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
