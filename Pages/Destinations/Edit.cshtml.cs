using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Web_Onetiu_Malan.Data;
using Proiect_Web_Onetiu_Malan.Models;


namespace Proiect_Web_Onetiu_Malan.Pages.Destinations
{
    [Authorize(Roles = "Admin")]
    public class EditModel : DestinationCategoriesPageModel

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

            Destination = await _context.Destination
                .Include(d => d.Country)
                .Include(d => d.City)
                .Include(d => d.DestinationCategories).ThenInclude(d => d.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            var destination =  await _context.Destination.FirstOrDefaultAsync(m => m.ID == id);
            if (destination == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Destination);
            Destination = destination;


            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "Name");
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "ID", "CityName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        /*public async Task<IActionResult> OnPostAsync()
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
    }*/
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var destinationToUpdate = await _context.Destination
            .Include(i => i.Country)
            .Include(i => i.City)
            .Include(i => i.DestinationCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (destinationToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Destination>(
            destinationToUpdate,
            "Destination",
            i => i.Title, i => i.Country,
            i => i.Price, i => i.EntryDate, i => i.CityID))
            {
                UpdateBookCategories(_context, selectedCategories, destinationToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateBookCategories(_context, selectedCategories, destinationToUpdate);
            PopulateAssignedCategoryData(_context, destinationToUpdate);
            return Page();
        }
    }
}
