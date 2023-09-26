using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameScreen : BaseScreen
{
    public Button pauseBtn;
    public Slider levelExpBar;
    public TMP_Text presentLevel;
    public TMP_Text nextLevel;
    public TMP_Text score;
    public TMP_Text coinNumber;
    public TMP_Text cupNumber;
    public TMP_Text heartNumber;

    private void Start()
    {
        AudioManager.ins.PlayRandomBGM();
        pauseBtn.onClick.AddListener(OnClickPauseBtn);
        levelExpBar.minValue = 0;
        levelExpBar.maxValue = Game.ins.MaxExp;
        presentLevel.text = Game.ins.CurrentLevel.ToString();
        nextLevel.text = Game.ins.CurrentLevel + 1 + "";
        coinNumber.text = 0.ToString();
        cupNumber.text = 0.ToString();

        if (Game.ins.GameScore != 0)
        {
            score.text = Game.ins.GameScore.ToString();
        }   
        else
        {
            score.text = 0.ToString();
        }

    }

    private void Update()
    {
        if (Game.ins.IsWinLevel)
        {
            UpdateLevel();

            Game.ins.IsWinLevel = false;
        }
    }

    public void UpdateScore()
    {
        score.text = Game.ins.GameScore.ToString();
    }

    public void UpdateExpBar()
    {
        levelExpBar.value = Game.ins.ExpValue;
    }

    public void UpdateLevel()
    {
        presentLevel.text = Game.ins.CurrentLevel.ToString();
        nextLevel.text = Game.ins.CurrentLevel + 1 + "";
	    Game.ins.ExpValue = 0;
        levelExpBar.minValue = 0;
        levelExpBar.maxValue = Game.ins.MaxExp;
    }

    public void UpdateCoinNumber()
    {
        coinNumber.text = Game.ins.CoinInGame.ToString();
    }

    public void UpdateCupNumber()
    {
        cupNumber.text = Game.ins.CupInGame.ToString();
    }

    public void OnClickPauseBtn()
    {
        if(UI.ins.pauseScreenClone == null)
        {
            UI.ins.pauseScreenClone = UI.ins.Spawn(UI.ins.pauseScreen);
        }
        Time.timeScale = 0;
        pauseBtn.gameObject.SetActive(false);
        AudioManager.ins.PlaySFX(13);
        AudioManager.ins.StopAllBGM();
    }

    
}
