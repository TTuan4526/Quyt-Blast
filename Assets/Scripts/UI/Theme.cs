using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Theme : MonoBehaviour
{
    [System.Serializable] class ThemeItem
    {
        public Sprite Image;
        public bool isUnlock = false;
    }

    [SerializeField] List<ThemeItem> themeItemsList;

    GameObject theme;
    GameObject themeItems;
    [SerializeField]Transform themeScrollView;
    [SerializeField] Sprite lockImg;

    private void Start()
    {
        theme = themeScrollView.GetChild(0).gameObject;

        int len = themeItemsList.Count;
        for(int i = 0; i < len; i++)
        {
            themeItems = Instantiate(theme, themeScrollView);
            themeItems.GetComponent<Image>().sprite = themeItemsList[i].Image;
            if(!themeItemsList[i].isUnlock)
            {
                themeItems.GetComponent<Image>().sprite = lockImg;
            }
        }

        Destroy(theme);
    }
}
