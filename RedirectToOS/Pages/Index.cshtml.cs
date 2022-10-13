using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RedirectToOS.Pages
{
    public class IndexModel : PageModel
    {
       
        public void OnGet()
        {
            Response.Redirect("https://object.social");
        }
    }
}