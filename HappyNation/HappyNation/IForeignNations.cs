using System.ComponentModel;

namespace HappyNation
{
    public interface IForeignNations : INotifyPropertyChanged
    {
        int Funds { get; }
    }
}