using System;
using UnityEngine;

namespace BrowserGame2D
{
    public sealed class Quest : IQuest
    {
        private readonly QuestObjectView _view;
        private readonly IQuestModel _model;

        private bool _active;

        public Quest(QuestObjectView view, IQuestModel model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        private void OnContact(LevelObjectView arg)
        {
            var completed = _model.TryComplete(arg.gameObject);
            if (completed) 
            {
                Complete();
                Debug.Log(_view.Id + " Complete QuestItem");
            }  
        }

        private void Complete()
        {
            if (!_active) return;
            _active = false;
            IsCompleted = true;
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }

        public event EventHandler<IQuest> Completed;
        public bool IsCompleted { get; private set; }

        public void Reset()
        {
            if (_active) return;
            _active = true;
            IsCompleted = false;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActivate();
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }
    }
}
