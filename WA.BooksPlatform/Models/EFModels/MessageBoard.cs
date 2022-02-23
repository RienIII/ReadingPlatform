namespace WA.BooksPlatform.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MessageBoard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MessageBoard()
        {
            MessageBoardItems = new HashSet<MessageBoardItem>();
        }

        public int Id { get; set; }

        public int BookId { get; set; }

        public int MemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Chapter { get; set; }

        public DateTime CreateTime { get; set; }

        public int? Good { get; set; }

        public int? Bad { get; set; }

        public virtual Book Book { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageBoardItem> MessageBoardItems { get; set; }
    }
}
