using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class HighScores : MonoBehaviour
{
    public Button backButton;
    public Text highScore;
    public static int highScoreValue = 0;

    // Use this for initialization
    void Start()
    {
        backButton = backButton.GetComponent<Button>();
        highScore.text = "Archer : " + File.ReadAllText("HighScores.txt").ToString();
        
    }


    public void BackButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
