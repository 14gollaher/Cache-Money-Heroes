using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class EnemyFixedRanged : MonoBehaviour
{
    public float health;
    public float speed;
    public float pullRange;
    public Transform player;
    public Rigidbody2D rb2d;
    private Animator animator;
    private bool movedPosition = false;
    private float initialPositionX;
    private float initialPositionY;
    private SpriteRenderer SpriteRend;
    private float timeStamp;
    public GameObject ArrowPrefab;
    public Transform ArrowSpawn;
    public int shotSpeed = 12000;
    public float fireDelay = 0.25F;
    private float nextFire = 0.25F;
    private float myTime = 0.0F;

    void Start()
    {
        initialPositionX = transform.position.x;
        initialPositionY = transform.position.y;
        animator = this.GetComponent<Animator>();
        SpriteRend = this.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        myTime = myTime + Time.deltaTime;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (health <= 0)
        {
            if (SceneManager.GetActiveScene().name == "EarthDungeon" || SceneManager.GetActiveScene().name == "GrassDungeon" || SceneManager.GetActiveScene().name == "FireDungeon" || SceneManager.GetActiveScene().name == "IceDungeon")
            {
                MiniDungeonManager.enemiesForKeyPrivate += -1;
            }

            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("highScore") + 1);
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

        else if ((distance < pullRange) && myTime > nextFire)
        {
            movedPosition = true;
            nextFire = myTime + fireDelay;
            Invoke("Fire", 0.7692308F / 2);
            nextFire = nextFire - myTime;
            myTime = 0.0F;
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

    void Fire()
    {
        if (animator.GetInteger("Direction") == 0)
        {
            var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 90));
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -1 * shotSpeed);
            Destroy(arrow, 5.0f);
        }
        else if (animator.GetInteger("Direction") == 1)
        {
            var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 360));
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -1 * shotSpeed);
            Destroy(arrow, 5.0f);
        }
        else if (animator.GetInteger("Direction") == 2)
        {
            var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 270));
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -1 * shotSpeed);
            Destroy(arrow, 5.0f);
        }
        else if (animator.GetInteger("Direction") == 3)
        {
            var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 180, 0));
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -1 * shotSpeed);
            Destroy(arrow, 5.0f);
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
            rb2d.velocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * 25, rb2d.velocity.y);

            timeStamp = Time.time + .35F;
            health--;
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
