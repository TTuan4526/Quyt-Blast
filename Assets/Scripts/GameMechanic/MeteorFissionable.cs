using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFissionable : Meteor
{
    [SerializeField] GameObject[] splitsPrefabs;

    protected override void Death()
    {
        base.Death();
        SplitMeteor();
    }

	private bool hasSpawnedMeteors = false; // Biến cờ xác định xem đã sinh ra meteor hay chưa

	private void SplitMeteor()
	{
		if (!hasSpawnedMeteors)
		{
			for (int i = 0; i < 2; i++)
			{
				GameObject meteorClone;
				meteorClone = Instantiate(splitsPrefabs[i], transform.position, Quaternion.identity, MeteorSpawner.ins.transform);
				meteorClone.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
				meteorClone.GetComponent<Meteor>().health = Random.Range(Game.ins.MinHealthMeteor, Game.ins.MaxHealthMeteor);
				meteorClone.GetComponent<Rigidbody2D>().velocity = new Vector2(leftAndRight[i] * 3f, 3f);
			}

			hasSpawnedMeteors = true; // Đã sinh ra meteor
		}
	}
}
