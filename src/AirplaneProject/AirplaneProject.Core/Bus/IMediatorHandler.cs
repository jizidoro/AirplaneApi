using System.Threading.Tasks;
using AirplaneProject.Core.Commands;
using AirplaneProject.Core.Events;


namespace AirplaneProject.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
