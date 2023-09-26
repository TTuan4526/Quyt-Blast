using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScreen : BaseScreen, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject == transform.Find("BlackBG").gameObject)
        {
            if(UI.ins.pauseScreenClone != null)
            {
                UI.ins.PauseScreen.Hide(UI.ins.pauseScreenClone);
            }
            UI.ins.inGameScreenClone.GetComponent<InGameScreen>().pauseBtn.gameObject.SetActive(true);
            Time.timeScale = 1;
        }

        AudioManager.ins.PlayRandomBGM();
    }
}
