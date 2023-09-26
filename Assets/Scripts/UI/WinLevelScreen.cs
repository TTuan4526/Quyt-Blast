using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class WinLevelScreen : BaseScreen
{
    public TMP_Text scoreAfterWin;
    public TMP_Text presentLevel;
    public TMP_Text nextLevel;
    public TMP_Text clearLevelPopUp;
    public TMP_Text coinAfterWin;

    public GameObject[] lightsOff;
    public Sprite lightOn;
    public Sprite lightOff;

    public int maxIterations = 5;
    public float delayBetweenIterations = 1f;
    private int currentIteration = 0;

    public GameObject bonusPanel;

    public float moveDuration = 1f;
    public float stopDuration = 2f;
    public TextMeshProUGUI[] numberTexts;
    private int currentIndex = 0;

    public TextMeshProUGUI tapToContinue;
    private bool canTap = false;

    // Start is called before the first frame update
    void Start()
    {
        tapToContinue.gameObject.SetActive(false);

        Game.ins.meteorsLeft = GameObject.FindGameObjectsWithTag("Meteor");
        Game.ins.bulletLeft = GameObject.FindGameObjectsWithTag("Bullet");
        Game.ins.itemsLeft = GameObject.FindGameObjectsWithTag("Item");
        foreach (var obj in Game.ins.meteorsLeft)
        {
            Destroy(obj);
        }
        foreach (var obj in Game.ins.bulletLeft)
        {
            Destroy(obj);
        }
        foreach (var obj in Game.ins.itemsLeft)
        {
            Destroy(obj);
        }

        if (Game.ins.cannonClone != null)
        {
            Destroy(Game.ins.cannonClone);
            Game.ins.cannon = null;
        }

        if (Game.ins.meteorSpawnerClone != null)
        {
            Destroy(Game.ins.meteorSpawnerClone);
        }

        Time.timeScale = 1;

        scoreAfterWin.text = Game.ins.GameScore.ToString();
        int presentLevelInt = Game.ins.CurrentLevel;
        presentLevel.text = presentLevelInt.ToString();
        nextLevel.text = Game.ins.CurrentLevel + 1 + "";
        clearLevelPopUp.text = "Level " + (presentLevelInt - 1).ToString() + " Cleared";
        clearLevelPopUp.GetComponent<TextMeshProUGUI>().color = Color.red;

        coinAfterWin.text = Game.ins.GameCoin.ToString();

        InvokeRepeating("RandomLight", delayBetweenIterations, delayBetweenIterations);

        StartCoroutine(MoveBonusPanel());

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ScaleTextEffect());

        if (canTap)
        {
            if (Input.GetMouseButton(0))
            {
                if (PlayerPrefs.HasKey("GameScore"))
                {
                    int gameScore = PlayerPrefs.GetInt("GameScore");
                    if (Game.ins.GameScore > gameScore)
                    {
                        DataManager.ins.SaveGameScore(Game.ins.GameScore);
                    }
                }
                else
                {
                    DataManager.ins.SaveGameScore(Game.ins.GameScore);
                }

                Destroy(Game.ins.cam.GetComponent<CameraController>());
                Game.ins.cam.transform.position = new Vector3(Game.ins.cam.transform.position.x, -3.5f, -11f);

                UI.ins.WinLevelScreen.Hide(UI.ins.winLevelScreenClone);

                if (UI.ins.mainMenuScreenClone == null)
                {
                    UI.ins.mainMenuScreenClone = UI.ins.Spawn(UI.ins.mainMenuScreen);
                }

                if (UI.ins.bigMainMenuScreenClone == null)
                {
                    UI.ins.bigMainMenuScreenClone = UI.ins.Spawn(UI.ins.bigMainMenuScreen);
                }
            }
        }
    }

    IEnumerator ScaleTextEffect()
    {
        yield return clearLevelPopUp.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).WaitForCompletion();

        yield return clearLevelPopUp.transform.DOScale(new Vector3(1f, 1f, 1f), 1f).WaitForCompletion();
    }

    IEnumerator MoveBonusPanel()
    {
        yield return new WaitForSeconds(7f);
        float duration = 1f;
        float distance = 1000f;

        bonusPanel.gameObject.GetComponent<RectTransform>().right  += new Vector3(-distance, 0, 0);
        bonusPanel.gameObject.GetComponent<RectTransform>().
            DOAnchorPosX(bonusPanel.gameObject.GetComponent<RectTransform>().anchoredPosition.x - distance, duration);

        
        yield return new WaitForSeconds(1f);
        tapToContinue.gameObject.SetActive(true);
        canTap = true;
    }

    private void RandomLight()
    {
        if(currentIteration >= maxIterations)
        {
            CancelInvoke("RandomLight");

            foreach(GameObject light in lightsOff)
            {
                light.GetComponent<Image>().sprite = lightOn;
            }
        }
        else
        {
            foreach(GameObject light in lightsOff)
            {
                bool turnOn = Random.Range(0, 2) == 0;
                if (turnOn)
                {
                    light.GetComponent<Image>().sprite = lightOn;
                }
                else
                {
                    light.GetComponent<Image>().sprite = lightOff;
                }
            }

            currentIteration++;
        }
    }

    
}
