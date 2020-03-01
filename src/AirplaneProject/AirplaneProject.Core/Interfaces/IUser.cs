using AirplaneProject.Domain.Enums;
using System.Collections.Generic;
using System.Security.Claims;

namespace AirplaneProject.Core.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();

    }
}
