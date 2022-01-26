namespace WA.BooksPlatform.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookChapter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Artical { get; set; }

        public int WordCount { get; set; }

        public int BookId { get; set; }

        public int Status { get; set; }

        public DateTime? CreateTime { get; set; }

        public virtual Book Book { get; set; }
    }
}
