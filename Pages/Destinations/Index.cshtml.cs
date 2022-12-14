using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Web_Onetiu_Malan.Data;
using Proiect_Web_Onetiu_Malan.Models;

namespace Proiect_Web_Onetiu_Malan.Pages.Destinations
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext _context;

        public IndexModel(Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext context)
        {
            _context = context;
        }

        public IList<Destination> Destination { get; set; } = default!;
        public DestinationData DestinationD { get; set; }
        public int DestinationID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string CitySort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            DestinationD = new DestinationData();
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            CitySort = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
            CurrentFilter = searchString;

            DestinationD.Destinations = await _context.Destination
            .Include(d => d.City)
            .Include(d => d.DestinationCategories)
            .ThenInclude(d => d.Category)
            .AsNoTracking()
            .OrderBy(d => d.Title)
            .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                DestinationD.Destinations = DestinationD.Destinations.Where(s => s.City.CityName.Contains(searchString)

               || s.City.CityName.Contains(searchString)
               || s.Title.Contains(searchString));
                if (id != null)
                {
                    DestinationID = id.Value;
                    Destination destination = DestinationD.Destinations
                    .Where(i => i.ID == id.Value).Single();
                    DestinationD.Categories = destination.DestinationCategories.Select(s => s.Category);
                }
                switch (sortOrder)
                {
                    case "title_desc":
                        DestinationD.Destinations = DestinationD.Destinations.OrderByDescending(s =>
                       s.Title);
                        break;
                    case "author_desc":
                        DestinationD.Destinations = DestinationD.Destinations.OrderByDescending(s =>
                       s.City.CityName);
                        break;
                }
            }

            /*public async Task OnGetAsync()
            {
                if (_context.Destination != null)
                {
                    Destination = await _context.Destination
                        .Include(d=>d.City)
                        .ToListAsync();
                }
            }*/
        }
    }
}
