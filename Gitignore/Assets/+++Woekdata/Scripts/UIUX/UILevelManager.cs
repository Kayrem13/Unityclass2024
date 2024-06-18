using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UILevelManager : MonoBehaviour
{

    //serialized fields for panels, buttons etc.
    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonPlayAgain;

    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private Button buttonPlayAgainLose;

    [SerializeField] private Button buttonBackToMain;
    [SerializeField] private Button buttonBackToMainOnLose;
    
    [SerializeField] private string nameNextScene;

    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI txtCoinCount;
    
    // Start is called before the first frame update
    void Start()
    {
        //the time scale is set to one and the coin count will be put as String
        Time.timeScale = 1f;
        txtCoinCount.text = coinCount.ToString();
        //panelWin.alpha = 0f;
        //panelWin.interactable = false;
        //panelWin.blocksRaycasts = false;
        
        //hides the canvas upon starting the game until activation
        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        
        //sets functions for clicking on the buttons declared in the serialized fields
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonPlayAgain.onClick.AddListener(RestartLevel);
        buttonBackToMain.onClick.AddListener(BackToMenu);
        buttonBackToMainOnLose.onClick.AddListener(BackToMenu);
    }

    
    //function if the player wins
    public void OnGameWin()
    {
        //win panel will be shown and time scale gets paused, next scene can be loaded
        panelWin.ShowCanvasGroup();
        PlayerPrefs.SetInt(nameNextScene, 1);
        Time.timeScale = 0f;
        //winscreen show
    }
    

    //function if the player loses
    public void OnGameLose()
    {
        //shows the lose panel and time scale gets paused
        panelLose.ShowCanvasGroup();
        Time.timeScale = 0f;
        //losescreen show
    }

    //function upon collecting a coin
    public void AddCoin()
    {
        //adds a coin to the counter and converts it to show in the string
        coinCount++;
        txtCoinCount.text = coinCount.ToString();
    }
    
    //function upon restarting a level
    void RestartLevel()
    {
        //reloads the scene to start anew
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    //function to load the next level
    void LoadNextLevel()
    {
        //loads the next scene in the scene manager
        SceneManager.LoadScene(nameNextScene);
        //
    }
    
    //function to get back to the main menu
    void BackToMenu()
    {
        //loads the menu scene
        SceneManager.LoadScene("Menu");
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class UIExtensions
{
    //function to make the canvas invisible
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    
    //function to make a canvas from the group visible
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}