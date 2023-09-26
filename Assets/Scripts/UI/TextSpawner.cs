    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    public int amountToSpawn = 4;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            GameObject textOBJ = new GameObject($"x{i}");
            textOBJ.transform.parent = transform;
            textOBJ.AddComponent<TextMeshProUGUI>();
            textOBJ.GetComponent<TextMeshProUGUI>().text = $"x{i}";
            textOBJ.GetComponent<RectTransform>().localScale = Vector3.one;
            textOBJ.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            textOBJ.GetComponent<TextMeshProUGUI>().fontSize = 64;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
