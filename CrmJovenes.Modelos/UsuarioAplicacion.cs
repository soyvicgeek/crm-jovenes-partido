using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.Modelos
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [MaxLength(80, ErrorMessage = "Máximo 80 Carácteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Los Apellidos son requeridos")]
        [MaxLength(80, ErrorMessage = "Máximo 80 Carácteres")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "La Dirección es Requerdida")]
        [MaxLength(200, ErrorMessage = "Máximo 200 Carácteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "La Ciudad es Requerdida")]
        [MaxLength(60, ErrorMessage = "Máximo 60 Carácteres")]
        public string Ciudad { get; set; }
        public string ImagenUrl { get; set; }
        [Required(ErrorMessage = "El Estado es Requerido")]
        [MaxLength(60, ErrorMessage = "Máximo 60 Carácteres")]
        public string Estado { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
