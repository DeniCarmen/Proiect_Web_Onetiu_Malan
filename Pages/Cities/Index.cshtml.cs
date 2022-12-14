using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Web_Onetiu_Malan.Data;
using Proiect_Web_Onetiu_Malan.Models;
using Proiect_Web_Onetiu_Malan.Models.ViewModels;

namespace Proiect_Web_Onetiu_Malan.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext _context;

        public IndexModel(Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; } = default!;

        public CityIndexData CityData { get; set; }
        public int CityID { get; set; }
        public int DestinationID { get; set; }
        public async Task OnGetAsync(int? id, int? destinationID)
        {
            CityData = new CityIndexData();
            CityData.Cities = await _context.City
            .Include(i => i.Destinations)
            //.ThenInclude(c => c.Country)
            .OrderBy(i => i.CityName)
            .ToListAsync();
            if (id != null)
            {
                CityID = id.Value;
                City city = CityData.Cities
                .Where(i => i.ID == id.Value).Single();
                CityData.Destinations = city.Destinations;
            }
        }

      /*  public async Task OnGetAsync()
        {
            if (_context.City != null)
            {
                City = await _context.City.ToListAsync();
            }
        }*/
    }
}
