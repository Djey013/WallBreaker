using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    public Text ScoreText;
    public MyScriptableObject Datas;
    
    private void Start()
    {
        AfficherScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Datas.actualScene++;
            if (Datas.actualScene < Datas.sceneList.Length)
            {
                SceneManager.LoadScene(Datas.sceneList[Datas.actualScene]);
            }
            else
            {
                SceneManager.LoadScene(0);

            }
        }

    }

    public void UpdateScore(int value)
    {
        Datas.score += value;
        AfficherScore();
    }


    public void AfficherScore()
    {
        ScoreText.text = "Score = " + Datas.score;
    }

    public void GameOver()
    {
        Debug.Log("Perdu");
    }
}
