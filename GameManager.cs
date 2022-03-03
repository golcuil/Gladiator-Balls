using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Transform mainCam;
    private PlayerController gameActivison;

    public TextMeshProUGUI winningText;
    public TextMeshProUGUI gameOverText;
    public Button startButton;
    public Button restartButton;
    public TextMeshProUGUI scoreText;

    public int score;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        startButton.onClick.AddListener(StartGame);
        mainCam = GameObject.Find("Main Camera").GetComponent<Transform>();
        gameActivison = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void StartGame()
    {
        gameActivison.isActive = true;
        startButton.gameObject.SetActive(false);
        
    }

    public void GameOver()
    {
        gameActivison.isActive = false;
        mainCam.transform.position = new Vector3(-10.6f, 7.28f, -1.6f);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    public void ScoreToAdd(int addScore)
    {
        score += addScore;
        scoreText.text = "Score : " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinningScreen()
    {
        gameActivison.isActive = false;
        mainCam.transform.position = new Vector3(-10.6f, 7.28f, -1.6f);
        winningText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    

}
