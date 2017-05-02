﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class DragonBoss : MonoBehaviour {

    public float health;
    public float speed;
    public float pullRange;
    public Transform player;
    public Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer SpriteRend;
    private float timeStamp;
    public GameObject ArrowPrefab;
    public Transform ArrowSpawn;
    public int shotSpeed = 12000;
    public float fireDelay = 5F;
    private float nextFire = 0.25F;
    private float myTime = 0.0F;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        SpriteRend = this.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        myTime = myTime + Time.deltaTime;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Credits");

        }

        if (health <= 0)
        {
            if (SceneManager.GetActiveScene().name == "EarthDungeon" || SceneManager.GetActiveScene().name == "GrassDungeon" || SceneManager.GetActiveScene().name == "FireDungeon" || SceneManager.GetActiveScene().name == "IceDungeon")
            {
                MiniDungeonManager.enemiesForKeyPrivate += -1;
            }

            HighScores.highScoreValue += 100;

            Destroy(this.gameObject);
        }

        if (timeStamp < Time.time)
        {
            SpriteRend.color = new Color(1F, 1F, 1F, 1F);
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if ((distance < pullRange) && myTime > nextFire)
        {
            animator.SetTrigger("Attack");
            nextFire = myTime + fireDelay;
            Invoke("Fire", 1F);
            nextFire = nextFire - myTime;
            myTime = 0.0F;
            if (health < 70)
            {
                Invoke("Fire2", 1F);
                if (health < 40)
                {
                    Invoke("Fire3", 1F);
                    myTime = 4.0F;
                }
                else
                    myTime = 2.5F;
            }
        }
    }

    void Fire()
    {
        var arrow0 = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 230));
        var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 250));
        var arrow2 = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 270));
        var arrow3 = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 290));
        var arrow4 = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 310));

        arrow0.GetComponent<Rigidbody2D>().AddForce(arrow0.transform.up * -1 * shotSpeed);
        arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.up * -1 * shotSpeed);
        arrow2.GetComponent<Rigidbody2D>().AddForce(arrow2.transform.up * -1 * shotSpeed);
        arrow3.GetComponent<Rigidbody2D>().AddForce(arrow3.transform.up * -1 * shotSpeed);
        arrow4.GetComponent<Rigidbody2D>().AddForce(arrow4.transform.up * -1 * shotSpeed);

        Destroy(arrow0, 3.0F);
        Destroy(arrow, 3.0f);
        Destroy(arrow2, 3.0f);
        Destroy(arrow3, 3.0f);
        Destroy(arrow4, 3.0F);
    }

    void Fire2()
    {
        var arrow0 = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 240));
        var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 260));
        var arrow2 = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 280));
        var arrow3 = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 300));
        var arrow4 = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 320));

        arrow0.GetComponent<Rigidbody2D>().AddForce(arrow0.transform.up * -1 * shotSpeed);
        arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.up * -1 * shotSpeed);
        arrow2.GetComponent<Rigidbody2D>().AddForce(arrow2.transform.up * -1 * shotSpeed);
        arrow3.GetComponent<Rigidbody2D>().AddForce(arrow3.transform.up * -1 * shotSpeed);
        arrow4.GetComponent<Rigidbody2D>().AddForce(arrow4.transform.up * -1 * shotSpeed);

        Destroy(arrow0, 3.0F);
        Destroy(arrow, 3.0f);
        Destroy(arrow2, 3.0f);
        Destroy(arrow3, 3.0f);
        Destroy(arrow4, 3.0F);
    }

    void Fire3()
    {
        Vector3 randomPosition = new Vector3(1059, Random.Range(-750.0f, -810.0f), 0);

        var arrow0 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 267));
        var arrow = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 269));
        var arrow2 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 271));
        var arrow3 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 273));
        var arrow4 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 275));
        var arrow5 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 280));
        var arrow6 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 282));
        var arrow7 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 284));
        var arrow8 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 286));
        var arrow9 = (GameObject)Instantiate(ArrowPrefab, randomPosition, Quaternion.Euler(0, 0, 288));

        arrow0.GetComponent<Rigidbody2D>().AddForce(arrow0.transform.up * -0.5f * shotSpeed);
        arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.up * -0.5f * shotSpeed);
        arrow2.GetComponent<Rigidbody2D>().AddForce(arrow2.transform.up * -0.5f * shotSpeed);
        arrow3.GetComponent<Rigidbody2D>().AddForce(arrow3.transform.up * -0.5f * shotSpeed);
        arrow4.GetComponent<Rigidbody2D>().AddForce(arrow4.transform.up * -0.5f * shotSpeed);
        arrow5.GetComponent<Rigidbody2D>().AddForce(arrow5.transform.up * -0.5f * shotSpeed);
        arrow6.GetComponent<Rigidbody2D>().AddForce(arrow6.transform.up * -0.5f * shotSpeed);
        arrow7.GetComponent<Rigidbody2D>().AddForce(arrow7.transform.up * -0.5f * shotSpeed);
        arrow8.GetComponent<Rigidbody2D>().AddForce(arrow8.transform.up * -0.5f * shotSpeed);
        arrow9.GetComponent<Rigidbody2D>().AddForce(arrow9.transform.up * -0.5f * shotSpeed);

        Destroy(arrow0, 10.0F);
        Destroy(arrow, 10.0f);
        Destroy(arrow2, 10.0f);
        Destroy(arrow3, 10.0f);
        Destroy(arrow4, 10.0F);
        Destroy(arrow5, 10.0F);
        Destroy(arrow6, 10.0f);
        Destroy(arrow7, 10.0f);
        Destroy(arrow8, 10.0f);
        Destroy(arrow9, 10.0F);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon" || collision.gameObject.tag == "PlayerUltimate")
        {
            SpriteRend.color = new Color(255F, 0F, 0F, .75F);
            timeStamp = Time.time + .35F;
            health--;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "PlayerPet")
        {
            SpriteRend.color = new Color(255F, 0F, 0F, .75F);
            timeStamp = Time.time + .35F;
            health--;
            Destroy(collision.gameObject);
        }
    }
}
