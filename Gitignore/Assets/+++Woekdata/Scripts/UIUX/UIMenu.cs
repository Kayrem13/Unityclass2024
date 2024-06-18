using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    //serialized fields for panels buttons and co.
    [SerializeField] private CanvasGroup panelMain;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonLevelSelection;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button exitButton;
    
    [SerializeField] private CanvasGroup panelLevelSelection;
    [SerializeField] private Button buttonBackToMain;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    [SerializeField] private Button buttonLevel3;
    [SerializeField] private Button buttonLevel4;

    [SerializeField] private CanvasGroup panelSettings;
    [SerializeField] private Button buttonBackToMainFromSettings;

    [SerializeField] private string[] levelNames;
    // Start is called before the first frame update
    void Start()
    {
        //upon starting, adds button functions and hides all canvas except main
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
        panelSettings.HideCanvasGroup();
        
        buttonLevelSelection.onClick.AddListener(ShowLevelSelection);
        buttonSettings.onClick.AddListener(ShowSettings);
        
        buttonNewGame.onClick.AddListener(LoadLevel1);
        buttonBackToMain.onClick.AddListener(ShowMainPanel);
        buttonBackToMainFromSettings.onClick.AddListener(ShowMainPanel);
        
        buttonLevel1.onClick.AddListener(LoadLevel1);
        buttonLevel2.onClick.AddListener(LoadLevel2);
        buttonLevel3.onClick.AddListener(LoadLevel3);
        buttonLevel4.onClick.AddListener(LoadLevel4);
        
        exitButton.onClick.AddListener(ExitGame);

        //these functions set the button to not interactable until completion of the previous level
        buttonLevel2.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[1]))
        {
           if (PlayerPrefs.GetInt(levelNames[1]) == 1)
           {
               buttonLevel2.interactable = true;
           }
        }

        buttonLevel3.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[2]))
        {
            if (PlayerPrefs.GetInt(levelNames[2]) == 1)
            {
                buttonLevel3.interactable = true;
            }
        }
        
        buttonLevel4.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[3]))
        {
            if (PlayerPrefs.GetInt(levelNames[3]) == 1)
            {
                buttonLevel4.interactable = true;
            }
        }
    }

    //function to show the level selection panel and hides the other panels
    void ShowLevelSelection()
    {
        panelMain.HideCanvasGroup();
        panelLevelSelection.ShowCanvasGroup();
        panelSettings.HideCanvasGroup();
    }
    
    //function to set the settings panel visible and hide the other panels
    void ShowSettings()
    {
        panelMain.HideCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
        panelSettings.ShowCanvasGroup();
    }

    //function to set the main panel visible and hide the other panels
    void ShowMainPanel()
    {
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
        panelSettings.HideCanvasGroup();
    }

    //function to exit the game
    void ExitGame()
    {
        //quits application
        Application.Quit();
    }
    

    //loads level 1
    void LoadLevel1()
    {
        SceneManager.LoadScene(levelNames[0]);
    }
   
    //loads level 2
    void LoadLevel2()
    {
        SceneManager.LoadScene(levelNames[1]);
    }
    
    //loads level 3
    void LoadLevel3()
    {
        SceneManager.LoadScene(levelNames[2]);
    }
    
    //loads the extra level 4
    void LoadLevel4()
    {
        SceneManager.LoadScene(levelNames[3]);
    }
}
