using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Handle { get; set; }
        public string ArtistUrl { get; set; }
        public string Bio { get; set; }
        public string Members { get; set; }
        public string Website { get; set; }
        public string ImageUrl { get; set; }
        public int Comments { get; set; }
        // TODO (mlandes) many more fields...
    }
}
