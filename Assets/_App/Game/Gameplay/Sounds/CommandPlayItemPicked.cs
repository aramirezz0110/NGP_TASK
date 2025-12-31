using Cysharp.Threading.Tasks;

namespace _App.Game.Gameplay.Sounds
{
    public class CommandPlayItemPicked : CommandPlaySound
    {
        protected override UniTask ExecuteInternal()
        {
            _sfxController.PlayItemPicked();
            return UniTask.CompletedTask;
        }
    }
}
