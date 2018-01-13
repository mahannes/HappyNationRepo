using System;
using HappyNation.Characters;
using System.ComponentModel;

namespace HappyNation
{
    class CharactersTurnContext : ICharactersTurnContext 
    {
        int _timeLeft = GameConstants.HoursInADay;
        ICharacterContext _characterContext;
        
        public CharactersTurnContext(ICharacterContext characterContext)
        {
            _characterContext = characterContext;
        }
        
        public bool VisitNeighbor(ICharacterContext neighbor, int numberToBuy)
        {
            if (_timeLeft < GameConstants.TimeToVisitNeighbor)
                return false;


            _timeLeft -= GameConstants.TimeToVisitNeighbor;
            _characterContext.Visit(neighbor, numberToBuy);

            return true;
        }

        public bool ExploreTheWorld2Cards()
        {
            if (_timeLeft < GameConstants.TimeToExplore2Cards)
                return false;
            
            return true;
        }

        public bool ExploreTheWorld3Cards()
        {
            if (_timeLeft < GameConstants.TimeToExplore3Cards)
                return false;

            return true;
        }

        public bool ExploreTheWorld4Cards()
        {
            if (_timeLeft < GameConstants.TimeToExplore4Cards)
                return false;

            return true;
        }
        
        public bool SpendEntertainment(int numberToSpend)
        {
            if (numberToSpend > _characterContext.EntertainmentStock)
                return false;
            if (numberToSpend < _timeLeft * GameConstants.TimeToSpendEntertainment)
                return false;
            if (_characterContext.Character == Profession.Entertainer 
                && numberToSpend > GameConstants.MaxNumberOfEntertainmentTheEntertainerCanSpend)
                return false;

            _characterContext.EntertainmentStock -= numberToSpend;
            _characterContext.Move(numberToSpend * GameConstants.NumberOfHappinessPointsPerEntertainmentSpent);
            return true;
        }

        public bool AdjustPrice(int newPrice)
        {
            if (newPrice < 0)
                return false;
            _characterContext.Price = newPrice;
            return true;
        }

        public void EndTurn()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

        public int TimeLeft
        {
            get { return _timeLeft; }
            private set
            {
                if(_timeLeft != value)
                {
                    _timeLeft = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimeLeft"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler Finished;

    }
}



