using UnityEngine;

public class Game : MonoBehaviour
{
    #region Singleton class: Game
    public static Game ins;
    

    public void Awake()
    {
        ins = this;
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0)).x;
        DataManager.ins.LoadLastLevel();
    }
    #endregion

	//ingame
    [SerializeField] private int gameScore;
    [SerializeField] private int maxExpEachLevelCount;
    [SerializeField] private int expValue;
    [SerializeField] private int meteorCount;
    [SerializeField] private int currentLevel;
    [SerializeField] private int minHealthMeteor;
    [SerializeField] private int maxHealthMeteor;
    [SerializeField] public GameObject cannon;
    [SerializeField] public GameObject meteorSpawner;
    [SerializeField] public GameObject cam;
    [SerializeField] public GameObject cannonPrefab;
    [SerializeField] public GameObject meteorSpawnerPrefab;
    [SerializeField] private int coinCollected;
    [SerializeField] private int cupCollected;
    //Upgrade
    [SerializeField] private int fireSpeedUI;
    [SerializeField] private int firePowerUI;
    [SerializeField] private int coinsUI;
    [SerializeField] private int OEUI;
    [SerializeField] private int coinForFireSpeed;
    [SerializeField] private int coinForFirePower;
    [SerializeField] private int coinForCoins;
    [SerializeField] private int coinForOE;
    [SerializeField] private float delay;
    [SerializeField] private int damageForMeteor;
    [SerializeField] private float coinDropChance;
    [SerializeField] private float coin1DropChance;
    [SerializeField] private float cupDropChance;
    [SerializeField] private float offlineEarningRate;
    [SerializeField] private int bulletNumber;

	//ingame(other)
    [HideInInspector] private int coinCollectedInGame;
    [HideInInspector] private int cupCollectedInGame;
    [HideInInspector] public GameObject[] meteorsLeft;
    [HideInInspector] public GameObject[] bulletLeft;
    [HideInInspector] public GameObject[] itemsLeft;
    [HideInInspector] public float screenWidth;
    [HideInInspector] public bool isLose = false;
    [HideInInspector] public GameObject cannonClone;
    [HideInInspector] public GameObject meteorSpawnerClone;
    [HideInInspector] private bool winLevel = false;

	public Sprite sprite1, sprite2, sprite3;
    
	//boss phase
	private bool isBossPhase;

    //offline time
    private const string LastShutDownTimeKey = "LastShutDownTime";
    [SerializeField] private int coinReceiveAfterOffline = 0;
    


    private void Start()
    {
        if (DataManager.ins.firstTimePlayer)
        {
            GameFireSpeedUI = 3;
            GameFirePowerUI = 100;
            GameCoinsUpgradeUI = 100;
            GameOfflineEarningUI = 100;

            CoinForFireSpeed = 1;
            CoinForFirePower = 1;
            CoinForCoins = 1;
            CoinForOE = 1;

            FireBulletDelay = 0.1f;
            DamageForMeteor = 1;
            CoinDropChance = 0.02f;
            Coin1DropChance = 0.01f;
            CupDropChance = 0.005f;
            OfflineLearningRate = 1;
            BulletNumber = 1;

            DataManager.ins.SaveUpgradeUIProperties(GameFireSpeedUI, GameFirePowerUI,
                GameCoinsUpgradeUI, GameOfflineEarningUI);
            DataManager.ins.SaveCoinUpgradeProperties(CoinForFireSpeed, ins.CoinForFirePower,
                CoinForCoins, ins.CoinForOE);
            DataManager.ins.SavePropertiesAfterUpgrade(FireBulletDelay, DamageForMeteor, CoinDropChance,
                Coin1DropChance, CupDropChance, OfflineLearningRate, BulletNumber);
        }
        else
        {
            DataManager.ins.LoadUpgradeUIProperties();
            DataManager.ins.LoadCoinUpgradeProperties();
            DataManager.ins.LoadPropertiesAfterUpgrade();
        }

        if (PlayerPrefs.HasKey("CoinCollected"))
        {
            coinCollected = PlayerPrefs.GetInt("CoinCollected");
        }

        if (PlayerPrefs.HasKey("CupCollected"))
        {
            cupCollected = PlayerPrefs.GetInt("CupCollected");
        }

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        if (PlayerPrefs.HasKey(LastShutDownTimeKey))
        {
            //Kiểm tra xem đã có thời gian tắt được lưu trước đó chưa
            string lastShutdownTime = PlayerPrefs.GetString(LastShutDownTimeKey);

            // Tính toán khoảng thời gian khi mở lại game
            System.DateTime previousShutdownTime = System.DateTime.Parse(lastShutdownTime);
            System.TimeSpan elapsedTime = System.DateTime.Now - previousShutdownTime;
            int minutesPlayed = (int)elapsedTime.TotalMinutes;

            CoinReceiveAfterOffline = minutesPlayed  * (int)OfflineLearningRate;

            if(UI.ins.offlineEarningScreenClone == null)
            {
                UI.ins.offlineEarningScreenClone = UI.ins.Spawn(UI.ins.offlineEarningScreen);
            }
        }

        IsWinLevel = false;
    }

    public void StartLevel(int level)
    {
        LevelScriptableObject.Level levelData = DataManager.ins.levelData.levels[level];

        currentLevel = levelData.level;
        meteorCount = levelData.numberOfMeteor;
        minHealthMeteor = levelData.minHealth;
        maxHealthMeteor = levelData.maxHealth;
        //IsBossPhase = false;

        //if(levelData.level != 10 && levelData.level != 20 && levelData.level != 30)
        //{

        //}
        //else
        //{
        //	IsBossPhase = true;
        //	Debug.Log(IsBossPhase);
        //}
    }

    private void Update()
    {
    }

    public void CheckWin()
    {
        if (expValue >= maxExpEachLevelCount)
        {
            if (currentLevel < DataManager.ins.levelData.levels.Length)
            {
                // Gọi hàm StartLevel với level tiếp theo
                StartLevel(currentLevel);
                UI.ins.inGameScreen.GetComponent<InGameScreen>().UpdateLevel();
                //if (meteorSpawnerClone != null)
                //{
                //    MeteorSpawner.ins.PrepareMeteor();
                //    StartCoroutine(MeteorSpawner.ins.SpawnMeteor());
                //}
                DataManager.ins.SaveLevel(currentLevel); 
                WinLevel();
            }
            else
            {
                // Đã hoàn thành tất cả các level
                // Thực hiện hành động khi kết thúc game
                Debug.Log("Finish Game");
            }
        }
    }

    public void UpdateExp()
    {
	    ExpValue++;
        UI.ins.inGameScreenClone.GetComponent<InGameScreen>().UpdateExpBar();
        CheckWin();
    }

    public void UpdateScore(int health)
    {
        gameScore += health;
        UI.ins.inGameScreenClone.GetComponent<InGameScreen>().UpdateScore();
    }

    public void UpdateCoin(int coin)
    {
        coinCollectedInGame += coin;
        UI.ins.inGameScreenClone.GetComponent<InGameScreen>().UpdateCoinNumber();
    }

    public void UpdateCup()
    {
        cupCollectedInGame++;
        UI.ins.inGameScreenClone.GetComponent<InGameScreen>().UpdateCupNumber();
    }

    public void LoseGame()
    {
        isLose = true;
       
        if (isLose)
        {
            Time.timeScale = 0;
            UI.ins.inGameScreenClone.GetComponent<InGameScreen>().pauseBtn.gameObject.SetActive(false);
            if(UI.ins.loseScreenClone == null)
            {
                UI.ins.loseScreenClone = UI.ins.Spawn(UI.ins.loseScreen);
            }
            coinCollected += coinCollectedInGame;
	        cupCollected += cupCollectedInGame;

            DataManager.ins.SaveCoin(GameCoin);
            DataManager.ins.SaveCup(GameCup);

            AudioManager.ins.PlaySFX(49);
        }
    }

    public void WinLevel()
    {
        IsWinLevel = true;

        if (IsWinLevel)
        {
            if (UI.ins.winLevelScreenClone == null)
            {
	            UI.ins.winLevelScreenClone = UI.ins.Spawn(UI.ins.winLevelscreen);
            }
	  
	        Time.timeScale = 0;
	        Game.ins.MaxExp = 0;
            //UI.ins.inGameScreenClone.GetComponent<InGameScreen>().pauseBtn.gameObject.SetActive(false);
            if(UI.ins.inGameScreenClone != null)
            {
                UI.ins.InGameScreen.Hide(UI.ins.inGameScreenClone);
            }
            
            coinCollected += coinCollectedInGame;
            cupCollected += cupCollectedInGame;

            DataManager.ins.SaveCoin(GameCoin);
            DataManager.ins.SaveCup(GameCup);

            AudioManager.ins.PlaySFX(49);
        }
    }
    
	public void BossPhase()
	{
		
	}

    private void OnApplicationQuit()
    {
        // Lưu thời điểm tắt game khi thoát
        string currentShutdownTime = System.DateTime.Now.ToString();
        PlayerPrefs.SetString(LastShutDownTimeKey, currentShutdownTime);

        DataManager.ins.SaveUpgradeUIProperties(GameFireSpeedUI, GameFirePowerUI,
               GameCoinsUpgradeUI, GameOfflineEarningUI);
        DataManager.ins.SaveCoinUpgradeProperties(CoinForFireSpeed, ins.CoinForFirePower,
            CoinForCoins, ins.CoinForOE);
        DataManager.ins.SavePropertiesAfterUpgrade(FireBulletDelay, DamageForMeteor, CoinDropChance,
            Coin1DropChance, CupDropChance, OfflineLearningRate, BulletNumber);
        DataManager.ins.SaveCoin(coinCollected);
        DataManager.ins.SaveCup(cupCollected);
    }

    #region get properties
    //trả về số lượng thiên thạch trong một level
    public bool IsWinLevel
    {
        get
        {
            return winLevel;
        }
        set
        {
            winLevel = value;
        }
    }

    public int MeteorCount
    {
        get
        {
            return meteorCount;
        }
        set
        {
            meteorCount = value;
        }
    }

    //trả về giá trị máu min của thiên thạch
    public int MinHealthMeteor
    {
        get
        {
            return minHealthMeteor;
        }
        set
        {
            minHealthMeteor = value;
        }
    }

    //trả về giá trị máu max của thiên thạch
    public int MaxHealthMeteor
    {
        get
        {
            return maxHealthMeteor;
        }
        set
        {
            maxHealthMeteor = value;
        }
    }

    //trả về giá trị lượng kinh nghiệm tối đa của màn chơi
    //(dùng để tham chiếu đến level exp bar của bên UI để check điều kiện qua level)
    public int MaxExp
    {
        get
        {
            return maxExpEachLevelCount;
        }
        set
        {
            maxExpEachLevelCount = value;
        }
    }

    //trả về level hiện tại
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    //trả về số điểm kiếm được trong màn chơi
    public int GameScore
    {
        get
        {
            return gameScore;
        }
        set
        {
            gameScore = value;
        }
    }

    //trả về số lượng kinh nghiệm kiếm được trong màn chơi
    public int ExpValue
    {
        get
        {
            return expValue;
        }
        set
        {
            expValue = value;
        }
    }
    

    //trả về số lượng coin kiếm được trong màn chơi
    public int CoinInGame
    {
        get
        {
            return coinCollectedInGame;
        }
        set
        {
            coinCollectedInGame = value;
        }
    }

    //trả về số lượng cup kiếm được trong màn chơi
    public int CupInGame
    {
        get
        {
            return cupCollectedInGame;
        }
        set
        {
            cupCollectedInGame = value;
        }
    }

    //trả về số lượng coin kiếm được trong game
    public int GameCoin
    {
        get
        {
            return coinCollected;
        }
        set
        {
            coinCollected = value;
        }
    }

    //trả về số lượng cup kiếm được trong game
    public int GameCup
    {
        get
        {
            return cupCollected;
        }
        set
        {
            cupCollected = value;
        }
    }

    //upgrade

    //trả về số coin hiện tại cần trả để nâng cấp
    public int CoinForFireSpeed
    {
        get
        {
            return coinForFireSpeed;
        }
        set
        {
            coinForFireSpeed = value;
        }
    }

    //trả về số coin hiện tại cần trả để nâng cấp
    public int CoinForFirePower
    {
        get
        {
            return coinForFirePower;
        }
        set
        {
            coinForFirePower = value;
        }
    }

    //trả về số coin hiện tại cần trả để nâng cấp
    public int CoinForCoins
    {
        get
        {
            return coinForCoins;
        }
        set
        {
            coinForCoins = value;
        }
    }

    //trả về số coin hiện tại cần trả để nâng cấp
    public int CoinForOE
    {
        get
        {
            return coinForOE;
        }
        set
        {
            coinForOE = value;
        }
    }

    public int GameFireSpeedUI
    {
        get
        {
            return fireSpeedUI;
        }
        set
        {
            fireSpeedUI = value;
        }
    }

    public int GameFirePowerUI
    {
        get
        {
            return firePowerUI;
        }
        set
        {
            firePowerUI = value;
        }
    }

    public int GameCoinsUpgradeUI
    {
        get
        {
            return coinsUI;
        }
        set
        {
            coinsUI = value;
        }
    }

    public int GameOfflineEarningUI
    {
        get
        {
            return OEUI;
        }
        set
        {
            OEUI = value;
        }
    }

    //offline time

    public int CoinReceiveAfterOffline
    {
        get
        {
            return coinReceiveAfterOffline;
        }
        set
        {
            coinReceiveAfterOffline = value;
        }
    }

    //other
    public float FireBulletDelay
    {
        get
        {
            return delay;
        }
        set
        {
            delay = value;
        }
    }

    public int DamageForMeteor
    {
        get
        {
            return damageForMeteor;
        }
        set
        {
            damageForMeteor = value;
        }
    }

    public float CoinDropChance
    {
        get
        {
            return coinDropChance;
        }
        set
        {
            coinDropChance = value;
        }
    }

    public float Coin1DropChance
    {
        get
        {
            return coin1DropChance;
        }
        set
        {
            coin1DropChance = value;
        }
    }

    public float CupDropChance
    {
        get
        {
            return cupDropChance;
        }
        set
        {
            cupDropChance = value;
        }
    }

    public float OfflineLearningRate
    {
        get
        {
            return offlineEarningRate;
        }
        set
        {
            offlineEarningRate = value;
        }
    }

    public int BulletNumber
    {
        get
        {
            return bulletNumber;
        }
        set
        {
            bulletNumber = value;
        }
    }
    
	public bool IsBossPhase
	{
		get{return isBossPhase;}
		set{isBossPhase = value;}
	}
    #endregion
}
