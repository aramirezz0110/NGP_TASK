using Cysharp.Threading.Tasks;

namespace _App.Game.Gameplay.Sounds
{
    public class CommandPlayRemoveItem : CommandPlaySound

    {
        protected override UniTask ExecuteInternal()
        {
            _sfxController.PlayRemoveItem();
            return UniTask.CompletedTask;
        }
    }
}
