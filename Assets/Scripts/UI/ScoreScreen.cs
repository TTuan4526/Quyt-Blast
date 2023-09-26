using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : BaseScreen
{
    public Slider levelExpBar;
    public TMP_Text presentLevel;
    public TMP_Text nextLevel;
    public TMP_Text score;
    public TMP_Text bestScore;
    public TMP_Text expCompleted;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(123);
        score.text = Game.ins.GameScore.ToString();
        bestScore.text = "Best Score: " + Game.ins.GameScore.ToString();
        levelExpBar.maxValue = Game.ins.MaxExp;
        levelExpBar.value = Game.ins.ExpValue;
        presentLevel.text = Game.ins.CurrentLevel.ToString();
        nextLevel.text = Game.ins.CurrentLevel + 1 + "";

        expCompleted.text = (Mathf.Round((Game.ins.ExpValue / (float)Game.ins.MaxExp) * 100)).ToString() + "% completed";

        int gameScore = PlayerPrefs.GetInt("GameScore");
        if (Game.ins.GameScore > gameScore)
        {
            AudioManager.ins.PlaySFX(29);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (PlayerPrefs.HasKey("GameScore"))
            {
                int gameScore = PlayerPrefs.GetInt("GameScore");
                if(Game.ins.GameScore > gameScore)
                {
                    DataManager.ins.SaveGameScore(Game.ins.GameScore);
                }
            }
            else
            {
                DataManager.ins.SaveGameScore(Game.ins.GameScore);
            }

            Game.ins.GameScore = 0;
            Game.ins.MaxExp = 0;

            Destroy(Game.ins.cam.GetComponent<CameraController>());
            Game.ins.cam.transform.position = new Vector3(Game.ins.cam.transform.position.x, -3.5f, -11f);
           
            UI.ins.ScoreScreen.Hide(UI.ins.scoreScreenClone);

	        

            Game.ins.meteorsLeft = GameObject.FindGameObjectsWithTag("Meteor");
            Game.ins.bulletLeft = GameObject.FindGameObjectsWithTag("Bullet");
            Game.ins.itemsLeft = GameObject.FindGameObjectsWithTag("Item");
            foreach(var obj in Game.ins.meteorsLeft)
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

            if(Game.ins.meteorSpawnerClone != null)
            {
                Destroy(Game.ins.meteorSpawnerClone);
            }

            if (UI.ins.mainMenuScreenClone == null)
            {
                UI.ins.mainMenuScreenClone = UI.ins.Spawn(UI.ins.mainMenuScreen);
            }

            if(UI.ins.bigMainMenuScreenClone == null)
            {
                UI.ins.bigMainMenuScreenClone = UI.ins.Spawn(UI.ins.bigMainMenuScreen);
            }

            Time.timeScale = 1;

            AudioManager.ins.PlaySFX(13);

           
        }
    }
}
