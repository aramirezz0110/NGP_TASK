using _App.Game.Core.Commands;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _App.Game.UI.Commands
{
    public class CommandCloseApp : Command
    {
        protected override UniTask ExecuteInternal()
        {
            Application.Quit();
            return UniTask.CompletedTask;
        }
    }
}
