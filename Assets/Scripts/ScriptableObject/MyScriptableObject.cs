using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create my scriptable object")] //ajoute une option en plus dans le menu "Projet"
public class MyScriptableObject : ScriptableObject
{
    public int score = 0;
    public string playerName = "NoName";
    public int actualScene = 0; //index de liste de scene
    
    public string[] sceneList;
}
