  using UnityEngine;
  using UnityEngine.UI;
  using UnityEngine.SceneManagement;
  using TMPro; 

public class GameManager : MonoBehaviour
{
    public Player player; 

    public TextMeshProUGUI scoreText;
    
    public GameObject playButton;

    public GameObject gameOver;
    
    private int score;
    private AudioManager audioManager;

    public TextMeshProUGUI bestScoreText;

    private int bestScore;

    private const string BestScoreKeyPrefix = "BestScore_";

    private string BestScoreKey => BestScoreKeyPrefix + SceneManager.GetActiveScene().name;

    private void Awake()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        if (bestScoreText != null)
        {
            bestScoreText.text = $"Best: {bestScore}";
        }
        Pause();
    }

    private void Start()
    {
        GameObject musicObject = GameObject.FindGameObjectWithTag("music");
        if (musicObject != null)
        {
            audioManager = musicObject.GetComponent<AudioManager>();
        }
        
        // Stop all music when scene starts (menu/paused state)
        if (audioManager != null)
        {
            audioManager.StopAllMusic();
        }
    }


     public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        if (bestScoreText != null)
        {
            bestScoreText.text = $"Best: {bestScore}";
        }

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

        // Stop background music when paused (menu state)
        if (audioManager != null)
        {
            audioManager.StopBackgroundMusic();
        }
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        // Stop background music and play game over music
        if (audioManager != null)
        {
            audioManager.StopBackgroundMusic();
            audioManager.PlayGameOverMusic();
        }

        PlayerPrefs.SetInt(BestScoreKey, bestScore);
        PlayerPrefs.Save();

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
            if (bestScoreText != null)
            {
                bestScoreText.text = $"Best: {bestScore}";
            }
        }
    }

}
