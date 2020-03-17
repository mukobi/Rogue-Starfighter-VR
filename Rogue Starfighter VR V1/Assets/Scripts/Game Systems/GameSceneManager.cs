using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void AddSceneIfNotLoaded(int index)
    {
        if (!SceneManager.GetSceneAt(index).isLoaded)
        {
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        }
    }
}
