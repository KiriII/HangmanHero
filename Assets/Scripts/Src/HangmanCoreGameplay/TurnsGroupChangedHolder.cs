using System.Collections;
using System.Collections.Generic;
using System;
namespace Src.HangmanCoreGameplay
{
    internal class TurnsGroupChangedHolder
    {
        private event Action<char> _turnGroupChanged;
        private List<ITurnsGroupChangedListener> _turnsGroupChangedListeners;

        public TurnsGroupChangedHolder(params ITurnsGroupChangedListener[] listeners)
        {
            _turnsGroupChangedListeners = new List<ITurnsGroupChangedListener>();
            
            foreach (var listener in listeners)
            {
                EnableListener(listener);
                _turnsGroupChangedListeners.Add(listener);
            }
        }

        public void EnableListener(ITurnsGroupChangedListener listener)
        {
            _turnGroupChanged += listener.UpdateValuesAfterTurn;
        }

        public void DisableListener(ITurnsGroupChangedListener listener)
        {
            _turnGroupChanged -= listener.UpdateValuesAfterTurn;
        }

        public void OnTurnGroupChanged(char symbol)
        {
            _turnGroupChanged?.Invoke(symbol);
        }

        public Action<char> GetTurnGroupChanged()
        {
            return _turnGroupChanged;
        }
    }
}
