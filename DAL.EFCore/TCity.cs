using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EFCore
{
    [Table("TCities")]
    public class TCity
    {
        [Column("Id")]
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        /// <summary>
        /// Holt oder setzt den langen Namen
        /// </summary>
        [Column("Name")]
        public String Name { get; set; }
    }
}
