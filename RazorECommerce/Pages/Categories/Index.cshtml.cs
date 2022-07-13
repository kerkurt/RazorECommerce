using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorECommerce.Data;
using RazorECommerce.Model;

namespace RazorECommerce.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext m_Db;
        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            m_Db = db;
        }

        public void OnGet()
        {
            Categories = m_Db.Category;
        }
    }
}
