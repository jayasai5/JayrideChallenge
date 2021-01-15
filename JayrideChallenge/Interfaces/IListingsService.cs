using System.Threading.Tasks;
using JayrideChallenge.Models;

namespace JayrideChallenge.Interfaces
{
    public interface IListingsService
    {
        Task<ListingsVm> GetListings(int passengers);
    }
}
