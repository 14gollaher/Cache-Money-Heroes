using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public static int keyValue;
	public int InternalKeyNum;
	public GameObject Key1;
	public GameObject Key2;
	public GameObject Key3;
	public GameObject Key4;

	public static int RPnum = 0;
	public static int BPnum = 0;
	public static int Cunum = 0;
	public static int Chnum = 0;
	public GameObject RP;
	public GameObject BP;
	public GameObject Cu;
	public GameObject Ch;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Key HUD Handlers
		InternalKeyNum = keyValue;

		if (keyValue >= 1) {
			Key1.SetActive (true);
		}
		if (keyValue >= 2) {
			Key2.SetActive (true);
		}
		if (keyValue >= 3) {
			Key3.SetActive (true);
		}
		if (keyValue == 4) {
			Key4.SetActive (true);
		}

		if (RPnum > 0) {
			RP.SetActive (true);
		}
		if (BPnum > 0) {
			BP.SetActive (true);
		}
		if (Cunum > 0) {
			Cu.SetActive (true);
		}
		if (Chnum > 0) {
			Ch.SetActive (true);
		}

	}
}
