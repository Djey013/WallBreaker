using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public MyScriptableObject datas;

    private void Start()
    {
        datas.actualScene = 0;
        datas.score = 0;
        SceneManager.LoadScene(datas.sceneList[datas.actualScene]);
    }
}
