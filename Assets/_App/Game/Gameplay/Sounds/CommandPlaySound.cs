using _App.Game.Core.Commands;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _App.Game.Gameplay.Sounds
{
    public class CommandPlaySound : Command
    {
        [Inject] protected SFXController _sfxController;
        
        protected override UniTask ExecuteInternal()
        {
            return UniTask.CompletedTask;
        }
    }
}
