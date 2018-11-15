using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameController instance;
    public string nextlevel;
 
    public  GameObject staminabarinstance;
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
       // staminabarinstance = staminabarinstance.GetComponent<StaminaController>();
        //Debug.Log(Inventory_.instance.items.Count);
    }
    // Update is called once per frame
    void Update()
    {
        ResetScene();
        QuitGame();
        BackScene();
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
    private void BackScene()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
     SceneManager.LoadScene(nextlevel);
        }
    }

}
