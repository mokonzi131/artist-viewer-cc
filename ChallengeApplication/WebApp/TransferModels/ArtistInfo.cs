using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.TransferModels
{
    public class ArtistInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ArtistUrl { get; set; }
        public int Comments { get; set; }
    }
}
