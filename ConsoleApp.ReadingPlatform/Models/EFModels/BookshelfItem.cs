namespace ConsoleApp.ReadingPlatform.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookshelfItem
    {
        public int Id { get; set; }

        public int BookshelfId { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Bookshelf Bookshelf { get; set; }
    }
}
