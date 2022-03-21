using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INVENTORY.MODEL.Models
{
    public class Ventas
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Productos { get; set; }

        [MaxLength(5)]
        public string Moneda { get; set; }

        public float Descuento { get; set; }

        public float Neto { get; set; }

        public float Total { get; set; }

        public string MetodoPago { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime Fecha { get; set; }

        public int  UsuarioID { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public int ClienteID { get; set; }
        public virtual Clientes Cliente { get; set; }

        public int ProductoID { get; set; }
        public virtual Productos Producto { get; set; }

        public int ComprobanteID { get; set; }
        public virtual Comprobantes Comprobante { get; set; }
    }
}
