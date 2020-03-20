using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameSceneManager : MonoBehaviour
{
    public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static async Task AddSceneIfNotLoaded(int index)
    {
        if (!SceneManager.GetSceneAt(index).isLoaded)
        {
            AsyncOperation sceneLoader = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            while (!sceneLoader.isDone)
            {
                await Task.Delay(10);
            }
        }
    }
}
