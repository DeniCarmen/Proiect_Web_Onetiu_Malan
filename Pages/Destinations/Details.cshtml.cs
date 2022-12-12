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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext _context;

        public DetailsModel(Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext context)
        {
            _context = context;
        }

      public Destination Destination { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Destination == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination.FirstOrDefaultAsync(m => m.ID == id);
            if (destination == null)
            {
                return NotFound();
            }
            else 
            {
                Destination = destination;
            }
            return Page();
        }
    }
}
