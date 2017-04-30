using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitioner : MonoBehaviour {

    public string nextScene;
    public int enemiesToKill;
    public static int enemiesKilled;


    // Use this for initialization
    void Start () {

        enemiesKilled = 0;
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (nextScene != "CastleFront")
        {
            if (enemiesKilled == enemiesToKill)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
        else
        {
            if (InventoryManager.keyValue == 4)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
