using System;
using System.ComponentModel;

namespace HappyNation
{
    public interface ICharactersTurnContext : INotifyPropertyChanged
    {
        event EventHandler Finished;

        int TimeLeft { get; }
        bool AdjustPrice(int newPrice);
        void EndTurn();
        bool ExploreTheWorld2Cards();
        bool ExploreTheWorld3Cards();
        bool ExploreTheWorld4Cards();
        bool SpendEntertainment(int numberToSpend);
        bool VisitNeighbor(ICharacterContext neighbor, int numberToBuy);
    }
}