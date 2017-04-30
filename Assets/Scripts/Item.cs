using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	}
	// Update is called once per frame
	void Update ()
    {
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{ 
			if (this.tag == "Item4")
            {
				UIManager.maxHealth = UIManager.maxHealth + 4;
				UIManager.healthValue = UIManager.healthValue + 4;
				InventoryManager.RPnum++;
			}

			if (this.tag == "Item3")
            {
				UIManager.maxMana = UIManager.maxMana + 5;
				UIManager.manaValue = UIManager.manaValue + 5;
				InventoryManager.BPnum++;
			}

			if (this.tag == "Item2")
            {
				UIManager.defense = UIManager.defense + 1;
				InventoryManager.Cunum++;
			}

			if (this.tag == "Item1")
            {
				UIManager.attack = UIManager.attack + 1;
				InventoryManager.Chnum++;
			}

			Destroy(gameObject);
		}
	}
}
