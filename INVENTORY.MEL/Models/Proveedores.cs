using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INVENTORY.MODEL.Models
{
    public class Proveedores
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Direccion { get; set; }

        [MaxLength(10)]
        public string Celular { get; set; }

        [MaxLength(50)]
        public string Correo { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
