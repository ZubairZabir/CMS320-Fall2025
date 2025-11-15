  using UnityEngine;
  using UnityEngine.UI;
  using TMPro; 

public class GameManager : MonoBehaviour
{
    public Player player; 

    public TMP_Text scoreText;
    
    public GameObject playButton;

    public GameObject gameOver;
    
    private int score;
    private AudioManager audioManager;

    private void Awake()
    {
        Pause();
    }

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("music")
                                 .GetComponent<AudioManager>();
    }


     public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsByType<Pipes>(FindObjectsSortMode.None);

        for( int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

        // Restart background music when game restarts
        if (audioManager != null)
        {
            audioManager.StartBackgroundMusic();
        }
    }

     public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;

    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        // Play game over music (background music already stopped by Player)
        if (audioManager != null)
        {
            audioManager.PlayGameOverMusic();
        }

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
