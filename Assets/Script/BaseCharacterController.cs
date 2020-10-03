using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseCharacterController : MonoBehaviour
{
	public bool isActive = false;
	[SerializeField]
	protected int maxHP = 1;
	[SerializeField]
	protected float defaultSpeed = 0;
	[SerializeField]
	protected int defaultPower = 0;
	//ここから追加
	[SerializeField]
	protected float jumpPower = 0;
	[SerializeField]
	protected GameObject[] groundCheckObjects = new GameObject[3];
	protected int hp = 0;
	protected float speed = 0;
	protected int power = 0;
	protected GameObject gameManagerObj;
	protected GameManager gameManager;
	//ここから追加
	protected bool isGrounded = false;
	protected bool isGroundedPrev = false;
	protected float direction = 1;
	float step_time = 0;

	public int Hp
	{
		set
		{
			hp = Mathf.Clamp(value, 0, maxHP);

			if(hp <= 0)
			{
				Dead();
				step_time += Time.deltaTime;

				if (step_time > 1.0f)
				{
					SceneManager.LoadScene("Stagechoice");
				}
			}
		}
		get
		{
			return hp;
		}
	}

	public float Speed
	{
		set
		{
			speed = value;
		}
		get
		{
			return speed;
		}
	}

	public int Power
	{
		set
		{
			power = Mathf.Max(value, 0);
		}
		get
		{
			return power;
		}
	}


    protected virtual void Start()
    {
		//gameManagerObj = GameObject.FindGameObjectWithTag("GameController");
		//gameManager = gameManagerObj.GetComponent<GameManager>();

		InitCharacter();
    }

    protected virtual void Update()
    {
        
    }

	protected virtual void FixedUpdate()
	{
		FixedUpdateCharacter();
	}

	protected virtual void FixedUpdateCharacter()
	{

	}

	protected virtual void InitCharacter()
	{
		Hp = maxHP;
		Speed = defaultSpeed;
		direction = transform.localScale.x; //追加

		isActive = true;
	}

	protected virtual void Move()
	{

	}

	protected virtual void Damage()
	{

	}

	protected virtual void Dead()
	{

	}

	//ここから追加
	protected virtual void UpdateAnimation()
	{
	}
	protected void GroundCheck()
	{
		isGroundedPrev = isGrounded;
		Collider2D[] groundCheckCollider = new Collider2D[groundCheckObjects.Length];
		//接地判定オブジェクトが何かに重なっているかどうかをチェック
		for (int i = 0; i < groundCheckObjects.Length; i++)
		{
			groundCheckCollider[i] = Physics2D.OverlapPoint(groundCheckObjects[i].transform.position);
			//接地判定オブジェクトのうち、1つでも何かに重なっていたら接地しているものとして終了
			if (groundCheckCollider[i] != null)
			{
				isGrounded = true;
				return;
			}
		}
		//ここまできたということは何も重なっていないということなので、接地していないと判断する
		isGrounded = false;
	}

}
