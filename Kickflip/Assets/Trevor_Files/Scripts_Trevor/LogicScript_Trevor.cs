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
        
        
    }

    


    public void explosionActive()
    {
        recallCollision.SetActive(true);
    }
    public void explosionDeActivate()
    {
        recallCollision.SetActive(false);
    }

    

    
}
