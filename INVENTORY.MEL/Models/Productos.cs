using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INVENTORY.MODEL.Models
{
    public class Productos
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public int Stock { get; set; }

        public float PrecioCompra { get; set; }

        public float PrecioVenta { get; set; }

        public int Venta { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime Fecha { get; set; }

        public int CategoriaID { get; set; }
        public virtual Categorias Categoria { get; set; }

        public int ProveedorID { get; set; }
        public virtual Proveedores Proveedor { get; set; }

        public virtual ICollection<Compras> Compras { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }

    }
}
