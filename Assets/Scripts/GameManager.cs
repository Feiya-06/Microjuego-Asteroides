using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public TextMeshProUGUI pauseText;
    public GameObject resumeButton;
    public GameObject pausePanel;

    private bool isPaused = false;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) && !isGameOver)
        {
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; //comando para congelar
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameOver = true;
        pausePanel.SetActive(true);
        pauseText.text = "GAME OVER";
        resumeButton.SetActive(false);
        Time.timeScale = 0f;
    }
}
