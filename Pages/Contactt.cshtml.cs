using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MRS.Pages
{
    public class ContacttModel : PageModel
    {
        [BindProperty]
        public ContactFormModel ContactForm { get; set; }

        public IActionResult OnPostSend()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Procesar el formulario
            TempData["SuccessMessage"] = "Mensaje enviado con éxito.";
            return RedirectToPage();
        }

        public class ContactFormModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Message { get; set; }
        }
    }
}
