using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float hP = 100;
    public float cooldown = 1F;
    public bool isStunned=false;
    float cooldowntimer;
    Rigidbody2D rb;
    Transform tr;
    SpriteRenderer sr;
    Transform playerTransform;
    Animator anim;
    Hp playerhp;
    Transform hpbar;
    public float moveSpeed=4F;
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        GameObject tmp = GameObject.FindWithTag("Player");
        playerTransform = tmp.GetComponent<Transform>();
        playerhp = tmp.GetComponent<Hp>();
        sethpbar();
        followplayer();
        flipx();
        if (hP <= 0)
        {
            scorecount();
            Destroy(gameObject);
        }
        if (cooldowntimer == 0 && (playerTransform.position.x - tr.position.x <= 1.5 && playerTransform.position.x - tr.position.x >= -1.5 && playerTransform.position.y - tr.position.y >= -1.5 && playerTransform.position.y - tr.position.y <= 1.5) && isStunned==false)
            attack();
        if (cooldowntimer > 0)
            cooldowntimer -= Time.deltaTime;
        if (cooldowntimer < 0)
        {
            cooldowntimer = 0;
            anim.SetBool("Attack", false);
        }
        
        
    }
    void followplayer()
    {
        if (playerTransform.position.x - tr.position.x > 1.5 && isStunned==false)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            anim.SetBool("Attack", false);
        }
            
        else if (playerTransform.position.x - tr.position.x < -1.5 && isStunned==false)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.SetBool("Attack", false);
        }
            
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }
    void flipx()
    {
        if (rb.velocity.x > 0.2)
            sr.flipX = false;
        if (rb.velocity.x < -0.2)
            sr.flipX = true;
    }

    void attack()
    {
        playerhp.hP -= 5;
        anim.SetBool("Attack", true);
            cooldowntimer = cooldown;
    }

    void sethpbar()
    {
        hpbar = GetComponent<Transform>();
        hpbar = hpbar.GetChild(0);
        hpbar.localScale = new Vector2(hP / 100, hpbar.localScale.y);
    }
    void scorecount()
    {
        GameObject tmp = GameObject.FindWithTag("GameManager");
        Score sc = tmp.GetComponent<Score>();
        sc.score += 1;
        sc.SetScore();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FireBall")
            hP -= 10;
        if (other.gameObject.tag == "FireStrike")
            hP -= 30; 
        if (other.gameObject.tag == "ScorchingFire")
            hP -= 30;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FireBall")
            hP -= 10;
        if (other.gameObject.tag == "FireStrike")
            hP -= 30;
        if (other.gameObject.tag == "ScorchingFire")
            hP -= 30;
    }
    
}
