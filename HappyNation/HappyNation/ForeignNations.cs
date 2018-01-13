using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HappyNation
{
    public class ForeignNations : IForeignNations
    {
        private readonly IEnumerable<ICharacterContext> _characters;
        private int _funds;

        public ForeignNations(IEnumerable<ICharacterContext> characters)
        {
            this._characters = characters;
        }

        public int Funds
        {
            get { return _funds; }
            private set
            {
                if(_funds != value)
                {
                    _funds = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Funds"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void BuyGoods()
        {
            //ToDo
        }
    }
}
