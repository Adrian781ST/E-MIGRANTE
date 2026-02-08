using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.Gerencia
{
    public class IndexModel : PageModel
    {
        private readonly IEmergencia _repoEmergencia;
        
        public IEnumerable<Emergencia> _ListarEmergencias { get; set; }
        
        public IndexModel(IEmergencia repoEmergencia)
        {
            _repoEmergencia = repoEmergencia;
        }
        
        public void OnGet()
        {
            _ListarEmergencias = _repoEmergencia.ListarEmergencias();
        }
    }
}
