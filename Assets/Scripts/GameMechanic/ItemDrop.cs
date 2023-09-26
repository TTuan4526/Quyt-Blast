using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public bool isCoin;
    public bool isCoin1;
    public bool isCup;

    private Rigidbody2D itemRb;
    public float dropForce = 7;

    // Start is called before the first frame update
    void Start()
    {
        itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Cannon"))
        {
            AudioManager.ins.PlaySFX(17);

            if (isCoin)
            {
                Game.ins.UpdateCoin(1);
                Destroy(gameObject);
            }

            if (isCoin1)
            {
                Game.ins.UpdateCoin(3);
                Destroy(gameObject);
            }

            if (isCup)
            {
                Game.ins.UpdateCup();
                Destroy(gameObject);
            }
        }
    }
}
