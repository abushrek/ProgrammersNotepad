﻿using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammersNotepad.BL.Messages.Interfaces;
using ProgrammersNotepad.BL.Services.Interfaces;

namespace ProgrammersNotepad.BL.Services
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Type, List<Delegate>> _registeredActions = new Dictionary<Type, List<Delegate>>();

        public void Register<TMessage>(Action<TMessage> action) where TMessage : IMessage
        {
            var key = typeof(TMessage);

            if (!_registeredActions.TryGetValue(key, out _))
            {
                _registeredActions[key] = new List<Delegate>();
            }

            _registeredActions[key].Add(action);
        }

        public void Send<TMessage>(TMessage message) where TMessage : IMessage
        {
            if (_registeredActions.TryGetValue(typeof(TMessage), out var actions))
            {
                foreach (var action in actions.Select(action => action as Action<TMessage>).Where(action => action != null))
                {
                    action(message);
                }
            }
        }

        public void UnRegister<TMessage>(Action<TMessage> action) where TMessage : IMessage
        {
            var key = typeof(TMessage);

            if (_registeredActions.TryGetValue(key, out var actions))
            {
                var actionList = actions.ToList();
                actionList.Remove(action);
                _registeredActions[key] = new List<Delegate>(actionList);
            }
        }
    }
}