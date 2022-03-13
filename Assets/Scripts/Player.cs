using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float _direction;
    public float _speed = 0.5f;
    public int lifes;
    public GameObject BallPrefab;
    public Transform BallSpawnPosition;
    public GameObject BallActive;
    public Level levelManager;
    private bool isLauched = false;
    private void Start()
    {
        SpawnBall();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLauched)    //lancement de la balle
                                                              // " !isLauched "  équivaut à  " isLauched = true "). mais il peut etre introduit dans le if stat
        {
            BallActive.transform.SetParent(null);
            BallActive.GetComponent<Rigidbody>().AddForce(new Vector3(_direction,300f *_speed,0f));
            isLauched = true; //permet de faire comprendre au systeme de passer au statut "true" après avoir verifié successivement et chronologiquement que...
                              //...la balle n'est pas encore lancée > space est appuyé > la balle est lancée.
        }

        
    }

    private void SpawnBall()    // apparition de la balle
    {
        BallActive = Instantiate(BallPrefab, BallSpawnPosition.position,BallSpawnPosition.rotation);
        BallActive.transform.SetParent(BallSpawnPosition);
        isLauched = false;
    }
    
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") !=0) // deplacement du joueur avec clamp
            {
                transform.position =
                    new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal"), -7.65f, 7.65f), transform.position.y, transform.position.z);
            }

    }


    public void LostBall()  // respawn de la balle quand elle atteint la limite (mur du bas)
    {
        Destroy(BallActive);
        lifes--;
        if (lifes > 0)
        {
            SpawnBall();
            
        }
        else
        {
            levelManager.GameOver();
        }
    }

    
}


/* ---------------------------------------------------------------------------------------------------
    CheckInputs();
    if (_direction != 0)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + _direction, -7.65f, 7.65f), -4.5f, -0.4f);
    }
    
    

---------------------------------------------------------------------------------------------------
private void CheckInputs()
{
    _direction = Input.GetAxis("Horizontal");
}
*/