using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WA.BooksPlatform.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext")
		{
		}

		public virtual DbSet<Author> Authors { get; set; }
		public virtual DbSet<BookChapter> BookChapters { get; set; }
		public virtual DbSet<BookPart> BookParts { get; set; }
		public virtual DbSet<Book> Books { get; set; }
		public virtual DbSet<BookshelfItem> BookshelfItems { get; set; }
		public virtual DbSet<Bookshelf> Bookshelfs { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Member> Members { get; set; }
		public virtual DbSet<MessageBoardItem> MessageBoardItems { get; set; }
		public virtual DbSet<MessageBoard> MessageBoards { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Author>()
				.HasMany(e => e.Books)
				.WithRequired(e => e.Author)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Book>()
				.HasMany(e => e.BookChapters)
				.WithRequired(e => e.Book)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Book>()
				.HasMany(e => e.BookshelfItems)
				.WithRequired(e => e.Book)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Bookshelf>()
				.HasMany(e => e.BookshelfItems)
				.WithRequired(e => e.Bookshelf)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Bookshelfs)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.MessageBoardItems)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.MessageBoards)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);
		}
	}
}
