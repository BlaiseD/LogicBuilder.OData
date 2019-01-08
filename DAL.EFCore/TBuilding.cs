using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EFCore
{
    [Table("OB_TBuilding")]
    public class TBuilding
    {

        /// <summary>
        /// Holt oder setzt die Id
        /// </summary>
        [Column("pkBID")]
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        [Column("Identifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Identity { get; set; }

        /// <summary>
        /// Holt oder setzt den langen Namen
        /// </summary>
        [Column("sLongName")]
        public String LongName { get; set; }

        [ForeignKey("Builder")]
        public Int32 BuilderId { get; set; }

        public TBuilder Builder { get; set; }

        public TMandator Mandator { get; set; }

        [ForeignKey("Mandator")]
        [Column("fkMandatorID")]
        public Int32 MandatorId { get; set; }

    }
}
