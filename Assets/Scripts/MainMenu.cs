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

    void Start()
    {
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        highscoreText = highscoreText.GetComponent<Button>();
		controlsText = controlsText.GetComponent<Button> ();
		controlsExit = controlsExit.GetComponent<Button> ();

        PlayerPrefs.SetFloat("TransformX", -1F);
        PlayerPrefs.SetFloat("TransformY", -1F);

        PlayerPrefs.SetInt("FireDungeon", 0);
        PlayerPrefs.SetInt("EarthDungeon", 0);
        PlayerPrefs.SetInt("IceDungeon", 0);
        PlayerPrefs.SetInt("GrassDungeon", 0);
    }

    public void ExitPress() 
    {
        startText.enabled = false; 
        exitText.enabled = false;
        highscoreText.enabled = false;
        Application.Quit(); 
    }

    public void StartLevel() 
	{
        SceneManager.LoadScene("CharacterSelect"); 
    }

    public void HighScorePress()
    {	
        SceneManager.LoadScene("High Scores");
    }

    public void CreditsPress()
    {
        SceneManager.LoadScene("Credits");
    }

    public void CButton()
    {
		if(CMint == 0)
			CMenu.SetActive(true);
		CMint = 1;
	}

	public void ExitControls()
    {
		if(CMint == 1)
			CMenu.SetActive(false);
		CMint = 0;
	}

    void Update()
    {

    }
}
