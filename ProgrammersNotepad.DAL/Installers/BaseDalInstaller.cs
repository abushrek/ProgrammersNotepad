using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Installers.Interfaces;

namespace ProgrammersNotepad.DAL.Installers
{
    public abstract class BaseDalInstaller:IInstaller
    {
        public virtual void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProgrammersNotepadDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProgrammersNotepadDb;Trusted_Connection=True;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                }));
        }
    }
}