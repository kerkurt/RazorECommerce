using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorECommerce.Data;
using RazorECommerce.Model;

namespace RazorECommerce.Pages.Categories
{
    //If we use like that, no need to write every single property bind attribute
    //[BindProperties] 
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext m_Db;
        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The 'DisplayOrder' cannot exactly match the 'Name'.");
            }
            if (ModelState.IsValid)
            {
                //If there will be multiple post action methods, name can be like "OnPostCreate", "OnPostEdit" etc.
                m_Db.Category.Update(Category);
                await m_Db.SaveChangesAsync();
                TempData["Success"] = "Template updated successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
