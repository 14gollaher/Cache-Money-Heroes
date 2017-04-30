using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniDungeonManager : MonoBehaviour
{
    public int enemiesForKeyPublic;
    public static int enemiesForKeyPrivate;
    public GameObject Key;
    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        enemiesForKeyPrivate = enemiesForKeyPublic;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (enemiesForKeyPrivate == 0 && SceneManager.GetActiveScene().name == "EarthDungeon")
        {
            Instantiate(Key, new Vector3(2553.841F, -2524.532F, -1F), new Quaternion(0, 0, 0, 0));
            enemiesForKeyPrivate = -1;
        }

        else if (enemiesForKeyPrivate == 0 && SceneManager.GetActiveScene().name == "GrassDungeon")
        {
            Instantiate(Key, new Vector3(50F, -1967F, -1F), new Quaternion(0, 0, 0, 0));
            enemiesForKeyPrivate = -1;
        }

        else if (enemiesForKeyPrivate == 0 && SceneManager.GetActiveScene().name == "FireDungeon")
        {
            Instantiate(Key, new Vector3(2537.329F, -2188.224F, -1F), new Quaternion(0, 0, 0, 0));
            enemiesForKeyPrivate = -1;
        }

        else if (enemiesForKeyPrivate == 0 && SceneManager.GetActiveScene().name == "IceDungeon")
        {
            Instantiate(Key, new Vector3(2528F, -2676F, -1F), new Quaternion(0, 0, 0, 0));
            enemiesForKeyPrivate = -1;
        }
    }
}
