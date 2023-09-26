using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class MainMenuScreen : BaseScreen
{
    public TMP_Text currentLevel;
    public TMP_Text bestGameScore;
    public GameObject cannonAnim;

    [SerializeField] private float timeExist;
    private float currentLevelExistTimeCount;
    private float bestScoreExistTimeCount;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel.text = "Level" + " " +  (PlayerPrefs.GetInt("CurrentLevel")).ToString();
        }
        else
        {
            currentLevel.text = "Level" + " " + 1;
        }

        if (PlayerPrefs.HasKey("GameScore"))
        {
            bestGameScore.text = "Best Score:" + " " + (PlayerPrefs.GetInt("GameScore")).ToString();
        }
        else
        {
            bestGameScore.text = "Best Score:" + " " + 0;
        }

        currentLevel.gameObject.SetActive(false);
        bestGameScore.gameObject.SetActive(false);
        currentLevelExistTimeCount = timeExist;
    }

    private void Update()
    {
        if (currentLevelExistTimeCount > 0)
        {
            currentLevelExistTimeCount -= Time.deltaTime;
            currentLevel.gameObject.SetActive(true);
            bestGameScore.gameObject.SetActive(false);

            if(currentLevelExistTimeCount <= 0)
            {
                currentLevelExistTimeCount = 0;
                bestScoreExistTimeCount = timeExist;
            }
        }

        if(bestScoreExistTimeCount > 0)
        {
            bestScoreExistTimeCount -= Time.deltaTime;
            currentLevel.gameObject.SetActive(false);
            bestGameScore.gameObject.SetActive(true);

            if(bestScoreExistTimeCount <= 0)
            {
                bestScoreExistTimeCount = 0;
                currentLevelExistTimeCount = timeExist;
            }
        }

        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
	        if(!Game.ins.IsBossPhase)
	        {
	        	if (UI.ins.bigMainMenuScreenClone != null)
	        	{
		        	UI.ins.BigMainMenuScreen.Hide(UI.ins.bigMainMenuScreenClone);
	        	}

		        if (Game.ins.cannonClone == null)
		        {
			        Game.ins.cannonClone = Instantiate(Game.ins.cannonPrefab, cannonAnim.transform.position, Quaternion.identity);
			        Game.ins.cannon = Game.ins.cannonClone;
		        }

		        if (Game.ins.meteorSpawnerClone == null)
		        {
			        Game.ins.meteorSpawnerClone = Instantiate(Game.ins.meteorSpawnerPrefab, Vector3.zero, Quaternion.identity);
		        }

		        if (UI.ins.mainMenuScreenClone != null)
		        {
			        UI.ins.MainMenuScreen.Hide(UI.ins.mainMenuScreenClone);
		        }

		        UI.ins.cam.AddComponent<CameraController>();
		        if (UI.ins.inGameScreenClone == null)
		        {
			        UI.ins.inGameScreenClone = UI.ins.Spawn(UI.ins.inGameScreen);
		        }

		        Game.ins.CoinInGame = 0;
		        Game.ins.CupInGame = 0;
	        }
	        else
	        {
	        	if (UI.ins.bigMainMenuScreenClone != null)
	        	{
		        	UI.ins.BigMainMenuScreen.Hide(UI.ins.bigMainMenuScreenClone);
	        	}
	        	
		        if (UI.ins.mainMenuScreenClone != null)
		        {
			        UI.ins.MainMenuScreen.Hide(UI.ins.mainMenuScreenClone);
		        }
		        
		        if (Game.ins.cannonClone == null)
		        {
			        Game.ins.cannonClone = Instantiate(Game.ins.cannonPrefab, cannonAnim.transform.position, Quaternion.identity);
			        Game.ins.cannon = Game.ins.cannonClone;
		        }
		        
		        UI.ins.cam.AddComponent<CameraController>();
		        if (UI.ins.inGameScreenClone == null)
		        {
			        UI.ins.inGameScreenClone = UI.ins.Spawn(UI.ins.inGameScreen);
		        }
		        
		        Debug.Log("isBossPhase");
	        }
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}


