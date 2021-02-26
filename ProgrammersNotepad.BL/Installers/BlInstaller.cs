using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.BL.Facades;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Installers.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Installers
{
    public class BlInstaller:BaseBlInstaller
    {
        public override void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMapper<UserDetailModel, UserEntity>, UserMapper>();
            serviceCollection.AddTransient<IMapper<UserListModel, UserEntity>, UserMapper>();
            serviceCollection.AddTransient<IMapper<LanguageDetailModel, LanguageEntity>, LanguageMapper>();
            serviceCollection.AddTransient<IMapper<LanguageListModel, LanguageEntity>, LanguageMapper>();
            serviceCollection.AddTransient<IMapper<NoteDetailModel, NoteEntity>, NoteMapper>();
            serviceCollection.AddTransient<IMapper<NoteListModel, NoteEntity>, NoteMapper>();
            serviceCollection.AddTransient<IMapper<LanguageNoteDetailModel, LanguageNoteEntity>, LanguageNoteMapper>();
            serviceCollection.AddTransient<IMapper<LanguageNoteListModel, LanguageNoteEntity>, LanguageNoteMapper>();

            serviceCollection.AddTransient<IDetailFacade<UserDetailModel>, UserFacade>();
            serviceCollection.AddTransient<IFacade<UserListModel>, UserFacade>();
            serviceCollection.AddTransient<IDetailFacade<LanguageDetailModel>, LanguageFacade>();
            serviceCollection.AddTransient<IFacade<LanguageListModel>, LanguageFacade>();
            serviceCollection.AddTransient<IDetailFacade<NoteDetailModel>, NoteFacade>();
            serviceCollection.AddTransient<IFacade<NoteListModel>, NoteFacade>();
            serviceCollection.AddTransient<IDetailFacade<LanguageNoteDetailModel>, LanguageNoteFacade>();
            serviceCollection.AddTransient<IFacade<LanguageNoteListModel>, LanguageNoteFacade>();
            serviceCollection.AddTransient<IAuthService, AuthService>();
        }
    }
}