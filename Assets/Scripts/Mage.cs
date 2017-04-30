using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mage : MonoBehaviour
{
	private Animator animator;
	private SpriteRenderer SpriteRend;
	public Rigidbody2D rb2d;
	public GameObject SpellPrefabSouth;
	public GameObject SpellPrefabNorth;
	public GameObject SpellPrefabEast;
	public GameObject SpellPrefabWest;
	public GameObject ShieldSpell;
	public Transform SpellSpawn;

	public float speed = 1F;
	public int health = 3;
	public int mana = 3;

	public int shotSpeed = 1200;
	public float fireDelay = 0.25F;
	private float nextFire = 0.25F;
	private float myTime = 0.0F;
	private float immuneTimeStamp;
	private bool isImmune = false;

	void Start ()
    {
		animator = this.GetComponent<Animator>();
		SpriteRend = this.GetComponent<SpriteRenderer>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "EnemyMelee")
		{
			if (!isImmune)
			{
				health--;
				rb2d.velocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * 25, rb2d.velocity.y);
				SpriteRend.color = new Color(255F, 0F, 0F, .75F);
				isImmune = true;
				immuneTimeStamp = Time.time + .35F;
			}
		}

		else if (collision.gameObject.tag == "PlayerWeapon")
		{
			Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}

	void Update ()
    {

		if (health <= 0)
		{
			SceneManager.LoadScene("MainMenu");
		}

		if (isImmune == true)
		{
			if (immuneTimeStamp < Time.time)
			{
				SpriteRend.color = new Color(1F, 1F, 1F);
				isImmune = false;
			}
		}

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		myTime = myTime + Time.deltaTime;

		if (Input.GetKey("up") || Input.GetKey("w"))
		{
			animator.SetInteger("Direction", 2);
			animator.SetBool("Move", true);
		}
		else if (Input.GetKey("down") || Input.GetKey("s"))
		{
			animator.SetInteger("Direction", 0);
			animator.SetBool("Move", true);
		}
		else if (Input.GetKey("right") || Input.GetKey("d"))
		{
			animator.SetInteger("Direction", 3);
			animator.SetBool("Move", true);
		}
		else if (Input.GetKey("left") || Input.GetKey("a"))
		{
			animator.SetInteger("Direction", 1);
			animator.SetBool("Move", true);
		}
		else if (!Input.anyKey)
		{
			animator.SetBool("Move", false);
		}

		if (Input.GetKeyDown(KeyCode.Space) && myTime > nextFire)
		{
			animator.SetTrigger("Attack");
			nextFire = myTime + fireDelay;
			Invoke("Fire", 0.5F * 2);
			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2) && myTime > nextFire)
		{
			animator.SetTrigger("UseAbility");
			nextFire = myTime + fireDelay;
			Invoke("Shield", 2F);
			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
		transform.Translate(horizontal * speed, vertical * speed, 0);
	}

	void Fire()
	{
		if (animator.GetInteger("Direction") == 0)
		{
			var spell = Instantiate(SpellPrefabSouth, SpellSpawn.position, SpellSpawn.rotation);
			spell.GetComponent<Rigidbody2D>().AddForce(spell.transform.up * -1 * shotSpeed);
			Destroy(spell, 1.333f);
		}
		else if (animator.GetInteger("Direction") == 1)
		{
			var spell = Instantiate(SpellPrefabWest, SpellSpawn.position, SpellSpawn.rotation);
			spell.GetComponent<Rigidbody2D>().AddForce(spell.transform.right * -1 * shotSpeed);
			Destroy(spell, 1.333f);
		}
		else if (animator.GetInteger("Direction") == 2)
		{
			var spell = Instantiate(SpellPrefabNorth, SpellSpawn.position, SpellSpawn.rotation);
			spell.GetComponent<Rigidbody2D>().AddForce(spell.transform.up * shotSpeed);
			Destroy(spell, 1.333f);
		}
		else if (animator.GetInteger("Direction") == 3)
		{
			var spell = Instantiate(SpellPrefabEast, SpellSpawn.position, SpellSpawn.rotation);
			spell.GetComponent<Rigidbody2D>().AddForce(spell.transform.right * shotSpeed);
			Destroy(spell, 1.333f);
		}
	}

	void Shield()
	{
		var shield = Instantiate(ShieldSpell, SpellSpawn.position, SpellSpawn.rotation);
		Destroy(shield, 5F);
	}
}
