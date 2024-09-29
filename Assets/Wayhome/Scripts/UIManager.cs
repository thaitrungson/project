using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
     public TMP_Text scoretext;
    public TMP_Text time;

    public TMP_Text FinalScoreText;
    public TMP_Text FinalScoreTextWin;
    public GameObject gameoverPanel;
    public GameObject buttonMenu;
    public GameObject gamevictoryPanel;
    public GameObject Panel;

    GameController gc;

    // public float timeStart = 300;


    void Start()
    {
      
    }

 void Update()
    {
      
    }

    public void SetScoretext(string txt)
    {
        if(scoretext)
            scoretext.text = txt;
    }

    public void SetTime(string txt)
    {
        if(time)
            time.text = txt;
    }
    
  public void ShowGameOverPanel(bool isShow)
   {
        if (gameoverPanel)
            gameoverPanel.SetActive(isShow);
        Destroy(buttonMenu);
   }



public void ShowGameVictoryPanel(bool isShow)
    {
        if (gamevictoryPanel)
            gamevictoryPanel.SetActive(isShow);
        Destroy(buttonMenu);
    }

    public void ShowPanel(bool isShow)
    {
        if (Panel)
            Panel.SetActive(isShow);
    }

    public void SetFinalScoreText(string txt)
    {
        if(FinalScoreText)
            FinalScoreText.text = txt;
        //  ui.SetScoreText("Score: " + score);
    }
    public void SetFinalScoreTextWin(string txt)
    {
        if (FinalScoreTextWin)
            FinalScoreTextWin.text = txt;
        //  ui.SetScoreText("Score: " + score);
    }
}
