using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelMain;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonLevelSelection;
    
    [SerializeField] private CanvasGroup panelLevelSelection;
    [SerializeField] private Button buttonBackToMain;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    [SerializeField] private Button buttonLevel3;

    [SerializeField] private string[] levelNames;
    // Start is called before the first frame update
    void Start()
    {
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
        
        buttonLevelSelection.onClick.AddListener(ShowLevelSelection);
        buttonNewGame.onClick.AddListener(StartNewGame);
        buttonBackToMain.onClick.AddListener(ShowMainPanel);
    }

    void ShowLevelSelection()
    {
        panelMain.HideCanvasGroup();
        panelLevelSelection.ShowCanvasGroup();
    }

    void ShowMainPanel()
    {
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
    }

    void StartNewGame()
    {
        SceneManager.LoadScene(levelNames[0]);
    }
   
}
