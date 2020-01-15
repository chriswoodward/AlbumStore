using AlbumStore.Core;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace AlbumStore.Data
{
    public class SqlAlbumData : IAlbumData
    {
        private readonly AlbumStoreDbContext dbContext;

        public SqlAlbumData(AlbumStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<Album> GetAll()
        {
            return from x in dbContext.Albums
                   orderby x.Title
                   select x;

        }
    }
}
