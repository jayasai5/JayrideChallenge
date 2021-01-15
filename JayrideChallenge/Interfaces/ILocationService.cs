using System.Threading.Tasks;
using JayrideChallenge.Models;

namespace JayrideChallenge.Interfaces
{
    public interface ILocationService
    {
        Task<Location> SearchIpLocation(IPDetails ip);
    }
}
