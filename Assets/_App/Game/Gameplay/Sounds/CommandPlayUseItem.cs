using Cysharp.Threading.Tasks;

namespace _App.Game.Gameplay.Sounds
{
    public class CommandPlayUseItem : CommandPlaySound
    {
        protected override UniTask ExecuteInternal()
        {
            _sfxController.PlayUseItem();
            return UniTask.CompletedTask;
        }
    }
}
