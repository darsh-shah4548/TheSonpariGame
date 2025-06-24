using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool isgameOver = false;

    public AudioClip scoreSound;
    public AudioClip gameOverSound;
    public AudioSource backgroundMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (isgameOver) return;
        
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioSource.PlayOneShot(scoreSound);
        

        
    }    

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (!isgameOver)
        {
            gameOverScreen.SetActive(true);
            isgameOver = true;
            backgroundMusic.Stop();
            audioSource.PlayOneShot(gameOverSound);
        }
        
    }

}
