using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INVENTORY.MODEL.Models
{
    public class Comprobantes
    {

        public int ID { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
