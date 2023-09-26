using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI ins;

    private void Awake()
    {
        if (ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Header("References")]
    public InGameScreen InGameScreen;
    public PauseScreen PauseScreen;
    public MainMenuScreen MainMenuScreen;
    public LoseScreen LoseScreen;
    public ScoreScreen ScoreScreen;
    public BigMainMenuScreen BigMainMenuScreen;
    public OffLineEarningScreen OffLineEarningScreen;
    public WinLevelScreen WinLevelScreen;

    [Header("Spawn")]
    public GameObject inGameScreen;
    public GameObject pauseScreen;
    public GameObject mainMenuScreen;
    public GameObject loseScreen;
    public GameObject scoreScreen;
    public GameObject bigMainMenuScreen;
    public GameObject offlineEarningScreen;
    public GameObject finalBallPopup;
    public GameObject winLevelscreen;
        
    [Header("Other")]
    public GameObject UIParent;
    public GameObject cam;
    [HideInInspector]
    public GameObject inGameScreenClone, pauseScreenClone, mainMenuScreenClone, loseScreenClone, scoreScreenClone,
        bigMainMenuScreenClone, offlineEarningScreenClone, finalBallPopupClone, winLevelScreenClone;

    private void Start()
    {
        mainMenuScreenClone = null;
        inGameScreenClone = null;
        pauseScreenClone = null;
        loseScreenClone = null;
        scoreScreenClone = null;
        bigMainMenuScreenClone = null;
        offlineEarningScreenClone = null;
        finalBallPopupClone = null;
        winLevelScreenClone = null;

        if (DataManager.ins.firstTimePlayer)
        {
            if (mainMenuScreenClone == null)
            {
                mainMenuScreenClone = Spawn(mainMenuScreen);
            }
        }
        else
        {
            if (mainMenuScreenClone == null)
            {
                mainMenuScreenClone = Spawn(mainMenuScreen);
            }

            if (bigMainMenuScreenClone == null)
            {
                bigMainMenuScreenClone = Spawn(bigMainMenuScreen);
            }

        }
    }

    private void Update()
    {
        
    }

    public GameObject Spawn(GameObject ui)
    {
        return Instantiate(ui, UIParent.transform);
    }
}
