using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel, levelcompletedPanel, gamePlayPanel, startMenuPanel;

    public static bool gameOver, levelCompleted;
    public static int currentLevelIndex, numberOfPassedRings, score = 0;

    public TextMeshProUGUI currentLevelText, nextLevelText, scoreText, highScoreText;

    public Slider gameProgressSlider;

    public static bool mute = false, isGameStarted;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", 1);
       
    }

    // Start is called before the first frame update
    void Start()
    {  
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        isGameStarted = gameOver = levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //setting score value to display
        scoreText.text = score.ToString();

        //to set the value of current level and next level
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        if(Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            isGameStarted=true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }
        //when player lands on unsafe ring it becomes gameover 
        if (gameOver)
        {
            score = 0;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                Restart();
            }
        }

        //when player lands on last ring, level is completed
        if (levelCompleted)
        {
            highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore");
            levelcompletedPanel.SetActive(true);
            if (Input.GetButton("Fire1"))
            {
                OnLevelCompleted();
            }
        }

        
    }
    void Restart()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
           
        }

        PlayerPrefs.SetInt("currentLevelIndex", 1);
        SceneManager.LoadScene("Level");
        
    }
   
    void OnLevelCompleted()
    {
        SceneManager.LoadScene("Level");
        PlayerPrefs.SetInt("currentLevelIndex", currentLevelIndex + 1);
    }
}
