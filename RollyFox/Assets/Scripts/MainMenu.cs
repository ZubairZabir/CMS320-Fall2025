using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load All Saints Scene
    public void LoadAllSaints()
    {
        SceneManager.LoadScene("AllSaints");
    }

    // Load Bush Scene
    public void LoadBush()
    {
        SceneManager.LoadScene("Bush");
    }

    // Load Olin Scene
    public void LoadOlin()
    {
        SceneManager.LoadScene("Olin");
    }

    // Load Lake Virginia Scene
    public void LoadLakeVirginia()
    {
        SceneManager.LoadScene("LakeVirginia");
    }

    // Quit button (optional)
    public void QuitGame()
    {
        Application.Quit();

        // So Play Mode stops in Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
