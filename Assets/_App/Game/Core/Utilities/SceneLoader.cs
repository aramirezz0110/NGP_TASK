using Udar.SceneManager;
using UnityEngine.SceneManagement;

namespace _App.Game.Core.Utilities
{
    public class SceneLoader
    {
        private const int MissingSceneIndex = -1;
        
        public void LoadScene(SceneField sceneField)
        {
            LoadSceneByIndex(sceneField.BuildIndex);
        }
        
        private void LoadSceneByIndex(int sceneIndex)
        {
            if (sceneIndex == MissingSceneIndex)
            {
                return;
            }

            if (sceneIndex == SceneManager.GetActiveScene().buildIndex)
            {
                return;
            }
            
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
