﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroControl : MonoBehaviour
{

    public float speed; //controls hero's pace

    private CircleCollider2D hitbox;  //used for collecting and interacting with close objects

    private Animator anim;

    //private Rigidbody2D rigbod;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        //rigbod = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Game.current.player.x, Game.current.player.y, 0);
        if (Game.current.player.finalBoss)
        {
            SceneManager.LoadScene("endGame");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHori = Input.GetAxisRaw("Horizontal");
        float moveVert = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(moveHori, moveVert) * speed * Time.deltaTime);
        Game.current.player.x = transform.position.x;
        Game.current.player.y = transform.position.y;

        //vertical movement
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            //character will always default to facing up or down if any vertical motion occurs
            anim.SetBool("MovedRight", false);
            anim.SetBool("MovedLeft", false);
            //prepare for next idle state
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                anim.SetBool("MovedUp", true);
                anim.SetBool("MovedDown", false);
            }
            else
            {
                anim.SetBool("MovedDown", true);
                anim.SetBool("MovedUp", false);
            }
        }
        //horizontal movement
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") >= 0)
            {
                anim.SetBool("MovedRight", true);
                anim.SetBool("MovedLeft", false);
            }
            else
            {
                anim.SetBool("MovedLeft", true);
                anim.SetBool("MovedRight", false);
            }
        }

        //set anim floats for walking animations
        anim.SetFloat("MovingX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MovingY", Input.GetAxisRaw("Vertical"));


        if (Input.GetKeyDown("left shift"))
        {
            speed = 1.8f;
        }
        if (Input.GetKeyUp("left shift"))
        {
            speed = 1.2f;
        }
    }

}