using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSides : MonoBehaviour
{
    [SerializeField] BoxCollider2D leftWall;
    [SerializeField] BoxCollider2D rightWall;
    // Start is called before the first frame update
    void Start()
    {
        float screenWidth = Game.ins.screenWidth;

        leftWall.transform.position = new Vector3(-screenWidth - (leftWall.size.x / 2f) + 1.01f, 0f, 0f);
        rightWall.transform.position = new Vector3(screenWidth + (rightWall.size.x / 2f) - 1.01f, 0f, 0f);

        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
