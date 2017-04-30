using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {

	public Button resumeText;
	public Button exitText;
	public Button HButton;
	public Button HExit;
	public Button SButton;
	public Button SExit;
	public GameObject PMenu;
	public GameObject HMenu;
	public GameObject SScreen;

	void Start()
	{
		resumeText = resumeText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
	}

	public void ExitPress()
	{
		resumeGame ();
		SceneManager.LoadScene ("MainMenu");
	}
	public void resumeGame() 
	{
        Time.timeScale = 1;
        PMenu.SetActive (false);
	}

	public void helpButton()
	{
		HMenu.SetActive (true);
	}

	public void hExitButton(){
		HMenu.SetActive (false);
	}

	public void statusButton()
	{
		SScreen.SetActive (true);
	}

	public void sExitButton(){
		SScreen.SetActive (false);
	}

	void Update()
	{

	}
}