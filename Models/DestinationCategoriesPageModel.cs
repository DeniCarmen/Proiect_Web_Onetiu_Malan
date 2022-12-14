using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Web_Onetiu_Malan.Data;
namespace Proiect_Web_Onetiu_Malan.Models
{
    public class DestinationCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_Web_Onetiu_MalanContext context,Destination destination)
        {
            var allCategories = context.Category;
            var destinationCategories = new HashSet<int>(
            destination.DestinationCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = destinationCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(Proiect_Web_Onetiu_MalanContext context,
        string[] selectedCategories, Destination destinationToUpdate)
        {
            if (selectedCategories == null)
            {
                destinationToUpdate.DestinationCategories = new List<DestinationCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var destinationCategories = new HashSet<int>
            (destinationToUpdate.DestinationCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!destinationCategories.Contains(cat.ID))
                    {
                        destinationToUpdate.DestinationCategories.Add(
                        new DestinationCategory
                        {
                            DestinationID = destinationToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (destinationCategories.Contains(cat.ID))
                    {
                        DestinationCategory courseToRemove
                        = destinationToUpdate
                        .DestinationCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
