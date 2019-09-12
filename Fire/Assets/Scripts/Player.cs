using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    Rigidbody2D _Player;
    SpriteRenderer _Renderer;
    public float moveSpeed = 4F;
    public float jumpForce = 400F;
    float speedX;
    bool isGrounded = false;
	void Start ()
    {
        _Player = GetComponent<Rigidbody2D>();
        _Renderer = GetComponent<SpriteRenderer>();
    }
    ///////////////////////////////////////////////////////////////////////////
	void Update ()
    {
        controlplayer(speedX);
        if (Input.GetKeyDown("left"))
            speedX = -moveSpeed;
        if (Input.GetKeyUp("left"))
            speedX = 0;
        if (Input.GetKeyDown("right"))
            speedX = moveSpeed;
        if (Input.GetKeyUp("right"))
            speedX = 0;
        flipx();
        if (Input.GetKeyDown("up"))
            jump();
	}
    ///////////////////////////////////////////////////////////////////////////

    public void controlplayer(float speed)
    {
        _Player.velocity = new Vector2(speed, _Player.velocity.y);
    }
    public void moveRight()
    {
        speedX = moveSpeed;
    }
    public void moveLeft()
    {
        speedX = -moveSpeed;
    }
    public void stopMove()
    {
        speedX = 0;
    }
    void flipx()
    {
        if (_Player.velocity.x < 0)
            _Renderer.flipX = true;
        else if(_Player.velocity.x > 0)
            _Renderer.flipX = false;
    }
    public void jump()
    {
        if (isGrounded)
            _Player.AddForce(new Vector2(_Player.velocity.x,jumpForce));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }
}
