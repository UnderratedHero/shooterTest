using Unity.Netcode;
using UnityEngine.SceneManagement;
public static class SceneLoader 
{
    public enum Scene
    {
        Game,
        Loading,
        Lobby,
    }

    private static Scene targetScene;

    public static void LoadNetwork(Scene targetScene)
    {
        NetworkManager.Singleton.SceneManager.LoadScene(targetScene.ToString(), LoadSceneMode.Single);
    }

    public static string GetScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
