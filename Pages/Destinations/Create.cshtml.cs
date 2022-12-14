using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Web_Onetiu_Malan.Data;
using Proiect_Web_Onetiu_Malan.Models;

namespace Proiect_Web_Onetiu_Malan.Pages.Destinations
{
    public class CreateModel : DestinationCategoriesPageModel
    {
        private readonly Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext _context;

        public CreateModel(Proiect_Web_Onetiu_Malan.Data.Proiect_Web_Onetiu_MalanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "Name");
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "ID", "CityName");
            var destination = new Destination();
            destination.DestinationCategories = new List<DestinationCategory>();
            PopulateAssignedCategoryData(_context, destination);
            return Page();
        }

        [BindProperty]
        public Destination Destination { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /*public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Destination.Add(Destination);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newDestination = new Destination();
            if (selectedCategories != null)
            {
                newDestination.DestinationCategories = new List<DestinationCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new DestinationCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newDestination.DestinationCategories.Add(catToAdd);
                }
            }
            //Destination.DestinationCategories = newDestination.DestinationCategories;
            
            _context.Destination.Add(newDestination);
             await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newDestination);
            return Page();
        }
    }
}