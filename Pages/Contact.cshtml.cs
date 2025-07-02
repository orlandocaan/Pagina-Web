using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MRS.Pages
{
    public class ContactModel : PageModel
    {

        private readonly IEmailService _emailService;

        public ContactModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [BindProperty]
        public ContactFormModel ContactForm { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSendAsync()
        {
            var isSuccess = await SendEmailAsync(ContactForm);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "¡Tu mensaje se ha enviado con éxito!";
            }
            else
            {
                TempData["ErrorMessage"] = "Lo siento, un error ocurrió al enviar tu mensaje.";
            }

            return RedirectToPage();

        }

        private async Task<bool> SendEmailAsync(ContactFormModel form)
        {
            try
            {
                await _emailService.SendEmailAsync(
                    "ejemplo@dominio.com", // Dirección de destino
                    "Nuevo mensaje de contacto", // Asunto
                    $"Nombre: {form.Name}<br>Email: {form.Email}<br>Teléfono: {form.Phone}<br>Mensaje: {form.Message}" 
                );
                return true;
            }
            catch
            {
                return false;
            }
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

