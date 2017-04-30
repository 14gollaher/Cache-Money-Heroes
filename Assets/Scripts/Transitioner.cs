using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitioner : MonoBehaviour
{
    public string nextScene;
    public int enemiesToKill;
    public static int enemiesKilled;

    // Use this for initialization
    void Start ()
    {
        enemiesKilled = 0;
	}

	// Update is called once per frame
	void Update ()
    {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerPrefs.GetInt("FireDungeon") == 0 && nextScene == "FireDungeon")
        {
            SceneManager.LoadScene(nextScene);
            PlayerPrefs.SetInt("FireDungeon", 1);
        }

        else if (PlayerPrefs.GetInt("EarthDungeon") == 0 && nextScene == "EarthDungeon")
        {
            SceneManager.LoadScene(nextScene);
            PlayerPrefs.SetInt("EarthDungeon", 1);
        }

        else if (PlayerPrefs.GetInt("IceDungeon") == 0 && nextScene == "IceDungeon")
        {
            SceneManager.LoadScene(nextScene);
            PlayerPrefs.SetInt("IceDungeon", 1);
        }

        else if (PlayerPrefs.GetInt("GrassDungeon") == 0 && nextScene == "GrassDungeon")
        {
            SceneManager.LoadScene(nextScene);
            PlayerPrefs.SetInt("GrassDungeon", 1);
        }

        else if (nextScene == "CastleFront")
        {
            if (InventoryManager.keyValue == 4)
            {
                SceneManager.LoadScene(nextScene);
            }
        }

        else
        {
            if (enemiesKilled == enemiesToKill)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
