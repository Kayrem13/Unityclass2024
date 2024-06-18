using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Interactions : MonoBehaviour
{
    //declares a ui level manager
    private UILevelManager uiLevelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //upon starting searches and finds a object of ui level manager type
        uiLevelManager = FindObjectOfType<UILevelManager>();
    }

    //funtion for the triggers
    private void OnTriggerEnter2D(Collider2D other)
       {
           //if the collider of collides with an object tagged win, the win panel will show
           if (other.CompareTag("Goal"))
           {
               //on game win funtion will be activated
               Debug.Log("you Win");
               uiLevelManager.OnGameWin();
           }
           
           //if the death tag collides with the collider the lose panel will show
           else if (other.CompareTag("Death"))
           {
               //uses the function on game lose
               Debug.Log("you lose");
               uiLevelManager.OnGameLose();
           }
           
           //upon collecting a coin will add to the counter and destroy the coin object
           else if (other.CompareTag("Coin"))
           {
               //uses function add coin
               uiLevelManager.AddCoin();
               //destroys the coin
               Destroy(other.gameObject);
           }
       }
}
