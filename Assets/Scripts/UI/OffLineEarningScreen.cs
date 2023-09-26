using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OffLineEarningScreen : BaseScreen
{
    public TMP_Text coinReceiveText;
    public Button collectBtn;
    public Button doubleX2Btn;

    private void Start()
    {
        coinReceiveText.text = Game.ins.CoinReceiveAfterOffline.ToString();
        collectBtn.onClick.AddListener(OnClickCollectBtn);
        doubleX2Btn.onClick.AddListener(OnClickDoubleX2Btn);
    }

    public void OnClickCollectBtn()
    {
        Game.ins.GameCoin += Game.ins.CoinReceiveAfterOffline;
        UI.ins.bigMainMenuScreenClone.GetComponent<BigMainMenuScreen>().coin.text = Game.ins.GameCoin.ToString(); 
        UI.ins.OffLineEarningScreen.Hide(UI.ins.offlineEarningScreenClone);
        AudioManager.ins.PlaySFX(13);
    }

    public void OnClickDoubleX2Btn()
    {
        Debug.Log("Run some shit ads, i don't know btw?");
        AudioManager.ins.PlaySFX(13);
    }

}
