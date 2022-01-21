[V] 註冊、登入、修改個人資料與密碼(大頭照變更)、忘記密碼

[V] add BookService...
				add BookContentEntity 書籍內容
				add BookDirectoryEntity 書籍目錄 
				add BookEntity 書籍

				modify BookDirectoryEntity => BookPartEntity : 暫時放棄
				modify BookContentEntity => BookChapterEntity

[V] add /Models/EFModel 用精靈產生

[V] add Entities...
				add BookshelfEntity.cs  書架用AggregateRoot 聚合
				add BookshelfItemEntity.cs
				add AuthorEntity.cs
				add BookBasicEntity.cs 只呈現書籍基本資料，像是封面圖、書名、作者、字數與簡介(15字左右)

[V] add BookshelfService書架... 
				add IBookshelfRepository
				add IBookRepository
				add /Models/DTOs/BookEntityExts.cs
				add /Models/ViewModels/BookshelfVM.cs

[V] add /Models/Infrastructurse/ForPages.cs 分頁用

[V] add BookService書籍...
				add IBookRepository 因為排序條件不同所以在Controller決定需要用哪一個interface
				add IBookRankRepository 繼承 IBookRepository : 呈現排行用
				add IBookHomeRepository 繼承 IBookRepository : 呈現首頁用
				add IBookSearchRepository 繼承 IBookRepository : 呈現 搜尋、查詢 書籍用
				add /Models/ViewModels/BookHomeVM.cs
				add /Models/ViewModels/BookRankVM.cs
				add /Models/ViewModels/BookSearchVM.cs

[working on] add Repository...
				add MemberRepository
				add BookshelfRepository
					add /Models/Infrastructures/Exts/BookshelfExts.cs
					add /Models/Infrastructures/Exts/BookshelfEntityExts.cs
					add /Models/Infrastructures/Exts/BookshelfItemEntityExts.cs
				add BookRankRepository 
				add BookHomeRepository 
				add BookSearchRepository 
				add BookRepository 因為重複程式碼太多 
					所以 BookRankRepository、BookHomeRepository、BookSearchRepository 
					都呼叫 BookRepository 
				modify IBookRepository, BookService
					add BookRepositoryEntity 用來裝搜尋結果的內容，如果不用這個裝起來Repository的參數會很長

[V] 新建測試專案 TestProject.ReadingPlatform...
				add /Models/Services/Core/MemberServiceTest.cs