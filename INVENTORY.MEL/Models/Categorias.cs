using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INVENTORY.MODEL.Models
{
    public class Categorias
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Categoria { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime Fecha { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
