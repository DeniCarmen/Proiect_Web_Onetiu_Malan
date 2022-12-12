using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Web_Onetiu_Malan.Data;
using Proiect_Web_Onetiu_Malan.Models;

namespace Proiect_Web_Onetiu_Malan.Pages.Destinations
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext _context;

        public EditModel(Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Destination Destination { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Destination == null)
            {
                return NotFound();
            }

            var destination =  await _context.Destination.FirstOrDefaultAsync(m => m.ID == id);
            if (destination == null)
            {
                return NotFound();
            }
            Destination = destination;

            ViewData["CityID"] = new SelectList(_context.Set<City>(), "ID", "CityName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Destination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationExists(Destination.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DestinationExists(int id)
        {
          return _context.Destination.Any(e => e.ID == id);
        }
    }
}
