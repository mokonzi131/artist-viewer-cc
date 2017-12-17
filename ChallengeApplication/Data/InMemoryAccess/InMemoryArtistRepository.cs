using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;

namespace Data.InMemoryAccess
{
    public class InMemoryArtistRepository : IArtistRepository
    {
        public async Task<IList<Artist>> ReadArtists()
        {
            throw new System.NotImplementedException();
        }
    }
}
