using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INVENTORY.MODEL.Models
{
    public class Usuarios
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Usuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string Clave { get; set; }

        [Required]
        [MaxLength(50)]
        public string Perfil { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        [MaxLength(10)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(50)]
        public string UltimoLogin { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
        public virtual ICollection<Compras> Compras { get; set; }

    }
}
