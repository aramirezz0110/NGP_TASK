using Cysharp.Threading.Tasks;

namespace _App.Game.Core.Commands
{
    public interface ICommand
    {
        public interface ICommand
        {
            void Execute();
            UniTask AwaitableExecute();
        }
    }
}