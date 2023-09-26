using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] public int health;

    [SerializeField] protected TMP_Text textHealth;
    [SerializeField] protected float jumpForce;
    [SerializeField] public int type;
    [SerializeField] public GameObject[] itemDrops;
   

    protected float rotationSpeed = 15f;
    public bool isShowing;
    protected float[] leftAndRight = new float[2] { -1f, 1f };

    [HideInInspector] public bool isResultOfFission = true;
    public static Meteor ins;
	
    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        UpdateHealthUI();
        jumpForce = Random.Range(10, 15);
        int maxValue = 15;
        int minValue = -15;
        rotationSpeed = Random.value < 0.5f ? minValue : maxValue;
        rb.gravityScale = 0f;

	    if (isResultOfFission)
	    {
		    FallDown();
	    }
	    else
	    {
		    float direction = leftAndRight[Random.Range(0, 2)];
		    float screenOffset = Game.ins.screenWidth * 1.3f;
		    float randomY = Random.Range(0f, 8f);
		    transform.position = new Vector2(screenOffset * direction, randomY);
		    AudioManager.ins.PlaySFX(0);
	
		    rb.velocity = new Vector2(-direction, 0f);
		    //push meteor down after few seconds
		    float waitTime = 1f;
		    Invoke("FallDown", waitTime);
	
		    if (type == 5)
		    {
			    float direction5 = Random.value < 0.5f ? -1f : 1f;
			    float speedMultiplier = 0.3f; // Điều chỉnh giá trị này để giảm tốc độ di chuyển
			    rb.velocity = new Vector2(direction5 * speedMultiplier, 0f);
			    float waitTime5 = 0.1f;
			    Invoke("FallDown", waitTime5);
		    }
	    }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void FallDown()
    {
        isShowing = false;
        rb.gravityScale = 1f;
        rb.AddTorque(Random.Range(-20f, 20f));
    }

    protected void UpdateHealthUI()
    {
        textHealth.text = health.ToString();
    }

    protected virtual void TakeDame(int dame)
    {
        if(health > 1)
        {
            health -= dame;

            if(type == 5)
            {
                if(health == 30)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Game.ins.sprite1;
                    gameObject.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                }

                if (health == 20)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Game.ins.sprite2;
                    gameObject.GetComponent<Transform>().localScale = Vector3.one;
                }

                if (health == 10)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Game.ins.sprite3;
                    gameObject.GetComponent<Transform>().localScale = new Vector3(1.2f, 1.2f, 1.2f);
                }
            }
        }
        else
        {
            Death();
        }

        UpdateHealthUI();
    }

    protected virtual void Death()
    {
        Game.ins.UpdateScore(health);

        if (type == 4)
        {
            Game.ins.UpdateExp();
        }

        ItemDrop();

        Destroy(gameObject);
    }

    protected virtual void ItemDrop()
    {
        if(Random.Range(0f,1f) <= Game.ins.CoinDropChance && Random.Range(0f, 1f) > Game.ins.Coin1DropChance)
        {
            Instantiate(itemDrops[0], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        else if(Random.Range(0f, 1f) <= Game.ins.Coin1DropChance && Random.Range(0f, 1f) > Game.ins.CupDropChance)
        {
            Instantiate(itemDrops[1], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        else if(Random.Range(0f, 1f) <= Game.ins.CupDropChance)
        {
            Instantiate(itemDrops[2], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        else
        {
            return;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Cannon")
        {
            //game over
            AudioManager.ins.PlaySFX(15);
            Game.ins.LoseGame();
        }
        
        if(other.tag == "Bullet")
        {
            //take dame
            TakeDame(Game.ins.DamageForMeteor);
            Bullet.ins.DestroyBullet(other.gameObject);
            if(type != 5)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
            }
        }
        
        if(!isShowing && other.tag.Equals("Wall"))
        {
            float posX = transform.position.x;
            if(posX > 0)
            {
                //hit right wall
                rb.AddForce(Vector2.left * 200f);
            }
            else
            {
                //hit left wall
                rb.AddForce(Vector2.right * 200f);
                
            }

            rb.AddTorque(posX * 4f);

            if(isShowing && other.tag.Equals("Wall"))
            {
                if (posX > 0)
                {
                    //hit right wall
                    rb.AddForce(Vector2.left * 200f);
                }
                else
                {
                    //hit left wall
                    rb.AddForce(Vector2.right * 200f);

                }

                rb.AddTorque(posX * 4f);
            }
        }
        
        if(other.tag == "Ground")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.ins.PlaySFX(Random.Range(1, 4));
        }
    }
}

