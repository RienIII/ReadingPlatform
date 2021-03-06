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

[V] add Repository...
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

[V] add MembersController...
				add Action Register 註冊
				add Action RegisterConfirm 註冊確認
				add /Models/ViewModel/LoginVM.cs
				add Action Login
				add Action Logout
				add /Models/ViewMOdels/ForgetPasswordVM.cs
				add /Models/Services/UseCases/LoginCommand.cs
				add Action ForgetPassword
				會員中心 : 修改個人資料、修改密碼 
				add Action EditProfile
				add Action RestPassword
				add /Models/ViewModels/EditProfileVM.cs
				add /Models/Services/UseCases/ResetDataCommand.cs
				add /Models/ViewModels/ResetProfileVM.cs
				add /Infrastructures/Exts/ResetPasswordVMExts.cs

[V] add BooksController...
				add BookChapter.cs
				add BookChapterVM.cs
				add BookVM.cs
				add /Models/Infrastructures/Exts/BookChapterEntityExts.cs
				modify /Models/Infrastructures/Exts/BookEntityExts.cs
				add Action Index 點開書籍可以看到書籍資料
				add Action ChooseChapter 選擇章節
					add Class ChapterLink => Action DisplayChapter
				add Action Chapter 顯示章節內容
					add private Action ChapterPages 分頁用
				add private Action LordBook 找到書籍給 Index ChooseChapter Chapter 用
				modify BookEntityExts.cs
	
[V] modify HomeController... 

[V] modify MemberController, MemberService, IMemberRepository...
				Controller : add Action BecomeAuthor
					add /Models/ViewModels/AuthorVM.cs
				Service : add Method BecomeAuthor
				IRepo : add Method IsAuthorExist, BecomeAuthor

[V] /Views 畫面修改...
				modify /Views/Books 全部
				modify /Views/Home 全部

[V] add AuthorsController...
				add /Models/DTOs/CreateBookRequest.cs
				add /Models/DTOs/CreateBookResponse.cs
				add /Models/Infrastructures/Exts/AuthorEntityExts.cs
				add /Models/Infrastructures/Exts/CreateBookRequestExts.cs
				add /Models/Infrastructures/Exts/ManageAuthorBookCreateVMExts.cs
				add AuthorService	
				add IAuthorRepository
				add AuthorRepository
				add /Models/ViewModels/ManageAuthorBookCreateVM.cs
				add /Models/ViewModels/ManageAuthorBooksVM.cs
				新增書籍與新增書籍內容完成
				要開始做修改章節內容
				Controller : add Action BookChapterEdit
				AuthorService : add Method BookChapterEdit
				AuthorRepo : add Method LordChapter, BookChapterUpdate

[working on] 留言板(MessageBoard)功能或稱為評論區，評論底下有留言...
	add /Models/DTOs/CommonResponse.cs 建立通用的Response，因為有需多的Response只需要有"是否成功(bool)"和"錯誤訊息(string)"
	add /Models/Entities/MessageBoardItemEntity.cs
	add /Models/Entities/MessageBoardEntity.cs
	...
	MessageBoardService... 
		add /Models/DTOs/MessageBoardRequest.cs
		add /Models/Infrastructures/Exts/MessageBoardRequestExts.cs
		add /Models/Infrastructures/Exts/MessageBoardItemRequestExts.cs
	add /Models/Services/Core/Interfaces/IMessageBoardRepository.cs
	...
	add /Models/Infrastructures/Repositories/MessageBoardRepository.cs
		add /Models/Infrastructures/Exts/MessageBoardEntityExts.cs
		add /Models/Infrastructures/Exts/MessageBoardItemEntityExts.cs
		add /Models/Infrastructures/Exts/MessageBoardExts.cs
		add /Models/Infrastructures/Exts/MessageBoardItemExts.cs
	...
	add MessageBoardsController  
		add /Models/ViewModels/MessageBoardCreateVM.cs 同一個地方再建一個class，MessageBoardItemCreateVM.cs
		add /Models/Infrastructures/Exts/MessageBoardCreateVMExts.cs 
		add /Models/Infrastructures/Exts/MessageBoardCreateItemVMExts.cs <=================

	