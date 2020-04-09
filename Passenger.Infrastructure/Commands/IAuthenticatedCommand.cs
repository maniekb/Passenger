using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}