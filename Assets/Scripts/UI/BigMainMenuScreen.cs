using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BigMainMenuScreen : BaseScreen
{
    #region Header Variables
    [Header("Header")]
    public GameObject headerPanel;
    public Sprite[] headerPanels;
    public TMP_Text coin;
    public TMP_Text cup;
    [HideInInspector] public Image headerPanelImg;
    #endregion

    #region Body Variables
    [Header("Body")]
    public GameObject battle_UI;
    public GameObject theme_UI;
    public GameObject cannon_UI;
    public GameObject shop_UI;
    public GameObject lock_UI;
    #endregion

    #region Footer Variables
    [Header("Footer")]
    public Button themeBtn;
    public Button cannonBtn;
    public Button battleBtn;
    public Button shopBtn;
    public Button lockBtn;
    public Sprite[] onClickSprite;
    public Sprite[] offClickSprite;
    [HideInInspector] public Image themeImg;
    [HideInInspector] public Image cannonImg;
    [HideInInspector] public Image battleImg;
    [HideInInspector] public Image shopImg;
    #endregion

    #region Battle_UI Variables
    [Header("Battle_UI")]
    public Button fireSpeedBtn;
    public Button firePowerBtn;
    public Button coinsBtn;
    public Button OEBtn;
    public Button fireSpeedUpgradeBtn;
    public Button firePowerUpgradeBtn;
    public Button coinsUpgradeBtn;
    public Button offlineEarningUpgradeBtn;
    public Image fireSpeedPanel;
    public Image firePowerPanel;
    public Image coinsPanel;
    public Image OEPanel;
    public Sprite OutOfMoneyBtn;
    public Sprite fireSpeedUpgrade;
    public Sprite firePowerUpgrade;
    public Sprite coinsUpgrade;
    public Sprite offlineEarningUpgrade;
    public TMP_Text fireSpeedShowText;
    public TMP_Text firePowerShowText;
    public TMP_Text coinsShowText;
    public TMP_Text offlineEarningShowText;
    public TMP_Text fireSpeedShowUpgradePriceText;
    public TMP_Text firePowerShowUpgradePriceText;
    public TMP_Text coinsShowUpgradePriceText;
    public TMP_Text offlineEarningShowUpgradePriceText;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartThisScreen();
        GetEventBtn();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void StartThisScreen()
    {
        //header
        headerPanel.gameObject.SetActive(false);
        headerPanelImg = headerPanel.GetComponent<Image>();
        if (PlayerPrefs.HasKey("CoinCollected"))
        {
            coin.text = PlayerPrefs.GetInt("CoinCollected").ToString();
        }

        if (PlayerPrefs.HasKey("CupCollected"))
        {
            cup.text = PlayerPrefs.GetInt("CupCollected").ToString();
        }

        //body
        battle_UI.SetActive(true);

        //footer
        themeImg = themeBtn.GetComponent<Image>();
        cannonImg = cannonBtn.GetComponent<Image>();
        battleImg = battleBtn.GetComponent<Image>();
        shopImg = shopBtn.GetComponent<Image>();
        //Battle_UI
        if (battle_UI.activeInHierarchy)
        {
            fireSpeedPanel.gameObject.SetActive(true);
            firePowerPanel.gameObject.SetActive(false);
            coinsPanel.gameObject.SetActive(false);
            OEPanel.gameObject.SetActive(false);
        }

        fireSpeedShowText.text = Game.ins.GameFireSpeedUI.ToString() + " bps";
        firePowerShowText.text = Game.ins.GameFirePowerUI.ToString() + " %";
        coinsShowText.text = Game.ins.GameCoinsUpgradeUI.ToString() + " %";
        offlineEarningShowText.text = Game.ins.GameOfflineEarningUI.ToString() + " %";

        fireSpeedShowUpgradePriceText.text = Game.ins.CoinForFireSpeed.ToString();
        firePowerShowUpgradePriceText.text = Game.ins.CoinForFirePower.ToString();
        coinsShowUpgradePriceText.text = Game.ins.CoinForCoins.ToString();
        offlineEarningShowUpgradePriceText.text = Game.ins.CoinForOE.ToString();

    }

    private void GetEventBtn()
    {
        //Footer
        themeBtn.onClick.AddListener(OnClickThemeBtn);
        cannonBtn.onClick.AddListener(OnClickCannonBtn);
        battleBtn.onClick.AddListener(OnClickBattleBtn);
        shopBtn.onClick.AddListener(OnClickShopBtn);
        lockBtn.onClick.AddListener(OnClickLockBtn);

        //Battle_UI
        fireSpeedBtn.onClick.AddListener(OnClickFireSpeedBtn);
        firePowerBtn.onClick.AddListener(OnClickFirePowerBtn);
        coinsBtn.onClick.AddListener(OnClickCoinsBtn);
        OEBtn.onClick.AddListener(OnClickOEBtn);
        fireSpeedUpgradeBtn.onClick.AddListener(OnClickFireSpeedUpgradeBtn);
        firePowerUpgradeBtn.onClick.AddListener(OnClickFirePowerUpgradeBtn);
        coinsUpgradeBtn.onClick.AddListener(OnClickCoinsUpgradeBtn);
        offlineEarningUpgradeBtn.onClick.AddListener(OnClickOfflineEarningUpgradeBtn);
    }

    #region Footer
    private void OnClickThemeBtn()
    {
        if (!headerPanel.activeInHierarchy)
        {
            headerPanel.SetActive(true);
            headerPanelImg.sprite = headerPanels[0];
        }
        else
        {
            headerPanelImg.sprite = headerPanels[0];
        }
        themeImg.sprite = onClickSprite[0];
        cannonImg.sprite = offClickSprite[1];
        battleImg.sprite = offClickSprite[2];
        shopImg.sprite = offClickSprite[3];

        theme_UI.SetActive(true);
        cannon_UI.SetActive(false);
        battle_UI.SetActive(false);
        shop_UI.SetActive(false);
        lock_UI.SetActive(false);
        AudioManager.ins.PlaySFX(13);
    }

    private void OnClickCannonBtn()
    {
        if (!headerPanel.activeInHierarchy)
        {
            headerPanel.SetActive(true);
            headerPanelImg.sprite = headerPanels[1];
        }
        else
        {
            headerPanelImg.sprite = headerPanels[1];
        }
        themeImg.sprite = offClickSprite[0];
        cannonImg.sprite = onClickSprite[1];
        battleImg.sprite = offClickSprite[2];
        shopImg.sprite = offClickSprite[3];

        theme_UI.SetActive(false);
        cannon_UI.SetActive(true);
        battle_UI.SetActive(false);
        shop_UI.SetActive(false);
        lock_UI.SetActive(false);
        AudioManager.ins.PlaySFX(13);
    }

    private void OnClickBattleBtn()
    {
        if (headerPanel.activeInHierarchy)
        {
            headerPanel.SetActive(false);
        }
        
        themeImg.sprite = offClickSprite[0];
        cannonImg.sprite = offClickSprite[1];
        battleImg.sprite = onClickSprite[2];
        shopImg.sprite = offClickSprite[3];

        theme_UI.SetActive(false);
        cannon_UI.SetActive(false);
        battle_UI.SetActive(true);
        shop_UI.SetActive(false);
        lock_UI.SetActive(false);
        AudioManager.ins.PlaySFX(13);
    }

    private void OnClickShopBtn()
    {
        if (!headerPanel.activeInHierarchy)
        {
            headerPanel.SetActive(true);
            headerPanelImg.sprite = headerPanels[2];
        }
        else
        {
            headerPanelImg.sprite = headerPanels[2];
        }

        themeImg.sprite = offClickSprite[0];
        cannonImg.sprite = offClickSprite[1];
        battleImg.sprite = offClickSprite[2];
        shopImg.sprite = onClickSprite[3];

        theme_UI.SetActive(false);
        cannon_UI.SetActive(false);
        battle_UI.SetActive(false);
        shop_UI.SetActive(true);
        lock_UI.SetActive(false);
        AudioManager.ins.PlaySFX(13);
    }

    private void OnClickLockBtn()
    {
        lock_UI.SetActive(true);
        StartCoroutine(UnShowLockUI());
        AudioManager.ins.PlaySFX(13);
    }

    IEnumerator UnShowLockUI()
    {
        yield return new WaitForSeconds(2f);
        if (lock_UI.activeInHierarchy)
        {
            lock_UI.SetActive(false);
        }
    }
    #endregion


    #region Battle_UI
    private void OnClickFireSpeedBtn()
    {
        fireSpeedPanel.gameObject.SetActive(true);
        firePowerPanel.gameObject.SetActive(false);
        coinsPanel.gameObject.SetActive(false);
        OEPanel.gameObject.SetActive(false);
        AudioManager.ins.PlaySFX(13);
    }

    private void OnClickFirePowerBtn()
    {
        fireSpeedPanel.gameObject.SetActive(false);
        firePowerPanel.gameObject.SetActive(true);
        coinsPanel.gameObject.SetActive(false);
        OEPanel.gameObject.SetActive(false);
        AudioManager.ins.PlaySFX(13);
    }

    private void OnClickCoinsBtn()
    {
        fireSpeedPanel.gameObject.SetActive(false);
        firePowerPanel.gameObject.SetActive(false);
        coinsPanel.gameObject.SetActive(true);
        OEPanel.gameObject.SetActive(false);
        AudioManager.ins.PlaySFX(13);
    }

    private void OnClickOEBtn()
    {
        AudioManager.ins.PlaySFX(13);
        fireSpeedPanel.gameObject.SetActive(false);
        firePowerPanel.gameObject.SetActive(false);
        coinsPanel.gameObject.SetActive(false);
        OEPanel.gameObject.SetActive(true);
        AudioManager.ins.PlaySFX(13);

    }

    private void OnClickFireSpeedUpgradeBtn()
    {
        AudioManager.ins.PlaySFX(13);
        if (Game.ins.GameCoin >= Game.ins.CoinForFireSpeed)
        {
            fireSpeedUpgradeBtn.GetComponent<Image>().sprite = fireSpeedUpgrade;
            fireSpeedUpgradeBtn.GetComponent<Button>().interactable = true;
            Game.ins.GameCoin = Game.ins.GameCoin - Game.ins.CoinForFireSpeed;

            if (Game.ins.FireBulletDelay == 0.1f)
            {
                if (Game.ins.BulletNumber < 7)
                {
                    Game.ins.BulletNumber++;
                }
            }
            else
            {
                if (Game.ins.FireBulletDelay > 0.1f)
                {
                    Game.ins.FireBulletDelay = Game.ins.FireBulletDelay - 0.05f;
                }
            }

            if (Game.ins.BulletNumber == 7)
            {
                Game.ins.BulletNumber = 7;
            }

            Game.ins.GameFireSpeedUI += 1;
            Game.ins.CoinForFireSpeed += 3;
            fireSpeedShowText.text = Game.ins.GameFireSpeedUI.ToString() + " bps";
            fireSpeedShowUpgradePriceText.text = Game.ins.CoinForFireSpeed.ToString();
            coin.text = Game.ins.GameCoin.ToString();
        }
        else
        {
            fireSpeedUpgradeBtn.GetComponent<Image>().sprite = OutOfMoneyBtn;
            fireSpeedUpgradeBtn.GetComponent<Button>().interactable = false;
        }
        AudioManager.ins.PlaySFX(47);
    }

    private void OnClickFirePowerUpgradeBtn()
    {
        AudioManager.ins.PlaySFX(13);
        if (Game.ins.GameCoin >= Game.ins.CoinForFirePower)
        {
            firePowerUpgradeBtn.GetComponent<Image>().sprite = firePowerUpgrade;
            firePowerUpgradeBtn.GetComponent<Button>().interactable = true;
            Game.ins.GameCoin = Game.ins.GameCoin - Game.ins.CoinForFirePower;
            Game.ins.DamageForMeteor += 1;
            Game.ins.GameFirePowerUI += 10;
            Game.ins.CoinForFirePower += 3;
            firePowerShowText.text = Game.ins.GameFirePowerUI.ToString() + " %";
            firePowerShowUpgradePriceText.text = Game.ins.CoinForFirePower.ToString();
            coin.text = Game.ins.GameCoin.ToString();
        }
        else
        {
            firePowerUpgradeBtn.GetComponent<Image>().sprite = OutOfMoneyBtn;
            firePowerUpgradeBtn.GetComponent<Button>().interactable = false;
        }
        AudioManager.ins.PlaySFX(47);
    }

    private void OnClickCoinsUpgradeBtn()
    {
       if(Game.ins.GameCoin >= Game.ins.CoinForCoins)
        {
            coinsUpgradeBtn.GetComponent<Image>().sprite = coinsUpgrade;
            coinsUpgradeBtn.GetComponent<Button>().interactable = true;
            Game.ins.GameCoin = Game.ins.GameCoin - Game.ins.CoinForCoins;
            Game.ins.CoinDropChance += 0.01f;
            Game.ins.Coin1DropChance += 0.01f;
            Game.ins.CupDropChance += 0.001f;
            Game.ins.GameCoinsUpgradeUI += 10;
            Game.ins.CoinForCoins += 3;
            coinsShowText.text = Game.ins.GameCoinsUpgradeUI.ToString() + " %";
            coinsShowUpgradePriceText.text = Game.ins.CoinForCoins.ToString();
            coin.text = Game.ins.GameCoin.ToString();
        }
        else
        {
            coinsUpgradeBtn.GetComponent<Image>().sprite = OutOfMoneyBtn;
            coinsUpgradeBtn.GetComponent<Button>().interactable = false;
        }
        AudioManager.ins.PlaySFX(47);
    }

    private void OnClickOfflineEarningUpgradeBtn()
    {
        if(Game.ins.GameCoin >= Game.ins.CoinForOE)
        {
            offlineEarningUpgradeBtn.GetComponent<Image>().sprite = offlineEarningUpgrade;
            offlineEarningUpgradeBtn.GetComponent<Button>().interactable = true;
            Game.ins.GameCoin = Game.ins.GameCoin - Game.ins.CoinForOE;
            Game.ins.OfflineLearningRate += 0.1f;
            Game.ins.GameOfflineEarningUI += 10;
            Game.ins.CoinForOE += 3;
            offlineEarningShowText.text = Game.ins.GameOfflineEarningUI.ToString() + " %";
            offlineEarningShowUpgradePriceText.text = Game.ins.CoinForOE.ToString();
            coin.text = Game.ins.GameCoin.ToString();
        }
        else
        {
            offlineEarningUpgradeBtn.GetComponent<Image>().sprite = OutOfMoneyBtn;
            offlineEarningUpgradeBtn.GetComponent<Button>().interactable = false;
        }
        AudioManager.ins.PlaySFX(47);
    }
    #endregion
}
