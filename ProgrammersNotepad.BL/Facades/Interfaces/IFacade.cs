﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface IFacade<TModel> where TModel : IModel
    {
        IList<TModel> GetAll();
        Task<IList<TModel>> GetAllAsync(CancellationToken token = default);
        TModel GetById(Guid id);
        Task<TModel> GetByIdAsync(Guid id, CancellationToken token = default);
        bool ModelExists(Guid id);
    }
}