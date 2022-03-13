using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public MyScriptableObject Data;

    private void Start()
    {
        Data.score = 0; //relancer le score à 0
        Data.actualScene = 0; //relance à 0 l'index de liste de scene
        SceneManager.LoadScene(Data.sceneList[Data.actualScene]);
    }
}
