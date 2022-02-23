namespace WA.BooksPlatform.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MessageBoardItem
    {
        public int Id { get; set; }

        public int MessageBoardId { get; set; }

        public int MemberId { get; set; }

        [Required]
        [StringLength(500)]
        public string Chapter { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual Member Member { get; set; }

        public virtual MessageBoard MessageBoard { get; set; }
    }
}
