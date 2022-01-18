namespace WA.BooksPlatform.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bookshelfs")]
    public partial class Bookshelf
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int BookId { get; set; }

        public int MemberId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Member Member { get; set; }
    }
}
