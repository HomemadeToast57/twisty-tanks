using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int winningScore = 5;
    [Header("Labels")]
    public TextMeshProUGUI blueScore;
    public TextMeshProUGUI redScore;

    [Header("Scores")]
    [SerializeField] private int blueScoreValue;
    [SerializeField] private int redScoreValue;

    public bool inPlay;

    public CameraShakeController cameraShakeController;
    


    // Start is called before the first frame update
    void Start()
    {
        cameraShakeController = GameObject.Find("Main Camera").GetComponent<CameraShakeController>();
        cameraShakeController.ShakeCam(false);

       inPlay = true;
       if(PlayerPrefs.GetInt("redScore") == winningScore || PlayerPrefs.GetInt("blueScore") == winningScore)
        {
            GameOver();
            
        } else
        {
            blueScoreValue = PlayerPrefs.GetInt("blueScore");
            redScoreValue = PlayerPrefs.GetInt("redScore");
            UpdateScoreUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoundOver(string playerTag)
    {
        inPlay = false;
        if (playerTag == "P2")
        {
            UpdateScore("P1");  
        }

        if (playerTag == "P1")
        {
            UpdateScore("P2");
        }

        Invoke("ResetGame", 2);
    }

    void UpdateScore(string winningPlayer)
    {
        if (winningPlayer == "P1")
        {
            blueScoreValue++;
            PlayerPrefs.SetInt("blueScore", blueScoreValue);
            UpdateScoreUI();

        } else if (winningPlayer == "P2")
        {
            redScoreValue++;
            PlayerPrefs.SetInt("redScore", redScoreValue);
            UpdateScoreUI();
        }

    }

    void UpdateScoreUI()
    {
        blueScore.text = blueScoreValue.ToString();
        redScore.text = redScoreValue.ToString();
    }

    public void GameOver()
    {
        //Handle end of game here
        PlayerPrefs.SetInt("blueScore", 0);
        PlayerPrefs.SetInt("redScore", 0);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("blueScore", 0);
        PlayerPrefs.SetInt("redScore", 0);
    }

    public bool GetInPlayBool()
    {
        return inPlay;
    }

}

