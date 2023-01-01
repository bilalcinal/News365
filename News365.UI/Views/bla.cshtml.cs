using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace News365.UI.Views
{
    public class bla : PageModel
    {
        private readonly ILogger<bla> _logger;

        public bla(ILogger<bla> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}