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
            
        }
    }
}