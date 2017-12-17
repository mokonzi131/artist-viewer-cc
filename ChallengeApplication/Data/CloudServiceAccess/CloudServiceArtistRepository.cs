using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data.CloudServiceAccess
{
    class CloudServiceArtistRepository : IArtistRepository
    {
        public async Task<IList<Artist>> ReadArtists()
        {
            throw new NotImplementedException();
        }
    }
}
