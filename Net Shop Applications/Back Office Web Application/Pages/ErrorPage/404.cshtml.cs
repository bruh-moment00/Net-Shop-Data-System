using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Back_Office_Web_Application.Pages.ErrorPage
{
    public class _404Model : PageModel
    {
        public string OriginalURL { get; set; }
        public void OnGet()
        {
            var statusCode = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCode != null)
            {
                OriginalURL =
                    statusCode.OriginalPathBase
                    + statusCode.OriginalPath
                    + statusCode.OriginalQueryString;
            }
        }
    }
}
