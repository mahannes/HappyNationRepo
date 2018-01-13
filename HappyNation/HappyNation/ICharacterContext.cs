using HappyNation.Characters;
using System.ComponentModel;

namespace HappyNation
{
    public interface ICharacterContext : INotifyPropertyChanged
    {
        int Cash { get; set; }
        Profession Character { get; }
        int EntertainmentStock { get; set; }
        int FoodStock { get; set; }
        int HouseStock { get; set; }
        int Position { get; set; }
        int Price { get; set; }
        int Stock { get; set; }

        void Move(int movement);
        bool Visit(ICharacterContext neighbor, int numberToBy);
    }
}