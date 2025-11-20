using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        // Stop all music when in main menu
        GameObject musicObject = GameObject.FindGameObjectWithTag("music");
        if (musicObject != null)
        {
            audioManager = musicObject.GetComponent<AudioManager>();
            if (audioManager != null)
            {
                audioManager.StopAllMusic();
            }
        }
    }

    // Load All Saints Scene
    public void LoadAllSaints()
    {
        StopMusicBeforeSceneLoad();
        SceneManager.LoadScene("AllSaints");
    }

    // Load Bush Scene
    public void LoadBush()
    {
        StopMusicBeforeSceneLoad();
        SceneManager.LoadScene("Bush");
    }

    // Load Olin Scene
    public void LoadOlin()
    {
        StopMusicBeforeSceneLoad();
        SceneManager.LoadScene("Olin");
    }

    // Load Lake Virginia Scene
    public void LoadLakeVirginia()
    {
        StopMusicBeforeSceneLoad();
        SceneManager.LoadScene("LakeVirginia");
    }

    private void StopMusicBeforeSceneLoad()
    {
        if (audioManager == null)
        {
            GameObject musicObject = GameObject.FindGameObjectWithTag("music");
            if (musicObject != null)
            {
                audioManager = musicObject.GetComponent<AudioManager>();
            }
        }
        
        if (audioManager != null)
        {
            audioManager.StopAllMusic();
        }
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
