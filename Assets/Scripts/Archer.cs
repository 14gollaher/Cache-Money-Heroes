using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Archer : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer SpriteRend;
    public Rigidbody2D rb2d;
    public GameObject ArrowPrefab;
    public GameObject WolfPrefab;
    public Transform ArrowSpawn;
    public int enemiesForKeyPublic;
    // Player Stats
    public float speed = 1F;
    public int health = 16;
    //public int focus = 3;
	public GameObject PMenu;
	public GameObject InventoryView;
	public static int InventoryState = 0;

    // Firing Speed
    public int shotSpeed = 12000;
    public float fireDelay = 0.25F;
    private float nextFire = 0.25F;
    private float myTime = 0.0F;
    private float invisibleTimeStamp;
    private float immuneTimeStamp;
    public static bool isInvisible = false;
    private static bool isImmune = false;
    private float transformX;
    private float transformY;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        SpriteRend = this.GetComponent<SpriteRenderer>();

        if (transformX == -1F && transformY == -1F)
        {
            transformX = 1041F;
            transformY = -3127F;
        }

        if (SceneManager.GetActiveScene().name == "EarthDungeon")
        {
        }
        else if (SceneManager.GetActiveScene().name == "GrassDungeon")
        {
        }

        else if (SceneManager.GetActiveScene().name == "IceDungeon")
        {
        }

        else if (SceneManager.GetActiveScene().name == "FireDungeon")
        {
        }

        else if (SceneManager.GetActiveScene().name == "CastleFront")
        {


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyMelee" || collision.gameObject.tag == "BossEnemy")
        {
            if (!isImmune)
            {
				UIManager.healthValue = UIManager.healthValue - (3 - UIManager.defense);
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

        else if (collision.gameObject.tag == "Key" && "EarthDungeon" == PlayerPrefs.GetString("previousScene"))
        {
            SceneManager.LoadScene("Outdoor");
            transform.position = new Vector3(1876, -2529);

        }

        else if (collision.gameObject.tag == "Key" && "GrassDungeon" == PlayerPrefs.GetString("previousScene"))
        {
            SceneManager.LoadScene("Outdoor");
        }

        else if (collision.gameObject.tag == "Key" && "FireDungeon" == PlayerPrefs.GetString("previousScene"))
        {
            SceneManager.LoadScene("Outdoor");
        }

        else if (collision.gameObject.tag == "Key" && "IceDungeon" == PlayerPrefs.GetString("previousScene"))
        {
            SceneManager.LoadScene("Outdoor");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EarthDungeonTransition")
        {
            //PlayerPrefs.SetFloat("TransformX", 742.2964F);
            //PlayerPrefs.SetFloat("TransformY", -789.8214F);
            SceneManager.LoadScene("EarthDungeon");
        }
        else if (other.gameObject.tag == "GrassDungeonTransition")
        {
            //PlayerPrefs.SetFloat("TransformX", 1123F);
            //PlayerPrefs.SetFloat("TransformY", -486F);
            SceneManager.LoadScene("GrassDungeon");
        }

        else if (other.gameObject.tag == "IceDungeonTransition")
        {

            //PlayerPrefs.SetFloat("TransformX", 959.4304F);
            //PlayerPrefs.SetFloat("TransformY", -864.0476F);
            SceneManager.LoadScene("IceDungeon");
        }

        else if (other.gameObject.tag == "FireDungeonTransition")
        {
            //PlayerPrefs.SetFloat("TransformX", -1741.483F);
            //PlayerPrefs.SetFloat("TransformY", -1360.215F);
            SceneManager.LoadScene("FireDungeon");
        }

        else if (other.gameObject.tag == "CastleFrontTransition")
        {
            PlayerPrefs.SetFloat("TransformX", 1601.054F);
            PlayerPrefs.SetFloat("TransformY", -2279.273F);
            SceneManager.LoadScene("CastleFront");
        }
    }

    // Update is called once per frame
    void Update()
    {
		health = UIManager.healthValue;
		if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        if (isInvisible == true)
        {
            if (invisibleTimeStamp < Time.time)
            {
                SpriteRend.color = new Color(1F, 1F, 1F, 1F);
                isInvisible = false;
            }
        }

        if (isImmune == true)
        {
            if (immuneTimeStamp < Time.time)
            {
                SpriteRend.color = new Color(1F, 1F, 1F, 1F);
                isImmune = false;
            }
        }

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        myTime = myTime + Time.deltaTime;

        // Controls Movement
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

        // Controls Attack and FireRate
        if (Input.GetKeyDown(KeyCode.Space) && myTime > nextFire)
        {
            // Need to fix the fire rate
            animator.SetTrigger("Attack");
            nextFire = myTime + fireDelay;
            Invoke("Fire", 0.7692308F / 2);
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && myTime > nextFire)
        {
            // Need to fix the fire rate
            animator.SetTrigger("Attack");
            nextFire = myTime + fireDelay;
            Invoke("TripleShot", 0.7692308F / 2);
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }

        // Cloak Ability
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("UseAbility");
            invisibleTimeStamp = Time.time + 5;
            Cloak();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("UseAbility");
            Wolf();
        }

		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			PMenu.SetActive (true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown (KeyCode.Alpha9)) {
			if (InventoryState == 0) {
				InventoryView.SetActive (true);
				InventoryState = 1;
			} else {
				InventoryView.SetActive (false);
				InventoryState = 0;
			}

		}
        // Move the player
        transform.Translate(horizontal * speed, vertical * speed, 0);
    }

    void Fire()
    {
        if (animator.GetInteger("Direction") == 0)
        {
            var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 90));
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -1 * shotSpeed);
            Destroy(arrow, 3.0f);
        }
        else if (animator.GetInteger("Direction") == 1)
        {
            var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 360));
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -1 * shotSpeed);
            Destroy(arrow, 3.0f);
        }
        else if (animator.GetInteger("Direction") == 2)
        {
            var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 0, 270));
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -1 * shotSpeed);
            Destroy(arrow, 3.0f);
        }
        else if (animator.GetInteger("Direction") == 3)
        {
            var arrow = (GameObject)Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.Euler(0, 180, 0));
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -1 * shotSpeed);
            Destroy(arrow, 3.0f);
        }
    }
    void TripleShot()
    {
		if (UIManager.manaValue >= 1) {
			UIManager.manaValue--;
			if (animator.GetInteger ("Direction") == 0) {
				var arrow = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 70));
				var arrow2 = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 90));
				var arrow3 = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 110));

				arrow.GetComponent<Rigidbody2D> ().AddForce (arrow.transform.right * -1 * shotSpeed);
				arrow2.GetComponent<Rigidbody2D> ().AddForce (arrow2.transform.right * -1 * shotSpeed);
				arrow3.GetComponent<Rigidbody2D> ().AddForce (arrow3.transform.right * -1 * shotSpeed);

				Destroy (arrow, 3.0f);
				Destroy (arrow2, 3.0f);
				Destroy (arrow3, 3.0f);
			} else if (animator.GetInteger ("Direction") == 1) {
				var arrow = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 340));
				var arrow2 = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 360));
				var arrow3 = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 380));

				arrow.GetComponent<Rigidbody2D> ().AddForce (arrow.transform.right * -1 * shotSpeed);
				arrow2.GetComponent<Rigidbody2D> ().AddForce (arrow2.transform.right * -1 * shotSpeed);
				arrow3.GetComponent<Rigidbody2D> ().AddForce (arrow3.transform.right * -1 * shotSpeed);

				Destroy (arrow, 3.0f);
				Destroy (arrow2, 3.0f);
				Destroy (arrow3, 3.0f);
			} else if (animator.GetInteger ("Direction") == 2) {
				var arrow = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 250));
				var arrow2 = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 270));
				var arrow3 = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 0, 290));

				arrow.GetComponent<Rigidbody2D> ().AddForce (arrow.transform.right * -1 * shotSpeed);
				arrow2.GetComponent<Rigidbody2D> ().AddForce (arrow2.transform.right * -1 * shotSpeed);
				arrow3.GetComponent<Rigidbody2D> ().AddForce (arrow3.transform.right * -1 * shotSpeed);

				Destroy (arrow, 3.0f);
				Destroy (arrow2, 3.0f);
				Destroy (arrow3, 3.0f);
			} else if (animator.GetInteger ("Direction") == 3) {

				var arrow = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 180, -20));
				var arrow2 = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 180, 0));
				var arrow3 = (GameObject)Instantiate (ArrowPrefab, ArrowSpawn.position, Quaternion.Euler (0, 180, 20));

				arrow.GetComponent<Rigidbody2D> ().AddForce (arrow.transform.right * -1 * shotSpeed);
				arrow2.GetComponent<Rigidbody2D> ().AddForce (arrow2.transform.right * -1 * shotSpeed);
				arrow3.GetComponent<Rigidbody2D> ().AddForce (arrow3.transform.right * -1 * shotSpeed);

				Destroy (arrow, 3.0f);
				Destroy (arrow2, 3.0f);
				Destroy (arrow3, 3.0f);
			}
		}
    }
    void Cloak()
    {
		if (UIManager.manaValue >= 3) {
			UIManager.manaValue = UIManager.manaValue - 3;
			SpriteRend.color = new Color (1F, 1F, 1F, 0.25F);
			isInvisible = true;
			if (UIManager.healthValue < UIManager.maxHealth)
				UIManager.healthValue++;
		}
    }
    void Wolf()
    {
		if (UIManager.manaValue >= 5) {
			UIManager.manaValue = UIManager.manaValue - 5;
			var go = Instantiate (WolfPrefab);
			Transform thisPlayer = transform;
			go.SendMessage ("TheStart", thisPlayer);
		}
    }

}