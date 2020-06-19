
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlbumStore.Pages.Albums
{



    public class IndexModel : PageModel
    {
        private readonly AlbumStore.Entities.AlbumStoreDbContext _context;

        [BindProperty(SupportsGet = true)]
        public string TitleFilter { get; set; }

        public IndexModel(AlbumStore.Entities.AlbumStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AlbumListItem> Albums { get; set; }

        public class AlbumListItem
        {
            public int AlbumId { get; set; }
            public string Title { get; set; }           
            public string ReferenceNumber { get; set; }
            public string Artist { get; set; }
        }

        public void OnGet()
        {
            var query = _context.Albums.AsQueryable();

            if (!string.IsNullOrWhiteSpace(TitleFilter))
            {
                query = query.Where(x => x.Title.Contains(TitleFilter));
            }

            Albums = query.Include(x => x.Artist)
                          .OrderBy(x => x.Title)
                          .Select(x => new AlbumListItem
                                            {
                                                AlbumId = x.AlbumId,
                                                Title = x.Title,
                                                Artist = x.Artist.Name,
                                                ReferenceNumber = x.ReferenceNumber
                                            });
        }
    }
}
