using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Describe_It.Pages
{
    public class FileUploadModel : PageModel
    {
        private IHostingEnvironment _environment;
        public FileUploadModel(IHostingEnvironment environment)
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
