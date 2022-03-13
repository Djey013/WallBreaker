using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _direction;
    private float _speed = 0.5f;
    public int lifes;
    public GameObject BallPrefab;
    public Transform BallSpawnPosition;
    public GameObject BallActive;
    public Level levelManager;
    private void Start()
    {
        SpawnBall();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BallActive.transform.SetParent(null);
            BallActive.GetComponent<Rigidbody>().AddForce(new Vector3(_direction,300f,0f));
        }

    }

    private void SpawnBall()
    {
        BallActive = Instantiate(BallPrefab, BallSpawnPosition.position,BallSpawnPosition.rotation);
        BallActive.transform.SetParent(BallSpawnPosition);
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Input.GetAxis("Horizontal"),0f,0f);

            if (transform.position.x > 7.65f)
            {
                transform.position = new Vector3(7.65f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -7.65f)
            {
                transform.position = new Vector3(-7.65f, transform.position.y, transform.position.z);
            }
 
        }
                
    }

    public void LostBall()
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
