using System;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.BL.Facades;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Common.Extensions;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.Models.Interfaces.Image;
using ProgrammersNotepad.Models.Interfaces.Note;
using ProgrammersNotepad.Models.Interfaces.NoteType;
using ProgrammersNotepad.Models.Interfaces.User;
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
            serviceCollection.AddSingleton<IMapper<ImageListModel, ImageEntity>, ImageMapper>();
            serviceCollection.AddSingleton<IMapper<ImageDetailModel, ImageEntity>, ImageMapper>();

            serviceCollection.AddTransient<IDetailFacade<UserDetailModel>, UserFacade<UserDetailModel>>();
            serviceCollection.AddTransient<IDetailFacade<UserListModel>, UserFacade<UserListModel>>();
            serviceCollection.AddTransient<IFacade<UserDetailModel>, UserFacade<UserDetailModel>>();
            serviceCollection.AddTransient<IFacade<UserListModel>, UserFacade<UserListModel>>();
            serviceCollection.AddTransient<IUserFacade<UserDetailModel>, UserFacade<UserDetailModel>>();
            serviceCollection.AddTransient<IUserFacade<UserListModel>, UserFacade<UserListModel>>();

            serviceCollection.AddTransient<IDetailFacade<NoteTypeDetailModel>, NoteTypeFacade<NoteTypeDetailModel>>();
            serviceCollection.AddTransient<IDetailFacade<NoteTypeListModel>, NoteTypeFacade<NoteTypeListModel>>();
            serviceCollection.AddTransient<IFacade<NoteTypeDetailModel>, NoteTypeFacade<NoteTypeDetailModel>>();
            serviceCollection.AddTransient<IFacade<NoteTypeListModel>, NoteTypeFacade<NoteTypeListModel>>();
            serviceCollection.AddTransient<INoteTypeFacade<NoteTypeDetailModel>, NoteTypeFacade<NoteTypeDetailModel>>();
            serviceCollection.AddTransient<INoteTypeFacade<NoteTypeListModel>, NoteTypeFacade<NoteTypeListModel>>();

            serviceCollection.AddTransient<IDetailFacade<NoteDetailModel>, NoteFacade<NoteDetailModel>>();
            serviceCollection.AddTransient<IDetailFacade<NoteListModel>, NoteFacade<NoteListModel>>();
            serviceCollection.AddTransient<IFacade<NoteDetailModel>, NoteFacade<NoteDetailModel>>();
            serviceCollection.AddTransient<IFacade<NoteListModel>, NoteFacade<NoteListModel>>();
            serviceCollection.AddTransient<INoteFacade<NoteDetailModel>, NoteFacade<NoteDetailModel>>();
            serviceCollection.AddTransient<INoteFacade<NoteListModel>, NoteFacade<NoteListModel>>();

            serviceCollection.AddTransient<IDetailFacade<ImageDetailModel>, ImageFacade<ImageDetailModel>>();
            serviceCollection.AddTransient<IDetailFacade<ImageListModel>, ImageFacade<ImageListModel>>();
            serviceCollection.AddTransient<IFacade<ImageDetailModel>, ImageFacade<ImageDetailModel>>();
            serviceCollection.AddTransient<IFacade<ImageListModel>, ImageFacade<ImageListModel>>();
            serviceCollection.AddTransient<IImageFacade<ImageDetailModel>, ImageFacade<ImageDetailModel>>();
            serviceCollection.AddTransient<IImageFacade<ImageListModel>, ImageFacade<ImageListModel>>();

            serviceCollection.AddTransient<IAuthService, AuthService>();
            serviceCollection.AddSingleton<IMediator, Mediator>();

        }
    }
}