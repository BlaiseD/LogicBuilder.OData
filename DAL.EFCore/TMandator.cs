using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EFCore
{
    [Table("G_TMandator")]
    public class TMandator
    {

        /// <summary>
        /// Primary Key
        /// </summary>
        [Column("pkMandatorID")]
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        /// <summary>
        /// GUID
        /// </summary>
        [Column("gIdentity")]
        public Guid Identity { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Column("sName")]
        public String Name { get; set; }

        /// <summary>
        /// Mandator hat diese Buildings
        /// </summary>
        public virtual ICollection<TBuilding> Buildings { get; set; }

    }
}
