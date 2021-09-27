using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int coins = 0;
    public Text coinsText;

    public GameObject player;
    public GameObject spawnPoint;

    private CheckPoint checkPoint;

    public PlayerController playerC;
    public bool gameIsPaused;
    public GameObject pause;

    public Button returnToMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        //coinsText.text = "Generic material: " + coins;
        checkPoint = null;
        playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //returnToMainMenu = GameObject.FindGameObjectWithTag("ReturnToMM").GetComponent<Button>();

        returnToMainMenu.onClick.AddListener(TaskOnClickReturn);
        //pause = GameObject.FindGameObjectWithTag("PauseScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerC.currentHP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

        if (Time.timeScale == 0f)
        {
            pause.SetActive(true);
            gameIsPaused = true;
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pause.SetActive(false);
        }
    }



    public void addCoins(int coins)
    {
        if (coins < 0) return;
        this.coins += coins;
        coinsText.text = "Generic material: " + coins;
        
    }

    public void CheckPoint(CheckPoint checkPoint)
    {
        this.checkPoint = checkPoint;
    }

    public void OnPlayerfall()
    {
        playerC.currentHP -= 30;
        if (checkPoint)
        {
            player.transform.position = checkPoint.transform.position;
        }
        else
        {
            player.transform.position = spawnPoint.transform.position;
        }

        player.GetComponent<BlinkController>().BlinkThenOn(3);

        if (checkPoint == null)
        {
            FallingBlock[] fallingBlocks = GameObject.FindObjectsOfType<FallingBlock>();
            for (int i = 0; i < fallingBlocks.Length; i++)
            {
                fallingBlocks[i].Reset();
            }
        }
    }

    public void OnDeath()
    {
        
        if (playerC.currentHP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void EndLevel()
    {
        SceneManager.LoadScene("Menu");
    }

    void TaskOnClickReturn()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
