using System;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public partial class Genre
    {
        public Genre()
        {
            Track = new HashSet<Track>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}
