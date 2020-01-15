using AlbumStore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumStore.Data
{
    public interface IAlbumData
    {
        IEnumerable<Album> GetAll();
    }
}
