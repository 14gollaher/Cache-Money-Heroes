using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

	public Button ArcherB;
	public Button WizardB;
	public Button KnightB;

	// Use this for initialization
	void Start()
	{
		ArcherB = ArcherB.GetComponent<Button>();
		WizardB = WizardB.GetComponent<Button>();
		KnightB = KnightB.GetComponent<Button>();

		 
	}

	public void ArcherSelect() //this function will be used on our Exit button
	{
		UIManager.manaValue = 5;
		UIManager.healthValue = 12;
		InventoryManager.keyValue = 0;
		UIManager.maxMana = 5;
		UIManager.maxHealth = 12;
		SceneManager.LoadScene("Outdoor");
		InventoryManager.RPnum = 0;
		InventoryManager.BPnum = 0;
		InventoryManager.Chnum = 0;
		InventoryManager.Cunum = 0;
	}
	//public void WizardSelect() //this function will be used on our Play button
	//{
	//}

	//public void KnightSelect()
	//{	
	//}

	// Update is called once per frame
	void Update()
	{

	}
}