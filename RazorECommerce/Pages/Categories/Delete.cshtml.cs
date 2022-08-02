using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorECommerce.Data;
using RazorECommerce.Model;

namespace RazorECommerce.Pages.Categories
{
    //If we use like that, no need to write every single property bind attribute
    //[BindProperties] 
    public class DeleteModel : PageModel
    {
        public readonly ApplicationDbContext m_Db;
        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            m_Db = db;
        }

        public void OnGet(int id)
        {
            Category = m_Db.Category.Find(id);
            //Category = m_Db.Category.FirstOrDefault(x => x.Id == id);
            //Category = m_Db.Category.SingleOrDefault(x => x.Id == id);
            //Category = m_Db.Category.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = m_Db.Category.Find(Category.Id);
            if (categoryFromDb != null)
            {
                m_Db.Category.Remove(categoryFromDb);
                await m_Db.SaveChangesAsync();
                TempData["Success"] = "Template deleted successfully!";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
