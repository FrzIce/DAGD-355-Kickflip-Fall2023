using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript_Trevor : MonoBehaviour
{
    public GameObject recallCollision;
    public GameObject healthPotion;
    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

    }

    


    public void explosionActive()
    {
        recallCollision.SetActive(true);
    }
    public void explosionDeActivate()
    {
        recallCollision.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene("Final_Scene_Trevor");
    }

    public void endGame()
    {
        SceneManager.LoadScene("Game_Over_Menu");
    }

    

    
}
