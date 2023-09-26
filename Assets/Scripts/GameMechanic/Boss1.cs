using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Boss
{
	public BossState bossState;
		
	[Header("Idle")]
	[SerializeField] private Transform[] wayPointsIdle;
	[SerializeField] private float moveSpeed;
	private int wayPointIndex = 0;
	
	[Header("Move")]
	[SerializeField] Transform[] startMovePoints;
	[SerializeField] Transform[] wayPointsMove;
	
	[Header("Attack")]
	public GameObject bossMouth;
	public GameObject bossMouthOpen;
	public float attackTime;
	public Transform attackPoint;
	private float attackTimeCount;
	
	public GameObject bossMeteor;
	[Header("Hit")]
	public GameObject bossBody;
	
	
    // Start is called before the first frame update
    void Start()
    {
	    attackTimeCount = attackTime;
	    bossState = BossState.idle;
	    
	    transform.position = wayPointsIdle[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
	    UpdateState();
    }
    
	void UpdateState()
	{
		switch(bossState)
		{
			case BossState.idle:
				IdleState();
					break;
			case BossState.move:
				MoveState();
				break;
			case BossState.patrol:
				PatrolState();
				break;
			
			case BossState.death:
				//DeathState();
					break;
		}
	}
	
	void IdleState()
	{
		Idle();
	}
	
	void MoveState()
	{
		Move();
	}
	
	void PatrolState()
	{
		Patrol();
		
		if(attackTimeCount <= 0)
		{
			StartCoroutine(Attack());
		}
		else{
			attackTimeCount -= Time.deltaTime;
		}
	}
	
	
	
	//void DeathState()
	//{
	//	//Destroy(gameObject);
	//}
	
	
	private IEnumerator waitToChangeStateToMove()
	{
		yield return new WaitForSeconds(5f);
		bossState = BossState.move;
	}
	
	private void Idle()
	{
		if(wayPointIndex <= wayPointsIdle.Length - 1)
		{
			transform.position = Vector2.MoveTowards(transform.position,
				wayPointsIdle[wayPointIndex].transform.position, moveSpeed * Time.deltaTime);
				
			if(transform.position == wayPointsIdle[wayPointIndex].transform.position)
			{
				wayPointIndex += 1;
			}
		}
		else{
			bossState = BossState.move;
			wayPointIndex = 0;
		}
	}
	
	private void Move()
	{
		if(wayPointIndex <= startMovePoints.Length - 1)
		{
			transform.position = Vector2.MoveTowards(transform.position,
				startMovePoints[wayPointIndex].transform.position, moveSpeed * Time.deltaTime);
				
			if(transform.position == startMovePoints[wayPointIndex].transform.position)
			{
				wayPointIndex += 1;
			}
		}
		else{
			bossState =BossState.patrol;
			wayPointIndex = 0;
		}
	}
	
	private void Patrol()
	{
		if(wayPointIndex <= wayPointsMove.Length - 1)
		{
			transform.position = Vector2.MoveTowards(transform.position,
				wayPointsMove[wayPointIndex].transform.position, moveSpeed * Time.deltaTime);
				
			if(transform.position == wayPointsMove[wayPointIndex].transform.position)
			{
				wayPointIndex += 1;
			}
		}
		else{
			wayPointIndex = 0;
		}
	}
	
	IEnumerator Attack()
	{
		bossMouth.gameObject.SetActive(false);
		bossMouthOpen.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		bossMouth.gameObject.SetActive(true);
		bossMouthOpen.gameObject.SetActive(false);
		attackTimeCount = attackTime;
	}
	
	IEnumerator changeColorWhenHit(){
		//đổi màu
		bossBody.gameObject.GetComponent<SpriteRenderer>().color = new Color(255,10,0,255);
		GetDame();
		yield return new WaitForSeconds(0.1f);
		//đổi lại màu
		bossBody.gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Bullet")
		{
			StartCoroutine(changeColorWhenHit());
		}
	}
}
