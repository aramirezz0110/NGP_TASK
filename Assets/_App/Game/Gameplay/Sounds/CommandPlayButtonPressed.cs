using Cysharp.Threading.Tasks;

namespace _App.Game.Gameplay.Sounds
{
    public class CommandPlayButtonPressed : CommandPlaySound
    {
        protected override UniTask ExecuteInternal()
        {
            _sfxController.PlayButtonPressed();
            return UniTask.CompletedTask;
        }
    }
}
