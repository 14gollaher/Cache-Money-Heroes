using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public static int defense = 1;
    public static int attack = 1;

    public static int maxHealth = 12;
    public static int healthValue = 12;
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

    public static int maxMana = 5;
    public static int manaValue = 5;
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

    public GameObject S1;
    public GameObject S2;
    public GameObject S3;

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        scoreText.text = "Score : " + HighScores.highScoreValue;
        if (maxHealth >= 16)
            HE.SetActive(true);
        else
            HE.SetActive(false);

        if (healthValue >= 4)
            HF1.SetActive(true);
        else
            HF1.SetActive(false);

        if (healthValue >= 3)
            HTQ1.SetActive(true);
        else
            HTQ1.SetActive(false);

        if (healthValue >= 2)
            HH1.SetActive(true);
        else
            HH1.SetActive(false);

        if (healthValue >= 1)
            HQ1.SetActive(true);
        else
            HQ1.SetActive(false);

        if (healthValue >= 8)
            HF2.SetActive(true);
        else
            HF2.SetActive(false);

        if (healthValue >= 7)
            HTQ2.SetActive(true);
        else
            HTQ2.SetActive(false);

        if (healthValue >= 6)
            HH2.SetActive(true);
        else
            HH2.SetActive(false);

        if (healthValue >= 5)
            HQ2.SetActive(true);
        else
            HQ2.SetActive(false);

        if (healthValue >= 12)
            HF3.SetActive(true);
        else
            HF3.SetActive(false);

        if (healthValue >= 11)
            HTQ3.SetActive(true);
        else
            HTQ3.SetActive(false);

        if (healthValue >= 10)
            HH3.SetActive(true);
        else
            HH3.SetActive(false);

        if (healthValue >= 9)
            HQ3.SetActive(true);
        else
            HQ3.SetActive(false);

        if (healthValue == 16)
            HF4.SetActive(true);
        else
            HF4.SetActive(false);

        if (healthValue >= 15)
            HTQ4.SetActive(true);
        else
            HTQ4.SetActive(false);

        if (healthValue >= 14)
            HH4.SetActive(true);
        else
            HH4.SetActive(false);

        if (healthValue >= 13)
            HQ4.SetActive(true);
        else
            HQ4.SetActive(false);

        if (maxMana >= 10)
            MB.SetActive(true);
        else
            MB.SetActive(false);

        if (manaValue == 10)
            M10.SetActive(true);
        else
            M10.SetActive(false);

        if (manaValue >= 9)
            M9.SetActive(true);
        else
            M9.SetActive(false);

        if (manaValue >= 8)
            M8.SetActive(true);
        else
            M8.SetActive(false);

        if (manaValue >= 7)
            M7.SetActive(true);
        else
            M7.SetActive(false);

        if (manaValue >= 6)
            M6.SetActive(true);
        else
            M6.SetActive(false);

        if (manaValue >= 5)
        {
            M5.SetActive(true);
            S3.SetActive(true);
        }
        else
        {
            M5.SetActive(false);
            S3.SetActive(false);
        }

        if (manaValue >= 4)
            M4.SetActive(true);
        else
            M4.SetActive(false);

        if (manaValue >= 3)
        {
            M3.SetActive(true);
            S2.SetActive(true);
        }
        else
        {
            M3.SetActive(false);
            S2.SetActive(false);
        }

        if (manaValue >= 2)
            M2.SetActive(true);
        else
            M2.SetActive(false);

        if (manaValue >= 1)
        {
            M1.SetActive(true);
            S1.SetActive(true);
        }
        else
        {
            M1.SetActive(false);
            S1.SetActive(false);
        }
    }
}
