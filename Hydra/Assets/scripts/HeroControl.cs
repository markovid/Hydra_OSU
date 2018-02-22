﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroControl : MonoBehaviour {

    public float speed; //controls hero's pace

    private string[] Inventory = new string[10];//holds hero's stuff
    int invCount = 0;

    private CircleCollider2D hitbox;  //used for collecting and interacting with close objects

    private Animator anim;
    public GameObject goblins;
    public GameObject unicorn;
    public GameObject heads;
    public GameObject horn;
    public GameObject milk;
    public GameObject booze;


    //private Rigidbody2D rigbod;

    private string invText = "Inventory:"; //display inventory on screen;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        //rigbod = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Game.current.player.x, Game.current.player.y, 0);
        if (Game.current.player.goblins == true && goblins!=null)
        {
            if (Game.current.player.heads == false && heads != null)
            {
                heads.transform.position = goblins.transform.position;
            }
            GameObject.Destroy(goblins);
        }

        if (Game.current.player.unicorn == true && unicorn != null)
        {
            if (Game.current.player.horn == false && horn != null)
            {
                horn.transform.position = unicorn.transform.position;
            }
            GameObject.Destroy(unicorn);
        }
    }

    // Update is called once per frame
    void Update() {
        float moveHori = Input.GetAxisRaw("Horizontal");
        float moveVert = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(moveHori, moveVert) * speed * Time.deltaTime);
        Game.current.player.x = transform.position.x;
        Game.current.player.y = transform.position.y;



        //vertical movement
        if (Input.GetAxisRaw("Vertical") != 0) {
            //character will always default to facing up or down if any vertical motion occurs
            anim.SetBool("MovedRight", false);
            anim.SetBool("MovedLeft", false);
            //prepare for next idle state
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                anim.SetBool("MovedUp", true);
                anim.SetBool("MovedDown", false);
            } else {
                anim.SetBool("MovedDown", true);
                anim.SetBool("MovedUp", false);
            }
        }
        //horizontal movement
        if (Input.GetAxisRaw("Horizontal") != 0) {
            if (Input.GetAxisRaw("Horizontal") >= 0)
            {
                anim.SetBool("MovedRight", true);
                anim.SetBool("MovedLeft", false);
            } else {
                anim.SetBool("MovedLeft", true);
                anim.SetBool("MovedRight", false);
            }
        }

        //set anim floats for walking animations
        anim.SetFloat("MovingX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MovingY", Input.GetAxisRaw("Vertical"));

        //this is added for simply a test
        if (invCount >= 2) {
            Destroy(GameObject.Find("cat"));
            Destroy(GameObject.Find("drunkard"));
            Destroy(GameObject.Find("farmer"));
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        string keyname;
        

        if (other.gameObject.CompareTag("key")) {
            keyname = other.gameObject.GetComponent<Text>().text;
            print("Collectible Activated");
            //print(keyname);
            invText = invText + "\n" + keyname;
            Inventory[invCount] = keyname;
            invCount++;
            print("Inventory contains:");
            for(int i = 0; i< invCount; i++)
                print(Inventory[i]);
            
            Destroy(other.gameObject);

        }
    }

    private void OnGUI(){
        Rect pos = new Rect(10, 10, 200, 3000);
        GUI.Label(pos, invText);

    }

}
