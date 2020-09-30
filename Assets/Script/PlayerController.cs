using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]


public class PlayerController : BaseCharacterController
{
    [SerializeField]
    string horizontalInputName = "Horizontal";
    [SerializeField]
    string jumpButtonName = "Jump";
    bool jump = false;
    bool damage = false;
    float inputH = 0;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;


    //float steakCount;
    //public Text steakUI;
    ////public GameObject[] steak= new GameObject[6];
    //public GameObject steak;


    //会話イベント時にプレイヤーの動きを止める変数
    public bool controllEnabled { get; set; } = true;



    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    protected override void Update()
    {
        if(controllEnabled == true) { 
        GetInput();
        }
    }
    protected override void FixedUpdate()
    {
        if (controllEnabled == true)
        {
            Move();
        }
    }
    void GetInput()
    {
        if (!isActive)
        {
            return;
        }
        inputH = Input.GetAxisRaw(horizontalInputName);
        jump = Input.GetButtonDown(jumpButtonName);
    }
    protected override void Move()
    {
        if (controllEnabled == true)
        {
            if (!isActive)
            {
                return;
            }
            //接地判定
            GroundCheck();
            //移動速度の計算処理
            if (inputH != 0)
            {
                direction = Mathf.Sign(inputH);
                speed = defaultSpeed * direction;
                //入力がマイナスならスプライトの向きを反転させる
                spriteRenderer.flipX = direction < 0 ? true : false;
            }
            else
            {
                speed = 0;
            }
            //ジャンプの速度計算
            if (jump && isGrounded)
            {
                rigidBody2D.velocity = Vector3.up * jumpPower;
            }
            //アニメーションを更新
            UpdateAnimation();
            //実際の移動処理
            rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);
        }
    }

    protected override void Damage()
    {

        //既にダメージ状態（＝無敵時間中）なら終了
        if (damage)
        {
            return;
        }
        //ヒットポイントを-1
        //Hpプロパティにより、HPが0になると自動的にDead()が呼ばれる（※BaseCharacterController参照）
        Hp--;
        GameOver.DecreaseHp();
        //GameOver.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
        if (Hp > 0)
        {
            StartCoroutine("DamageTimer");
            
        }

    }


    //追加
    //ダメージを受けた瞬間の無敵時間のタイマー
    protected IEnumerator DamageTimer()
    {
        //既にダメージ状態なら終了
        if (damage)
        {
            yield break;
        }
        damage = true;
        animator.SetTrigger("Damage");
        //無敵時間中の点滅
        for (int i = 0; i < 10; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
        damage = false;
    }
    //追加
    //敵に触れたらダメージ
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }


    }


    protected override void Dead()
    {
        isActive = false;
        GameOver.GameeOver();
    }
    protected override void UpdateAnimation()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        animator.SetBool("Jump", !isGrounded);
    }



    }