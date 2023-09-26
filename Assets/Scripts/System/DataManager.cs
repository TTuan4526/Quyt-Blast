using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public static DataManager ins;

    public bool firstTimePlayer = true;

    public LevelScriptableObject levelData;

    
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

            if (PlayerPrefs.HasKey("FirstTimePlayer"))
            {
                firstTimePlayer = false; // Player has played before
            }
            else
            {
                PlayerPrefs.SetInt("FirstTimePlayer", 1); // Set the flag to indicate that the player has played before
                PlayerPrefs.Save();
            }
        }

        
    }
    public void SaveLevel(int currentLevel)
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);

        if (firstTimePlayer)
        {
            PlayerPrefs.SetInt("FirstTimePlayer", 0); // Set the flag to indicate that the player has played before
        }

        PlayerPrefs.Save();
    }

    public void LoadLastLevel()
    {
        int currentLevel = 0;

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        UI.ins.mainMenuScreen.GetComponent<MainMenuScreen>().currentLevel.text = "Level " + currentLevel.ToString();
        Game.ins.StartLevel(currentLevel);
    }

    public void SaveCoin(int coin)
    {
        PlayerPrefs.SetInt("CoinCollected", coin);
        PlayerPrefs.Save();
    }

    public void SaveCup(int cup)
    {
        PlayerPrefs.SetInt("CupCollected", cup);
        PlayerPrefs.Save();
    }

    public void SaveGameScore(int score)
    {
        PlayerPrefs.SetInt("GameScore", score);
        PlayerPrefs.Save();
    }


    public void SaveUpgradeUIProperties(int fireSpeedUI, int firePowerUI, int coinRateUI, int OEUI)
    {
        PlayerPrefs.SetInt("FireSpeedUI", fireSpeedUI);
        PlayerPrefs.SetInt("FirePowerUI", firePowerUI);
        PlayerPrefs.SetInt("CoinRateUI", coinRateUI);
        PlayerPrefs.SetInt("OfflineEarningUI", OEUI);
        PlayerPrefs.Save();
    }
    
    public void LoadUpgradeUIProperties()
    {
        if (PlayerPrefs.HasKey("FireSpeedUI"))
        {
            Game.ins.GameFireSpeedUI = PlayerPrefs.GetInt("FireSpeedUI");
        }

        if (PlayerPrefs.HasKey("FirePowerUI"))
        {
            Game.ins.GameFirePowerUI = PlayerPrefs.GetInt("FirePowerUI");
        }

        if (PlayerPrefs.HasKey("CoinRateUI"))
        {
            Game.ins.GameCoinsUpgradeUI = PlayerPrefs.GetInt("CoinRateUI");
        }

        if (PlayerPrefs.HasKey("OfflineEarningUI"))
        {
            Game.ins.GameOfflineEarningUI = PlayerPrefs.GetInt("OfflineEarningUI");
        }
    }

    public void SaveCoinUpgradeProperties(int fireSpeedCoin, int firePowerCoin, int coinRateCoin, int OECoin)
    {
        PlayerPrefs.SetInt("FireSpeedCoin", fireSpeedCoin);
        PlayerPrefs.SetInt("FirePowerCoin", firePowerCoin);
        PlayerPrefs.SetInt("CoinRateCoin", coinRateCoin);
        PlayerPrefs.SetInt("OfflineEarningCoin", OECoin);
        PlayerPrefs.Save();
    }

    public void LoadCoinUpgradeProperties()
    {
        if (PlayerPrefs.HasKey("FireSpeedCoin"))
        {
            Game.ins.CoinForFireSpeed = PlayerPrefs.GetInt("FireSpeedCoin");
        }

        if (PlayerPrefs.HasKey("FirePowerCoin"))
        {
            Game.ins.CoinForFirePower = PlayerPrefs.GetInt("FirePowerCoin");
        }

        if (PlayerPrefs.HasKey("CoinRateCoin"))
        {
            Game.ins.CoinForCoins = PlayerPrefs.GetInt("CoinRateCoin");
        }

        if (PlayerPrefs.HasKey("OfflineEarningCoin"))
        {
            Game.ins.CoinForOE = PlayerPrefs.GetInt("OfflineEarningCoin");
        }
    }

    public void SavePropertiesAfterUpgrade(float fireBulletDelay, int damageForMeteor, float coinDropChance,
        float coin1DropChance, float cupDropChance, float offlineEarningRate, int bulletNumber)
    {
        PlayerPrefs.SetFloat("FireBulletDelay", fireBulletDelay);
        PlayerPrefs.SetInt("DamageForMeteor", damageForMeteor);
        PlayerPrefs.SetFloat("CoinDropChance", coinDropChance);
        PlayerPrefs.SetFloat("Coin1DropChance", coin1DropChance);
        PlayerPrefs.SetFloat("CupDropChance", cupDropChance);
        PlayerPrefs.SetFloat("OfflineEarningRate", offlineEarningRate);
        PlayerPrefs.SetInt("BulletNumber", bulletNumber);
    }

    public void LoadPropertiesAfterUpgrade()
    {
        if (PlayerPrefs.HasKey("FireBulletDelay"))
        {
            Game.ins.FireBulletDelay = PlayerPrefs.GetFloat("FireBulletDelay");
        }
        if (PlayerPrefs.HasKey("DamageForMeteor"))
        {
            Game.ins.DamageForMeteor = PlayerPrefs.GetInt("DamageForMeteor");
        }
        if (PlayerPrefs.HasKey("CoinDropChance"))
        {
            Game.ins.CoinDropChance = PlayerPrefs.GetFloat("CoinDropChance");
        }
        if (PlayerPrefs.HasKey("Coin1DropChance"))
        {
            Game.ins.Coin1DropChance = PlayerPrefs.GetFloat("Coin1DropChance");
        }
        if (PlayerPrefs.HasKey("CupDropChance"))
        {
            Game.ins.CupDropChance = PlayerPrefs.GetFloat("CupDropChance");
        }
        if (PlayerPrefs.HasKey("OfflineEarningRate"))
        {
            Game.ins.OfflineLearningRate = PlayerPrefs.GetFloat("OfflineEarningRate");
        }
        if (PlayerPrefs.HasKey("BulletNumber"))
        {
            Game.ins.BulletNumber = PlayerPrefs.GetInt("BulletNumber");
        }
    }
}
