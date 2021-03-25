using System;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.BL.Facades;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Installers
{
    public class BlInstaller:BaseBlInstaller
    {
        public override void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMapper<UserDetailModel, UserEntity>, UserMapper>();
            serviceCollection.AddSingleton<IMapper<UserListModel, UserEntity>, UserMapper>();
            serviceCollection.AddSingleton<IMapper<NoteTypeDetailModel, NoteTypeEntity>, NoteTypeMapper>();
            serviceCollection.AddSingleton<IMapper<NoteTypeListModel, NoteTypeEntity>, NoteTypeMapper>();
            serviceCollection.AddSingleton<IMapper<NoteDetailModel, NoteEntity>, NoteMapper>();
            serviceCollection.AddSingleton<IMapper<NoteListModel, NoteEntity>, NoteMapper>();
            //TODO!!! Not working lazy loading should be fixed cause cyclic dependency is here
            serviceCollection.AddSingleton(typeof(Lazy<IMapper<ImageDetailModel, ImageEntity>>), typeof(Lazy<IMapper<ImageDetailModel, ImageEntity>>));

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

            serviceCollection.AddTransient<IDetailFacade<ImageDetailModel>, ImageFacade>();
            serviceCollection.AddTransient<IFacade<ImageDetailModel>, ImageFacade>();


            serviceCollection.AddTransient<IAuthService, AuthService>();
            serviceCollection.AddSingleton<IMediator, Mediator>();

        }
    }
}