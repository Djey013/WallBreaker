using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create MyScriptableObject")]
public class MyScriptableObject : ScriptableObject
{
    public int score = 0;
    public string playerName = "AnotherName";

    public string[] sceneList;
    public int actualScene = 0;
}
