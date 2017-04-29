using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class HighScores : MonoBehaviour
{
    public Button backButton;
    public Text highScore;

    // Use this for initialization
    void Start()
    {
        backButton = backButton.GetComponent<Button>();
        highScore.text = File.ReadAllText("highScores.txt").ToString();

    }


    public void BackButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
