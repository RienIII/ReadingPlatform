[V] 註冊、登入、修改個人資料與密碼(大頭照變更)、忘記密碼

[V] add BookService...
				add BookContentEntity 書籍內容
				add BookDirectoryEntity 書籍目錄 
				add BookEntity 書籍

				modify BookDirectoryEntity => BookPartEntity
				modify BookContentEntity => BookChapterEntity

[working on] add /Models/EFModel 用精靈產生

[working on] add Entities...
				add BookshelfEntity.cs 
				add AuthorEntity.cs
				add BookBasicEntity.cs

[working on] add BookshelfService書架... 
				add IBookshelfRepository
				add IBookRepository
				add /Models/DTOs/BookEntityExts.cs
				add /Models/ViewModels/BookshelfVM.cs

[working on] add BookService書籍...
	add IBookRepository
	add 
