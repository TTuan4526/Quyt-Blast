using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPowerUp : Meteor
{
    [SerializeField] private Sprite sprite1, sprite2, sprite3;

    protected override void TakeDame(int dame)
    {
        if(health > 1)
        {
            health -= dame;

            if(health == 30)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
                gameObject.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 0.6f);
            }
            else if(health == 20)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
                gameObject.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            else if(health == 10)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
                gameObject.GetComponent<Transform>().localScale = Vector3.one;
            }
        }
        else
        {
            Death();
        }
    }

    protected override void Death()
    {
        ItemDrop();

        Destroy(gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            TakeDame(Game.ins.DamageForMeteor);
            Bullet.ins.DestroyBullet(other.gameObject);
        }
    }
}
