﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.Modelos.ViewModels
{
    public class BrigadaVM
    {
        public Brigada Brigada { get; set; }
        public IEnumerable<SelectListItem> ZonaLista { get; set; }
    }
}
