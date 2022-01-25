[V] ���U�B�n�J�B�ק�ӤH��ƻP�K�X(�j�Y���ܧ�)�B�ѰO�K�X

[V] add BookService...
				add BookContentEntity ���y���e
				add BookDirectoryEntity ���y�ؿ� 
				add BookEntity ���y

				modify BookDirectoryEntity => BookPartEntity : �Ȯɩ��
				modify BookContentEntity => BookChapterEntity

[V] add /Models/EFModel �κ��F����

[V] add Entities...
				add BookshelfEntity.cs  �Ѭ[��AggregateRoot �E�X
				add BookshelfItemEntity.cs
				add AuthorEntity.cs
				add BookBasicEntity.cs �u�e�{���y�򥻸�ơA���O�ʭ��ϡB�ѦW�B�@�̡B�r�ƻP²��(15�r���k)

[V] add BookshelfService�Ѭ[... 
				add IBookshelfRepository
				add IBookRepository
				add /Models/DTOs/BookEntityExts.cs
				add /Models/ViewModels/BookshelfVM.cs

[V] add /Models/Infrastructurse/ForPages.cs ������

[V] add BookService���y...
				add IBookRepository �]���ƧǱ��󤣦P�ҥH�bController�M�w�ݭn�έ��@��interface
				add IBookRankRepository �~�� IBookRepository : �e�{�Ʀ��
				add IBookHomeRepository �~�� IBookRepository : �e�{������
				add IBookSearchRepository �~�� IBookRepository : �e�{ �j�M�B�d�� ���y��
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
				add BookRepository �]�����Ƶ{���X�Ӧh 
					�ҥH BookRankRepository�BBookHomeRepository�BBookSearchRepository 
					���I�s BookRepository 
				modify IBookRepository, BookService
					add BookRepositoryEntity �ΨӸ˷j�M���G�����e�A�p�G���γo�Ӹ˰_��Repository���ѼƷ|�ܪ�

[V] �s�ش��ձM�� TestProject.ReadingPlatform...
				add /Models/Services/Core/MemberServiceTest.cs

[V] add MembersController...
				add Action Register ���U
				add Action RegisterConfirm ���U�T�{
				add /Models/ViewModel/LoginVM.cs
				add Action Login
				add Action Logout
				add /Models/ViewMOdels/ForgetPasswordVM.cs
				add /Models/Services/UseCases/LoginCommand.cs
				add Action ForgetPassword
				�|������ : �ק�ӤH��ơB�ק�K�X <=====
				add Action EditProfile
				add Action RestPassword
				add /Models/ViewModels/EditProfileVM.cs
				add /Models/Services/UseCases/ResetDataCommand.cs
				add /Models/ViewModels/ResetProfileVM.cs
				add /Infrastructures/Exts/ResetPasswordVMExts.cs

[working on] add BooksController...
	add BookChapter.cs
	add BookChapterVM.cs
	add BookVM.cs
	add /Models/Infrastructures/Exts/BookChapterEntityExts.cs
	modify /Models/Infrastructures/Exts/BookEntityExts.cs
	add Action Index �I�}���y�i�H�ݨ���y���
	add Action ChooseChapter ��ܳ��`
		add Class ChapterLink => Action DisplayChapter
	add Action Chapter ��ܳ��`���e
		add private Action ChapterPages ������
	add private Action LordBook �����y�� Index ChooseChapter Chapter ��
	modify BookEntityExts.cs
	
