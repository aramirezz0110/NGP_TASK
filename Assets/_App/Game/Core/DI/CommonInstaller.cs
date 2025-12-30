using _App.Game.Core.Utilities;
using Zenject;

namespace _App.Game.Core.DI
{
    public class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}
