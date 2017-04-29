using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;



public class Credits : MonoBehaviour
{

    public Button back;
    public UIManager uiManager;


    // Use this for initialization
    void Start()
    {
        back = back.GetComponent<Button>();
    }


    public void ReturnButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
