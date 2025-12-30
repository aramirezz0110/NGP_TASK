using _App.Game.Core.Commands;
using _App.Game.Core.Utilities;
using Cysharp.Threading.Tasks;
using Udar.SceneManager;
using UnityEngine;
using Zenject;

namespace _App.Game.UI.Commands
{
    public class CommandLoadScene : Command
    {
        [SerializeField] private SceneField _scene;
        
        [Inject] private SceneLoader _sceneLoader;
        
        protected override UniTask ExecuteInternal()
        {
            _sceneLoader.LoadScene(_scene);
            return UniTask.CompletedTask;
        }
    }
}
