using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button startText;
    public Button exitText; 
    public Button highscoreText;
	public Button controlsText;
	public Button controlsExit;
	public GameObject CMenu;
	public static int CMint = 0;
    // Use this for initialization
    void Start()
    {
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        highscoreText = highscoreText.GetComponent<Button>();
		controlsText = controlsText.GetComponent<Button> ();
		controlsExit = controlsExit.GetComponent<Button> ();


        PlayerPrefs.SetFloat("TransformX", -1F);
        PlayerPrefs.SetFloat("TransformY", -1F);
        PlayerPrefs.SetInt("highScore", 0);

    }

    public void ExitPress() //this function will be used on our Exit button
    {
        startText.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
        exitText.enabled = false;
        highscoreText.enabled = false;
        Application.Quit(); //this will quit our game. Note this will only work after building the game
    }
    public void StartLevel() //this function will be used on our Play button
	{
        SceneManager.LoadScene("CharacterSelect"); //this will load our first level from our build settings. "1" is the second scene in our game
    }

    public void HighScorePress()
    {	
        SceneManager.LoadScene("High Scores");
    }

    public void CreditsPress()
    {
        SceneManager.LoadScene("Credits");
    }


    public void CButton(){
		if(CMint == 0)
			CMenu.SetActive(true);
		CMint = 1;
	}

	public void ExitControls(){
		if(CMint == 1)
			CMenu.SetActive(false);
		CMint = 0;
	}
    // Update is called once per frame
    void Update()
    {

    }
}
