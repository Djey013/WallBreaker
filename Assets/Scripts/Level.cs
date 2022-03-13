using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    public int brikeLeft = 0;
    public Text brikeText;
    public Text ScoreText;
    public MyScriptableObject Datas; //acces a notre objet persistant appelé "Datas"
    public GameObject WinCanvas;

    private void Start()
    {
        Time.timeScale = 1; 
        WinCanvas.SetActive(false);
        brikeText.text = "Bricks restantes: " + brikeLeft;
    }
    
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Datas.actualScene++;
            if (Datas.actualScene < Datas.sceneList.Length)
            {
                SceneManager.LoadScene(Datas.sceneList[Datas.actualScene]);
            }
            else
            {
                SceneManager.LoadScene("Start");
            }
            
        }

        if (brikeLeft <= 0)
        {
            WinCanvas.SetActive(true);
            Time.timeScale = 0;  //met le jeu en pause
        }
    }

    
    
    
    public void UpdateScore(int value)
    {
        Datas.score += value;
    }


    public void AfficherScore()
    {
        ScoreText.text = "Score =" + Datas.score;
        brikeText.text = "Bricks restantes: " + brikeLeft;


    }

    public void GameOver()
    {
        Debug.Log("Perdu");
        
    }
}
