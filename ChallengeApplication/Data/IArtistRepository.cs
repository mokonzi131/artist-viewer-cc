using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IArtistRepository
    {
        Task<IList<Artist>> ReadArtists();
    }
}
