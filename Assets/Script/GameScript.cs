using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    private const string GAME_OVER_MESSAGE = "遊戲結束\n你的分數為";
    public bool isGameOver;
    private int life;
    private int score;

    public Text scoreText;
    public Text lifeText;
    public Text restartGameHintText;
    public Text gameOverText;
    public Button startButton;
    public SpawnManager spawnManager;
    public GameObject menuPanel;
    public PlayerController playerController;

    void Start()
    {
        //某些UI先隱藏
        restartGameHintText.enabled = false;
        gameOverText.enabled = false;
        isGameOver = false;
        //初始數值
        life = 3;
        score = 0;
        isGameOver = false;

        //使用者不能亂動
        playerController.enabled = false;

        startButton.onClick.AddListener(StartButtonOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            RestartGame();
        }
    }

    private void StartButtonOnClick()
    {
        spawnManager.StartSpawn();
        menuPanel.SetActive(false);
        playerController.enabled = true;
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();
    }

    private void GameOver()
    {
        isGameOver = true;
        spawnManager.StopSpawn();
        restartGameHintText.enabled = true;
        gameOverText.text = GAME_OVER_MESSAGE + score.ToString();
        gameOverText.enabled = true;
        playerController.enabled = false;
    }

    private void RestartGame()
    {
        isGameOver = false;
        life = 3;
        score = 0;
        lifeText.text = life.ToString();
        scoreText.text = score.ToString();
        isGameOver = false;
        spawnManager.StartSpawn();
        restartGameHintText.enabled = false;
        gameOverText.enabled = false;
        playerController.enabled = true;
    }

    public void AddScore(int score)
    {
        if (isGameOver) return;

        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void DecreaseLife()
    {
        if (isGameOver) return;

        life -= 1;
        lifeText.text = life.ToString();

        if (this.life == 0)
        {
            isGameOver = true;
            GameOver();
        }
    }
}
