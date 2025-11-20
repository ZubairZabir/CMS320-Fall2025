using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        // Stop all music before going back to menu
        GameObject musicObject = GameObject.FindGameObjectWithTag("music");
        if (musicObject != null)
        {
            AudioManager audioManager = musicObject.GetComponent<AudioManager>();
            if (audioManager != null)
            {
                audioManager.StopAllMusic();
            }
        }
        
        // Make sure the scene name matches exactly your Main Menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
