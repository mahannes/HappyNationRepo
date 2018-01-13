using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using HappyNation.Characters;
using HappyNation.Banking;

namespace HappyNation
{
    class CharacterContext : ICharacterContext
    {
        int _stock; //Number of goods
        int _cash; //cash
        int _price; //price
        int _position;
        int _foodStock;
        int _houseStock;
        int _entertainmentStock;
        ILoan _loan; // Can a character have multiple loans?

        HashSet<Profession> _neighborsVisitedThisRound = new HashSet<Profession>();
        Profession _profession;

        public event PropertyChangedEventHandler PropertyChanged;

        public CharacterContext(Profession profession)
        {
            _profession = profession;
        }
        
        public bool Visit(ICharacterContext neighbor, int numberToBuy)
        {
            var totalPrice = numberToBuy * neighbor.Price;
            if(_cash < totalPrice)
            {
                return false;
            }
            _neighborsVisitedThisRound.Add(neighbor.Character);

            // ToDo This does not work for banking
            neighbor.Stock -= numberToBuy;

            neighbor.Cash += totalPrice;
            Cash -= totalPrice;

            return true;
        }

        public void Move(int movement)
        {
            Position += movement;

        }

        public int Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Position"));
                }
            }
        }

        // ToDO How to deal with this? And what about banker?
        public int Stock
        {
            get { return _stock; }
            set
            {
                if (_stock != value)
                {
                    _stock = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Stock"));
                }
            }
        }

        public int FoodStock
        {
            get { return _foodStock; }
            set
            {
                if (_foodStock != value)
                {
                    _foodStock = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FoodStock"));
                }
            }
        }

        public int HouseStock
        {
            get { return _houseStock; }
            set
            {
                if (_houseStock != value)
                {
                    _houseStock = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HouseStock"));
                }
            }
        }

        public int EntertainmentStock
        {
            get { return _entertainmentStock; }
            set
            {
                if (_entertainmentStock != value)
                {
                    _entertainmentStock = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EntertainmentStock"));
                }
            }
        }

        public int Cash
        {
            get { return _cash; }
            set
            {
                if (_cash != value)
                {
                    _cash = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cash"));
                }
            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                }
            }
        }

        public ILoan Loan
        {
            get { return _loan; }
            set
            {
                if (_loan != value)
                {
                    _loan = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loan"));
                }
            }
        }

        public Profession Character { get { return _profession; } }
        
    }
}



