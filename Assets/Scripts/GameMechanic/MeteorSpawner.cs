using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] meteorPrefabs;
    [SerializeField] float spawnDelay;

    [HideInInspector] public GameObject[] meteors;

    public static MeteorSpawner ins;

    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PrepareMeteor();
        StartCoroutine(SpawnMeteor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnMeteor()
    {
        int activeMeteorCount = 0;

        for(int i = 0; i < Game.ins.MeteorCount; i++)
        {
            meteors[i].SetActive(true);
            activeMeteorCount++;

            if(activeMeteorCount == Game.ins.MeteorCount)
            {
                UI.ins.finalBallPopupClone = UI.ins.Spawn(UI.ins.finalBallPopup);
                yield return new WaitForSeconds(1f);
                if(UI.ins.finalBallPopupClone != null)
                {
                    Destroy(UI.ins.finalBallPopupClone);
                }
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void PrepareMeteor()
    {
        meteors = new GameObject[Game.ins.MeteorCount];
        int prefabsCount = meteorPrefabs.Length;
        for(int i = 0; i < Game.ins.MeteorCount; i++)
        {
            meteors[i] = Instantiate(meteorPrefabs[Random.Range(0, prefabsCount)], transform);
            if(meteors[i].GetComponent<Meteor>().type != 5)
            {
                meteors[i].GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
                meteors[i].GetComponent<Meteor>().health = Random.Range(Game.ins.MinHealthMeteor, Game.ins.MaxHealthMeteor);
            }
            else
            {
                meteors[i].GetComponent<Meteor>().health = 40;
            }
            meteors[i].GetComponent<Meteor>().isResultOfFission = false;
            meteors[i].SetActive(false);

            if (meteors[i].GetComponent<Meteor>().type == 1)
            {
                Game.ins.MaxExp += 8;
            }
            else if(meteors[i].GetComponent<Meteor>().type == 2)
            {
                Game.ins.MaxExp += 4;
            }
            else if(meteors[i].GetComponent<Meteor>().type == 3)
            {
                Game.ins.MaxExp += 2;
            }
            else if(meteors[i].GetComponent<Meteor>().type == 4)
            {
                Game.ins.MaxExp += 1;
            }
        }
    }
}
