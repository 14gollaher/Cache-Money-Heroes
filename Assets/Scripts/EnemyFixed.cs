using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class EnemyFixed : MonoBehaviour
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
    void Start()
    {
        initialPositionX = transform.position.x;
        initialPositionY = transform.position.y;
        rb2d = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        SpriteRend = this.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            Transitioner.enemiesKilled += 1;
            HighScores.highScoreValue += 1;
            if (UIManager.manaValue < 5)
            {
                UIManager.manaValue++;
            }
            if (SceneManager.GetActiveScene().name == "EarthDungeon" || SceneManager.GetActiveScene().name == "GrassDungeon" || SceneManager.GetActiveScene().name == "FireDungeon" || SceneManager.GetActiveScene().name == "IceDungeon")
            {
                MiniDungeonManager.enemiesForKeyPrivate += -1;
            }

            Destroy(this.gameObject);
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

        else if ((distance < pullRange))
        {
            movedPosition = true;
            float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, z);
            rb2d.AddForce(gameObject.transform.up * speed);
            animator.SetInteger("Direction", 2);
            animator.SetBool("Move", true);
        }

        else if (movedPosition)
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
        if (x < .3 && x > -.3)
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
        if (x < 1.3 && x > .7)
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
        if (x < -.7 && x > -1.3)
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
        if (collision.gameObject.tag == "PlayerWeapon" || collision.gameObject.tag == "PlayerUltimate")
        {
            SpriteRend.color = new Color(255F, 0F, 0F, .75F);
            rb2d.velocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * 25, rb2d.velocity.y);

            timeStamp = Time.time + .35F;
			health = health - UIManager.attack;

            if (collision.gameObject.tag == "PlayerWeapon")
                Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "PlayerPet")
        {
            rb2d.velocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * 50, rb2d.velocity.y);
            SpriteRend.color = new Color(255F, 0F, 0F, .75F);
            timeStamp = Time.time + .35F;
            health--;
        }
    }
}
