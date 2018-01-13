using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HappyNation
{
    class TurnContext : ITurnContext
    {
        int _currentIdx = 0;
        IList<ICharacterContext> _characterContexts;
        ICharactersTurnContext _currentCharacterTurnContext;
        private readonly ForeignNations _foreignNations;

        public TurnContext(IList<ICharacterContext> characterContexts, ForeignNations foreignNations)
        {
            _characterContexts = characterContexts;
            _foreignNations = foreignNations;
        }

        public ICharactersTurnContext CurrentCharactersTurnContext
        {
            get { return _currentCharacterTurnContext; }
            private set
            {
                if(value != _currentCharacterTurnContext)
                {
                    _currentCharacterTurnContext = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentCharactersTurnContext"));
                }
            }
        }
        
        public void StartTurn()
        {
            PayInterest();

            StartNextCharactersTurn();
            
        }

        private void StartNextCharactersTurn()
        {
            var currentCharacter = _characterContexts[_currentIdx];
            _currentCharacterTurnContext = new CharactersTurnContext(currentCharacter);
            _currentCharacterTurnContext.Finished += HandleCharactersTurnOver;

            CharactersTurnStarted?.Invoke(this, EventArgs.Empty);
        }

        public void HandleCharactersTurnOver(object sender, EventArgs e)
        {
            _currentCharacterTurnContext.Finished -= HandleCharactersTurnOver;
            _currentIdx++;

            if (_currentIdx < _characterContexts.Count)
                StartNextCharactersTurn();
            else
                EndTurn();
        }

        public void EndTurn()
        {
            _foreignNations.BuyGoods();
            TurnEnded?.Invoke(this, EventArgs.Empty);
        }

        public void PayInterest()
        {
            foreach(var c in _characterContexts)
                c.Cash += GameConstants.InflationToEachPlayerPerTurn;
        }

        public event EventHandler CharactersTurnStarted;
        public event EventHandler TurnEnded;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}



