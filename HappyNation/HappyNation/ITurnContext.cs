using System;
using System.ComponentModel;

namespace HappyNation
{
    public interface ITurnContext : INotifyPropertyChanged
    {
        ICharactersTurnContext CurrentCharactersTurnContext { get; }

        event EventHandler CharactersTurnStarted;
        event EventHandler TurnEnded;

        void EndTurn();
        void HandleCharactersTurnOver(object sender, EventArgs e);
        void PayInterest();
        void StartTurn();
    }
}