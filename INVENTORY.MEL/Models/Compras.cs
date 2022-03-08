using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INVENTORY.MODEL.Models
{
    public class Compras
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Productos { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha { get; set; }

        public int UsuarioID { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public int ProductoID { get; set; }
        public virtual Productos Producto { get; set; }
    }
}
