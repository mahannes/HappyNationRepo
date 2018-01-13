using System;
using System.Collections.Generic;
using System.ComponentModel;
using HappyNation.Characters;
using HappyNation.ExploreCards;

namespace HappyNation
{
    public class GameContext : IGameContext
    {
        bool _started = false;
        bool _initialized = false;

        ForeignNations _foreignNations;
        List<ICharacterContext> _characterContexts = new List<ICharacterContext>();
        Stack<IExploreCard> _exploreCardsDeck = new Stack<IExploreCard>();
        ITurnContext _currentTurnContext; 

        public void InitializeStandard()
        {
            if (_initialized)
                throw new InvalidOperationException();

            _characterContexts.Add(new CharacterContext(Profession.Builder));
            _characterContexts.Add(new CharacterContext(Profession.Farmer));
            _characterContexts.Add(new CharacterContext(Profession.Entertainer));
            _characterContexts.Add(new CharacterContext(Profession.Doctor));
            _characterContexts.Add(new CharacterContext(Profession.Banker));

            // ToDo Initialize Foreign nations correctly
            _foreignNations = new ForeignNations(_characterContexts);

            // ToDo Initialize Explore Cards

            _initialized = true;
        }

        public void StartGame()
        {
            NextTurn();
        }

        private void NextTurn()
        {
            CurrentTurnContext = new TurnContext(_characterContexts, _foreignNations);
            CurrentTurnContext.TurnEnded += HandleTurnEnded;
            CurrentTurnContext.StartTurn();
        }

        private void HandleTurnEnded(object sender, EventArgs e)
        {
            CurrentTurnContext.TurnEnded -= HandleTurnEnded;
            NextTurn();
        }

        public ITurnContext CurrentTurnContext
        {
            get { return _currentTurnContext; }
            private set
            {
                if(_currentTurnContext != value)
                {
                    _currentTurnContext = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentTurnContext"));
                }
            }
        }

        public IEnumerable<ICharacterContext> CharacterContexts { get { return _characterContexts; } }

        public IForeignNations ForeignNations { get { return _foreignNations; } }

        public ICharactersTurnContext CurrentCharactersTurnContext;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}



