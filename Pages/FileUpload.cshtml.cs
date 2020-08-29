using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Describe_It.Pages
{
    public class FileUploadModel : PageModel
    {
        private IWebHostEnvironment _environment;
        public FileUploadModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task OnPostAsync()
        {
            var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            using(var filestream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(filestream);
            }
        }
    }
}
