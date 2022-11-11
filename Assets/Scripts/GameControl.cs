using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject pausedObg;
    private bool isPoused;

    public GameObject GameOverObg;

    public Text healthText;

    public int score;
    public Text scoreText;
    public int totalScore;

    public static GameControl instance;

    public bool isLv1;

    //para pausar o jogo quando tiver em game over
    private bool gO;

    //chamado antes do Start
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //instance representa este objeto;
        //instance = this;
        totalScore = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
   
    public void UpdateScore(int volue)
    {
        score += volue;
        scoreText.text = score.ToString();

        //o nome "score" pode ser outro nome sem ser o da variavel que se deseja salva
        PlayerPrefs.SetInt("score", score + totalScore);
    }
   

    public void UpdadeLives(int value)
    {
        healthText.text = "X" + value.ToString();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPoused = !isPoused;
            pausedObg.SetActive(isPoused);
        }
        if (isPoused)
        {
            //para tudo que ta acontecedo no jogo
            Time.timeScale = 0f;
            if(Input.GetKeyDown(KeyCode.S))
            {
                //isLv1 = !isLv1;
                if(isLv1)
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }

            }
        }
        else if(!isPoused && !gO)
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        GameOverObg.SetActive(true);
        //opcional
        Time.timeScale = 0f;
        gO = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
