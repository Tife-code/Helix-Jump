using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel, levelcompletedPanel, gamePlayPanel, startMenuPanel;

    public static bool gameOver, levelCompleted;
    public static int currentLevelIndex, numberOfPassedRings;

    public TextMeshProUGUI currentLevelText, nextLevelText;

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
        isGameStarted = gameOver = levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Level");
            }
        }

        //when player lands on last ring, level is completed
        if (levelCompleted)
        {
            levelcompletedPanel.SetActive(true);
            if (Input.GetButton("Fire1"))
            {
                SceneManager.LoadScene("Level");
                PlayerPrefs.SetInt("currentLevelIndex", currentLevelIndex + 1);
            }
        }

        
    }

   
}
