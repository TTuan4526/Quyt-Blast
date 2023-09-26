using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : BaseScreen
{
    public Button retryBtn;
    public TMP_Text extraText;
    public RectTransform targetRectTransform;


    private void Start()
    {
        AudioManager.ins.StopAllBGM();
        ScaleRetryBtn();
    }

    public void RetryBtnOnClick()
    {
        if(UI.ins.scoreScreenClone == null)
        {
            UI.ins.scoreScreenClone = UI.ins.Spawn(UI.ins.scoreScreen);
        }

        UI.ins.InGameScreen.Hide(UI.ins.inGameScreenClone);
        UI.ins.LoseScreen.Hide(UI.ins.loseScreenClone);
        AudioManager.ins.PlaySFX(14);
    }
  

    private void ScaleRetryBtn()
    {
        retryBtn.transform.localScale = Vector3.zero;

        retryBtn.transform.DOScale(Vector3.one, 1f).SetUpdate(true);

        retryBtn.onClick.AddListener(RetryBtnOnClick);
    }
}
