using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameController instance;
    public string nextlevel;
 
    public  Image staminabarinstance;
//  public  StaminaController staminaCtrl;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start()
    {
        staminabarinstance = staminabarinstance.GetComponent<Image>();
        //Debug.Log(Inventory_.instance.items.Count);
    }
    // Update is called once per frame
    void Update()
    {
        ResetScene();
        QuitGame();
        Menu();
        Level1();
        Level2();
        GameOver();
    }
    private void ResetScene()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            staminabarinstance.GetComponent<Image>().fillAmount =staminabarinstance.GetComponent<StaminaController>().staminabar;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void Menu()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    private void Level1()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("Level1");
        }
    }
    private void Level2()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Level2");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
     SceneManager.LoadScene(nextlevel);
        }
    }
    void GameOver()
    {
       if(staminabarinstance.fillAmount <= 0f)
        {
            staminabarinstance.GetComponent<Image>().fillAmount = staminabarinstance.GetComponent<StaminaController>().staminabar;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
