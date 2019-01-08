using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EFCore
{
    [Table("TBuilders")]
    public class TBuilder
    {
        [Column("Id")]
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        /// <summary>
        /// Holt oder setzt den langen Namen
        /// </summary>
        [Column("Name")]
        public String Name { get; set; }

        [ForeignKey("City")]
        public Int32 CityId { get; set; }

        public TCity City { get; set; }
    }
}
