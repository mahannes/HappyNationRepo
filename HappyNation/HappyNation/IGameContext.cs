using System.Collections.Generic;
using System.ComponentModel;

namespace HappyNation
{
    public interface IGameContext : INotifyPropertyChanged
    {
        IEnumerable<ICharacterContext> CharacterContexts { get; }
        ITurnContext CurrentTurnContext { get; }
        void InitializeStandard();
        void StartGame();
        IForeignNations ForeignNations { get; }
    }
}