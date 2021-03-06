﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class BossFixed : MonoBehaviour
{

    public float health;
    public float speed;
    public float pullRange;
    public Transform player;
    private Rigidbody2D rb2d;
    private Animator animator;
    private bool movedPosition = false;
    private float initialPositionX;
    private float initialPositionY;
    private SpriteRenderer SpriteRend;
    private float timeStamp;
    //public Text scoreText;
    public AnimationClip deathAnimation;
    private bool deathBool;


    void Start()
    {
        initialPositionX = transform.position.x;
        initialPositionY = transform.position.y;
        rb2d = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        SpriteRend = this.GetComponent<SpriteRenderer>();
        deathBool = false;
    }

    void FixedUpdate()
    {

        if (health <= 0)
        {

            animator.SetTrigger("Death");
            animator.SetBool("Move", false);
            if (UIManager.manaValue < 5)
            {
                UIManager.manaValue++;
            }
            if ((SceneManager.GetActiveScene().name == "EarthDungeon" || SceneManager.GetActiveScene().name == "GrassDungeon" || SceneManager.GetActiveScene().name == "FireDungeon" || SceneManager.GetActiveScene().name == "IceDungeon" || SceneManager.GetActiveScene().name == "CastleFloor9") && deathBool == false)
            {
                
                MiniDungeonManager.enemiesForKeyPrivate += -1;
                Transitioner.enemiesKilled += 1;
                HighScores.highScoreValue += 10;

                deathBool = true;
            }

            Destroy(this.gameObject, deathAnimation.length * 5);
        }


        if (timeStamp < Time.time)
        {
            SpriteRend.color = new Color(1F, 1F, 1F, 1F);
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (Archer.isInvisible == true)
        {
            float z = Mathf.Atan2((initialPositionY - transform.position.y), (initialPositionX - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, z);
            rb2d.AddForce(gameObject.transform.up * speed);
            if (((initialPositionX > transform.position.x - 1) && (initialPositionX < transform.position.x + 1)) &&
                ((initialPositionY > transform.position.y - 1) && (initialPositionY < transform.position.y + 1)))
            {
                movedPosition = false;
            }
        }

        else if ((distance < pullRange) && health > 0)
        {
            movedPosition = true;
            float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, z);
            rb2d.AddForce(gameObject.transform.up * speed);
            animator.SetInteger("Direction", 2);
            animator.SetBool("Move", true);
        }

        else if (movedPosition && health > 0)
        {
            float z = Mathf.Atan2((initialPositionY - transform.position.y), (initialPositionX - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, z);
            rb2d.AddForce(gameObject.transform.up * speed);
            if (((initialPositionX > transform.position.x - 1) && (initialPositionX < transform.position.x + 1)) &&
                ((initialPositionY > transform.position.y - 1) && (initialPositionY < transform.position.y + 1)))
            {
                movedPosition = false;
            }
        }

        // Gets a vector that points from the player's position to the target's.
        var heading = transform.position - player.position;
        var myDistance = heading.magnitude;
        var direction = heading / myDistance; // This is now the normalized direction.
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (isAround0(direction.x) && isAroundNegative1(direction.y)) // NORTH
        {
            animator.SetInteger("Direction", 2);
            animator.SetBool("Move", true);
        }

        else if (isAroundNegative1(direction.x) && isAround0(direction.y)) // EAST
        {
            animator.SetInteger("Direction", 3);
            animator.SetBool("Move", true);
        }

        else if (isAroundPositive1(direction.x) && isAround0(direction.y)) // WEST
        {
            animator.SetInteger("Direction", 1);
            animator.SetBool("Move", true);
        }

        else if (isAround0(direction.x) && isAroundPositive1(direction.y)) // SOUTH
        {
            animator.SetInteger("Direction", 0);
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private bool isAround0(float x)
    {
        if (x < .2 && x > -.2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isAroundPositive1(float x)
    {
        if (x < 1.2 && x > .8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isAroundNegative1(float x)
    {
        if (x < -.8 && x > -1.2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            SpriteRend.color = new Color(255F, 0F, 0F, .75F);
            //rb2d.velocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * 25, rb2d.velocity.y);

            timeStamp = Time.time + .35F;
            health--;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "PlayerPet" || collision.gameObject.tag == "PlayerUltimate")
        {
            rb2d.velocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * 10, rb2d.velocity.y);
            SpriteRend.color = new Color(255F, 0F, 0F, .75F);
            timeStamp = Time.time + .35F;
            health--;
        }

        else if (collision.gameObject.tag == "PlayerDefense")
        {
            rb2d.velocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * 10, rb2d.velocity.y);
            timeStamp = Time.time + .35F;
        }
    }
}
