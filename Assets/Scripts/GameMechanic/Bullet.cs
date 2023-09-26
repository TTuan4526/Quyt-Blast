using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    Queue<GameObject> bulletQueue;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int bulletCount;

    [Space]
    [SerializeField] float speed;

    GameObject bulletClone;
    GameObject bulletClone1;
    GameObject bulletClone2;
    GameObject bulletClone3;
    GameObject bulletClone4;
    GameObject bulletClone5;
    GameObject bulletClone6;
    float timeCount = 0f;

    public static Bullet ins;

    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    void Start()
    {
	    PrepareBullet();
    }

    // Update is called once per frame
    void Update()
    {
        ShootNumBerOfBullet();
    }

    public void ShootNumBerOfBullet()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= Game.ins.FireBulletDelay && transform.parent.GetComponent<Cannon>().isMoving && !IsMouseOverUI())
        {
            AudioManager.ins.PlaySFX(22);
            timeCount = 0f;
            if (Game.ins.BulletNumber == 1)
            {
                if (Random.value <= 0.3f)
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
                else
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                }
            }
            else if (Game.ins.BulletNumber == 2)
            {
                if (Random.value <= 0.3f)
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
                else
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
            }
            else if (Game.ins.BulletNumber == 3)
            {
                if (Random.value <= 0.3f)
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone3 = SpawnBullet(transform.position + new Vector3(0.5f, 0f, 0f));
                        bulletClone3.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
                else
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
            }
            else if (Game.ins.BulletNumber == 4)
            {
                if (Random.value <= 0.3f)
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone3 = SpawnBullet(transform.position + new Vector3(0.5f, 0f, 0f));
                        bulletClone3.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone4 = SpawnBullet(transform.position + new Vector3(-0.5f, 0f, 0f));
                        bulletClone4.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
                else
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone3 = SpawnBullet(transform.position + new Vector3(0.5f, 0f, 0f));
                        bulletClone3.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
            }
            else if (Game.ins.BulletNumber == 5)
            {
                if (Random.value <= 0.3f)
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone3 = SpawnBullet(transform.position + new Vector3(0.5f, 0f, 0f));
                        bulletClone3.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone4 = SpawnBullet(transform.position + new Vector3(-0.5f, 0f, 0f));
                        bulletClone4.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone5 = SpawnBullet(transform.position + new Vector3(-0.75f, 0f, 0f));
                        bulletClone5.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
                else
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone3 = SpawnBullet(transform.position + new Vector3(0.5f, 0f, 0f));
                        bulletClone3.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone4 = SpawnBullet(transform.position + new Vector3(-0.5f, 0f, 0f));
                        bulletClone4.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
            }
            else if (Game.ins.BulletNumber == 6)
            {
                if (Random.value <= 0.3f)
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone3 = SpawnBullet(transform.position + new Vector3(0.5f, 0f, 0f));
                        bulletClone3.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone4 = SpawnBullet(transform.position + new Vector3(-0.5f, 0f, 0f));
                        bulletClone4.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone5 = SpawnBullet(transform.position + new Vector3(-0.75f, 0f, 0f));
                        bulletClone5.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone6 = SpawnBullet(transform.position + new Vector3(0.75f, 0f, 0f));
                        bulletClone6.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
                else
                {
                    bulletClone = SpawnBullet(transform.position);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    if (bulletClone != null)
                    {
                        bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                        bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                        bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone3 = SpawnBullet(transform.position + new Vector3(0.5f, 0f, 0f));
                        bulletClone3.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone4 = SpawnBullet(transform.position + new Vector3(-0.5f, 0f, 0f));
                        bulletClone4.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                        bulletClone5 = SpawnBullet(transform.position + new Vector3(-0.75f, 0f, 0f));
                        bulletClone5.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    }
                }
            }
            else if (Game.ins.BulletNumber == 7)
            {
                bulletClone = SpawnBullet(transform.position);
                bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                if (bulletClone != null)
                {
                    bulletClone1 = SpawnBullet(transform.position + new Vector3(0.25f, 0f, 0f));
                    bulletClone1.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    bulletClone2 = SpawnBullet(transform.position + new Vector3(-0.25f, 0f, 0f));
                    bulletClone2.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    bulletClone3 = SpawnBullet(transform.position + new Vector3(0.5f, 0f, 0f));
                    bulletClone3.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    bulletClone4 = SpawnBullet(transform.position + new Vector3(-0.5f, 0f, 0f));
                    bulletClone4.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    bulletClone5 = SpawnBullet(transform.position + new Vector3(-0.75f, 0f, 0f));
                    bulletClone5.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                    bulletClone6 = SpawnBullet(transform.position + new Vector3(0.75f, 0f, 0f));
                    bulletClone6.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                }
            }

        }
    }

    public void PrepareBullet()
    {
        bulletQueue = new Queue<GameObject>();
        for(int i = 0; i < bulletCount; i++)
        {
            bulletClone = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
            bulletClone.gameObject.SetActive(false);
            bulletQueue.Enqueue(bulletClone);
        }
    }

    public GameObject SpawnBullet(Vector2 pos)
    {
        if(bulletQueue.Count > 0)
        {
            bulletClone = bulletQueue.Dequeue();
            bulletClone.transform.position = pos;
            bulletClone.gameObject.SetActive(true);

            return bulletClone;
        }

        return null;
    }

    public void DestroyBullet(GameObject bullet)
    {
        bulletQueue.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            DestroyBullet(other.gameObject);
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
