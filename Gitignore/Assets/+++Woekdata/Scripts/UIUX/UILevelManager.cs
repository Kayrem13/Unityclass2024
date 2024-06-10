using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UILevelManager : MonoBehaviour
{

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
        Time.timeScale = 1f;
        txtCoinCount.text = coinCount.ToString();
        //panelWin.alpha = 0f;
        //panelWin.interactable = false;
        //panelWin.blocksRaycasts = false;
        
        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        //hide win and lose
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonPlayAgain.onClick.AddListener(RestartLevel);
        buttonBackToMain.onClick.AddListener(BackToMenu);
        buttonBackToMainOnLose.onClick.AddListener(BackToMenu);
    }

    public void OnGameWin()
    {
        panelWin.ShowCanvasGroup();
        PlayerPrefs.SetInt(nameNextScene, 1);
        Time.timeScale = 0f;
        //winscreen show
    }

    public void OnGameLose()
    {
        panelLose.ShowCanvasGroup();
        Time.timeScale = 0f;
        //losescreen show
    }

    public void AddCoin()
    {
        coinCount++;
        txtCoinCount.text = coinCount.ToString();
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //reload current Level
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nameNextScene);
        //
    }
    
    void BackToMenu()
    {
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
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}