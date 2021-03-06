﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlane : MonoBehaviour
{
    float speed = 10.0f;
    float zlimit;
    bool OnLimit;
    float currentPost;
    
    public GameObject PlayerGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        // Moving plane's limit before turning right or left
        currentPost = transform.position.x;
        zlimit = 15f;
        if (currentPost < zlimit && OnLimit)
        {
            MoveRight();
        }
        else if (currentPost > -15f && !OnLimit)
        {
            MoveLeft();
        }
        else
        {
            OnLimit = !OnLimit;
        }
    }

    private void MoveRight()
    {
        // move right
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    private void MoveLeft()
    {
        // move left
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Enables player to move with moving plane
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerGo.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Allows player to exit the moving plane
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerGo.transform.SetParent(null);
        }
    }
}
