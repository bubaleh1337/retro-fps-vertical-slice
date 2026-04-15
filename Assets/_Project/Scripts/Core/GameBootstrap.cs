using UnityEngine;

namespace RetroSlice.Core
{
    public class GameBootstrap : MonoBehaviour
    {

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
                UnityEngine.SceneManagement.SceneManager.LoadScene(index);
            }
        }
    }
}

