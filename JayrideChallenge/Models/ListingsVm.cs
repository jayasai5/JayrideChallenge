using System.Collections.Generic;

namespace JayrideChallenge.Models
{
    public class ListingsVm
    {
        public int Total { get; set; }
        public IList<Listing> Listings { get; set; }
    }
}
