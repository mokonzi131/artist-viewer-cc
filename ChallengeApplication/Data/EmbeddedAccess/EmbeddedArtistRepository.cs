using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Data.EmbeddedAccess
{
    internal class ArtistListWrapper
    {
        public IList<Artist> Artists { get; set; }
    }

    internal class MyContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> MyMappings { get; set; }

        public MyContractResolver()
        {
            MyMappings = new Dictionary<string, string>()
            {
                { "Id", "artist_id" },
                { "Name", "artist_name" },
                { "Handle", "artist_handle" },
                { "ArtistUrl", "artist_url" },
                { "Bio", "artist_bio" },
                { "Members", "artist_members" },
                { "Website", "artist_website" },
                { "ImageUrl", "artist_image_file" },
                { "Comments", "artist_comments" }
            };
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = MyMappings.TryGetValue(propertyName, out resolvedName);
            return resolved ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }

    public class EmbeddedArtistRepository : IArtistRepository
    {
        public async Task<IList<Artist>> ReadArtists()
        {
            var rawData = await LoadArtistsFromEmbeddedResource();
            var parsedData = ParseJsonData(rawData);
            return parsedData;
        }

        private IList<Artist> ParseJsonData(string data)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new MyContractResolver();
            return JsonConvert.DeserializeObject<ArtistListWrapper>(data, settings).Artists;
        }

        private async Task<string> LoadArtistsFromEmbeddedResource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("Data.EmbeddedAccess.artists.json");
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
