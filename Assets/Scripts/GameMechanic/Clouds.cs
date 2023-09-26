using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [System.Serializable] class Cloud
    {
        public MeshRenderer meshRenderer = null;
        public float speed = 0f;
        [HideInInspector] public Vector2 offSet;
        [HideInInspector] public Material mat;
    }

    [SerializeField] Cloud[] allClouds;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = allClouds.Length;
        for(int i = 0; i < count; i++)
        {
            allClouds[i].offSet = Vector2.zero;
            allClouds[i].mat = allClouds[i].meshRenderer.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < count; i++)
        {
            allClouds[i].offSet.x += allClouds[i].speed * Time.deltaTime;
            allClouds[i].mat.mainTextureOffset = allClouds[i].offSet;
        }
    }
}
