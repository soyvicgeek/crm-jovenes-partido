using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.Modelos
{
    public class Afiliado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [MaxLength(80, ErrorMessage = "Máximo 80 Carácteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        [MaxLength(40, ErrorMessage = "Máximo 40 Carácteres")]
        public string ApePat { get; set; }
        [Required(ErrorMessage = "El Apellido Materno es requerido")]
        [MaxLength(40, ErrorMessage = "Máximo 40 Carácteres")]
        public string ApeMat { get; set; }
        [Required(ErrorMessage = "La Edad es requerida")]
        [MaxLength(10, ErrorMessage = "Máximo 10 Carácteres")]
        public string Edad { get; set; }
        [Required(ErrorMessage = "El Teléfono es requerdo")]
        [MaxLength(20, ErrorMessage = "Máximo 20 Carácteres")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La Calle es requerida")]
        [MaxLength(50, ErrorMessage = "Máximo 50 Carácteres")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "El Número es requerido")]
        [MaxLength(10, ErrorMessage = "Máximo 10 Carácteres")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "La Colonia es requerida")]
        [MaxLength(25, ErrorMessage = "Máximo 25 Carácteres")]
        public string Colonia { get; set; }
        [Required(ErrorMessage = "El Municipio es requerido")]
        [MaxLength(40, ErrorMessage = "Máximo 40 Carácteres")]
        public string Municipio { get; set; }
        [Required(ErrorMessage = "El Estado es requerido")]
        [MaxLength(40, ErrorMessage = "Máximo 40 Carácteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La zona es requerida")]
        public int ZonaId { get; set; }
        [ForeignKey("ZonaId")]
        public Zona Zona { get; set; }

        [Required]
        public string UsuarioAplicacionId { get; set; }
        [ForeignKey("UsuarioAplicacionId")]
        public UsuarioAplicacion UsuarioAplicacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
