namespace WA.BooksPlatform.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            BookChapters = new HashSet<BookChapter>();
            BookshelfItems = new HashSet<BookshelfItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000)]
        public string Blurb { get; set; }

        [StringLength(40)]
        public string ImageFileName { get; set; }

        public int AuthorId { get; set; }

        public int? CategoryId { get; set; }

        public int Clicks { get; set; }

        public int Likes { get; set; }

        public int Collections { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public int TotalWord { get; set; }

        public bool Status { get; set; }

        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookChapter> BookChapters { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookshelfItem> BookshelfItems { get; set; }
    }
}
