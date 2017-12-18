using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.TransferModels;

namespace WebApp.Services
{
    public class ArtistService
    {
        private IArtistRepository _repository;

        public ArtistService(IArtistRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ArtistInfo>> GetAllArtists()
        {
            var artists = await _repository.ReadArtists();
            return artists.Select(artist => ExtractArtistInfo(artist)).ToList();
        }

        public async Task<ArtistDetails> GetSpecificArtist(string id)
        {
            var details = new ArtistDetails()
            {
                Id = id
            };
            return await Task.FromResult(details);
        }

        private ArtistInfo ExtractArtistInfo(Artist artist)
        {
            return new ArtistInfo()
            {
                Id = artist.Id,
                Name = artist.Name,
                ArtistUrl = artist.ArtistUrl,
                ImageUrl = artist.ImageUrl,
                Comments = artist.Comments
            };
        }
    }
}
