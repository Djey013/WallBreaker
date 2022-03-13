using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Level levelManager;
    public int Points = 1;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Ball>() != null)
        {
            levelManager.UpdateScore(Points);
            levelManager.brikeLeft--;
            levelManager.AfficherScore();
            TargetDestruction(other.gameObject);
        }
    }

    protected void TargetDestruction(GameObject ball)
    {
        Destroy(gameObject);

    }
}
