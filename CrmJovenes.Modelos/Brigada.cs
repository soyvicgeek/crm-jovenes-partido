using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.Modelos
{
    public class Brigada
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es Requerido")]
        [MaxLength(100, ErrorMessage = "La Descripción sólo se compone de 100 carácteres como Máximo")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Campo Número de Personas es Requerido")]
        [MaxLength(20, ErrorMessage = "El Número de Personas sólo se compone de 20 carácteres como Máximo")]
        public string NumeroPersonas { get; set; }
        [Required(ErrorMessage = "El Campo Localidad es Requerido")]
        [MaxLength(50, ErrorMessage = "La Localidad sólo se compone de 50 carácteres como Máximo")]
        public string Localidad { get; set; }
        [Required(ErrorMessage = "El Campo Municipio es Requerido")]
        [MaxLength(50, ErrorMessage = "El Municipio sólo se compone de 50 carácteres como Máximo")]
        public string Municipio { get; set; }
        [Required(ErrorMessage = "La zona es requerida")]
        public int ZonaId { get; set; }
        [ForeignKey("ZonaId")]
        public Zona Zona { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
