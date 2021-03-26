using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.DbContext
{
    public interface IDbContextFactory
    {
        ProgrammersNotepadDbContext CreateDbContext();
    }
}