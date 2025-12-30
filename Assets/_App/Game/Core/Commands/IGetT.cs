namespace _App.Game.Core.Commands
{
    public interface IGetT<T>
    {
        abstract T GetValue();
    }
}