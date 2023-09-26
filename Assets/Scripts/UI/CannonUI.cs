using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CannonUI : MonoBehaviour
{
    [System.Serializable]
    class CannonItem
    {
        public Sprite Image;
        public int Price;
        public bool isPurchase = false;
    }

    [SerializeField] List<CannonItem> cannonItemsList;

    GameObject cannon;
    GameObject cannonItems;
    [SerializeField] Transform cannonScrollView;
    [SerializeField] Sprite unknownCannon;

    private void Start()
    {
        cannon = cannonScrollView.GetChild(0).gameObject;

        int len = cannonItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            cannonItems = Instantiate(cannon, cannonScrollView);
            cannonItems.transform.GetChild(0).GetComponent<Image>().sprite = unknownCannon;
            cannonItems.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cannonItemsList[i].Price.ToString();

            if (cannonItemsList[i].isPurchase)
            {
                cannonItems.transform.GetChild(0).GetComponent<Image>().sprite = cannonItemsList[i].Image;
                RectTransform rt = cannonItems.transform.GetChild(0).GetComponent(typeof(RectTransform)) as RectTransform;
                rt.sizeDelta = new Vector2(205, 203);
                cannonItems.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(-5f, -5f);
                Destroy(cannonItems.transform.GetChild(1).gameObject);
                Destroy(cannonItems.transform.GetChild(2).gameObject);
            }
        }

        Destroy(cannon);
    }
}
