using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.Modelos
{
    public class Zona
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "El Nombre sólo se compone de 60 carácteres como Máximo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es Requerido")]
        [MaxLength(100, ErrorMessage = "La Descripción sólo se compone de 100 carácteres como Máximo")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Estado de la Zona es Requerido")]
        public bool Estado { get; set; }
    }
}
