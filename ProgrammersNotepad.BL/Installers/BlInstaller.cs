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
            serviceCollection.AddTransient<IMapper<NoteTypeDetailModel, NoteTypeEntity>, NoteTypeMapper>();
            serviceCollection.AddTransient<IMapper<NoteTypeListModel, NoteTypeEntity>, NoteTypeMapper>();
            serviceCollection.AddTransient<IMapper<NoteDetailModel, NoteEntity>, NoteMapper>();
            serviceCollection.AddTransient<IMapper<NoteListModel, NoteEntity>, NoteMapper>();

            serviceCollection.AddTransient<IDetailFacade<UserDetailModel>, UserFacade>();
            serviceCollection.AddTransient<IFacade<UserListModel>, UserFacade>();
            serviceCollection.AddTransient<IUserFacade<UserListModel>, UserFacade>();
            serviceCollection.AddTransient<IUserFacade<UserDetailModel>, UserFacade>();

            serviceCollection.AddTransient<IDetailFacade<NoteTypeDetailModel>, NoteTypeFacade>();
            serviceCollection.AddTransient<IFacade<NoteTypeListModel>, NoteTypeFacade>();
            serviceCollection.AddTransient<INoteTypeFacade, NoteTypeFacade>();

            serviceCollection.AddTransient<IDetailFacade<NoteDetailModel>, NoteFacade>();
            serviceCollection.AddTransient<IFacade<NoteListModel>, NoteFacade>();
            serviceCollection.AddTransient<INoteFacade, NoteFacade>();

            serviceCollection.AddTransient<IAuthService, AuthService>();
            serviceCollection.AddSingleton<IMediator, Mediator>();

        }
    }
}