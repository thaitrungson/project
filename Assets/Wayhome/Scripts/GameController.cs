using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    // public static GameController instance;

    public GameObject Cherry;


    int score;

    public TMP_Text time;
    public float timeValue = 300;


    bool isGameover;
    bool isGameVictory;


    UIManager ui;
    Playercontroller pl;




    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        pl = FindObjectOfType<Playercontroller>();
        


    }
    void Update()
    {
        if (isGameover)
        {
            ui.ShowGameOverPanel(true);
            ui.SetFinalScoreText("Your Score: " + score);
            return;

        }
        if (isGameVictory)
        {
            ui.ShowGameVictoryPanel(true);
            pl.jumpHeight = 0;
            pl.maxSpeed = 0;
            ui.SetFinalScoreTextWin("Your Score: " + score);
            return;
        }

        if (timeValue == 0)
        {
            ui.ShowGameOverPanel(true);
            pl.jumpHeight = 0;
            pl.maxSpeed = 0;
            ui.SetFinalScoreText("Your Score: " + score);
            return;
        }

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }

    public void RePlay(int index)
    {
       /* if (Input.GetKey(KeyCode.KeypadEnter))
        {*/

            score = 0;
            isGameover = false;
            isGameVictory = false;
            ui.SetScoretext("Score: " + score);

            ui.ShowGameOverPanel(false);
            ui.ShowGameVictoryPanel(false);
            SceneManager.LoadScene("WayHome");
        //}
       
    }

    public void Menu(int index)
    {
        SceneManager.LoadScene("MenuGame");
    }

    public void InFor(int index)
    {

        SceneManager.LoadScene("infor");
    }

    public void play(int index)
    {

        SceneManager.LoadScene("WayHome");
    }


    public void MN(int index)
    {
        ui.ShowPanel(true);
        pl.jumpHeight = 0;
        pl.maxSpeed = 0;

    }

    public void contin(int index)
    {
        ui.ShowPanel(false);
        pl.jumpHeight = 9.5f;
        pl.maxSpeed = 7f;
    
    }



    public void SetScore(int value)
    {
        score = value;
    }
    public int GetScore()
    {
        return score;
    }

   

    public void IncrementScore()
    {
        score++;
        ui.SetScoretext("Score: " + score);
    }

    public void IncrementScore5()
    {
        score += 5;
        ui.SetScoretext("Score: " + score);
    }


    public bool  IsGameover()
    {
        return isGameover;
    }
    public void SetGameoverState(bool state)
    {
        isGameover = state;
    }

    public bool IsGameVictory()
    {
        return isGameVictory;
        
    }
    public void SetGamevictoryState(bool state)
    {
        isGameVictory = state;
    }

    void DisplayTime(float timeToDisPlay)
    {
        if (timeToDisPlay < 0)
        {
            timeToDisPlay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisPlay / 60);
        float seconds = Mathf.FloorToInt(timeToDisPlay % 60);
        
    }
}


