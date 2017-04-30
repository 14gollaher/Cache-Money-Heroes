using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusScreen : MonoBehaviour
{
	public GameObject HE;
	public GameObject HQ1;
	public GameObject HH1;
	public GameObject HTQ1;
	public GameObject HF1; 
	public GameObject HQ2;
	public GameObject HH2;
	public GameObject HTQ2;
	public GameObject HF2; 
	public GameObject HQ3;
	public GameObject HH3;
	public GameObject HTQ3;
	public GameObject HF3; 
	public GameObject HQ4;
	public GameObject HH4;
	public GameObject HTQ4;
	public GameObject HF4; 

	public GameObject MB;
	public GameObject M1;
	public GameObject M2;
	public GameObject M3;
	public GameObject M4; 
	public GameObject M5;
	public GameObject M6;
	public GameObject M7;
	public GameObject M8; 
	public GameObject M9;
	public GameObject M10;

	public GameObject Key1;
	public GameObject Key2;
	public GameObject Key3;
	public GameObject Key4;

	public GameObject RP;
	public GameObject BP;
	public GameObject Cu;
	public GameObject Ch;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		//Heart HUD Handler
		if (UIManager.maxHealth >= 16)
			HE.SetActive (true);
		else
			HE.SetActive (false);

		if (UIManager.healthValue >= 4) 
			HF1.SetActive (true);
		else
			HF1.SetActive (false);

		if (UIManager.healthValue >= 3)
			HTQ1.SetActive (true);
		else
			HTQ1.SetActive (false);

		if (UIManager.healthValue >= 2)
			HH1.SetActive (true);
		else
			HH1.SetActive (false);

		if (UIManager.healthValue >= 1)
			HQ1.SetActive (true);
		else
			HQ1.SetActive (false);

		if (UIManager.healthValue >= 8) 
			HF2.SetActive (true);
		else
			HF2.SetActive (false);

		if (UIManager.healthValue >= 7)
			HTQ2.SetActive (true);
		else
			HTQ2.SetActive (false);

		if (UIManager.healthValue >= 6)
			HH2.SetActive (true);
		else
			HH2.SetActive (false);

		if (UIManager.healthValue >= 5)
			HQ2.SetActive (true);
		else
			HQ2.SetActive (false);

		if (UIManager.healthValue >= 12) 
			HF3.SetActive (true);
		else
			HF3.SetActive (false);

		if (UIManager.healthValue >= 11)
			HTQ3.SetActive (true);
		else
			HTQ3.SetActive (false);

		if (UIManager.healthValue >= 10)
			HH3.SetActive (true);
		else
			HH3.SetActive (false);

		if (UIManager.healthValue >= 9)
			HQ3.SetActive (true);
		else
			HQ3.SetActive (false);

		if (UIManager.healthValue == 16) 
			HF4.SetActive (true);
		else
			HF4.SetActive (false);

		if (UIManager.healthValue >= 15)
			HTQ4.SetActive (true);
		else
			HTQ4.SetActive (false);

		if (UIManager.healthValue >= 14)
			HH4.SetActive (true);
		else
			HH4.SetActive (false);

		if (UIManager.healthValue >= 13)
			HQ4.SetActive (true);
		else
			HQ4.SetActive (false);

		//Focus and Special Bottun HUD Handler
		if (UIManager.maxMana >= 10)
			MB.SetActive (true);
		else
			MB.SetActive (false);

		if (UIManager.manaValue == 10)
			M10.SetActive (true);
		else 
			M10.SetActive (false);

		if (UIManager.manaValue >= 9)
			M9.SetActive (true);
		else 
			M9.SetActive (false);

		if (UIManager.manaValue >= 8)
			M8.SetActive (true);
		else 
			M8.SetActive (false);

		if (UIManager.manaValue >= 7)
			M7.SetActive (true);
		else 
			M7.SetActive (false);

		if (UIManager.manaValue >= 6)
			M6.SetActive (true);
		else 
			M6.SetActive (false);

		if (UIManager.manaValue >= 5) {
			M5.SetActive (true);
		} else {
			M5.SetActive (false);
		}

        if (UIManager.manaValue >= 4)
			M4.SetActive (true);
		else 
			M4.SetActive (false);

		if (UIManager.manaValue >= 3) {
			M3.SetActive (true);
		} else {
			M3.SetActive (false);
		}

		if (UIManager.manaValue >= 2)
			M2.SetActive (true);
		else 
			M2.SetActive (false);

		if (UIManager.manaValue >= 1) {
			M1.SetActive (true);
		} else {
			M1.SetActive (false);
		}
			
		if (InventoryManager.keyValue >= 1) {
			Key1.SetActive (true);
			}
		if (InventoryManager.keyValue >= 2) {
			Key2.SetActive (true);
			}
		if (InventoryManager.keyValue >= 3) {
			Key3.SetActive (true);
			}
		if (InventoryManager.keyValue == 4) {
			Key4.SetActive (true);
			}

        if (InventoryManager.RPnum > 0) {
			RP.SetActive (true);
			}
		if (InventoryManager.BPnum > 0) {
			BP.SetActive (true);
			}
		if (InventoryManager.Cunum > 0) {
			Cu.SetActive (true);
			}
		if (InventoryManager.Chnum > 0) {
			Ch.SetActive (true);
			}
	}
}
