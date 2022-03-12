using API.Entities;
using API.Requests;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IControlService
    {
        Task<Position> ProcessCommand(Command command);
    }
}