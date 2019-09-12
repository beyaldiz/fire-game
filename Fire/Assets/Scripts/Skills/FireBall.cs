using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
    Rigidbody2D rb;
    GameObject tmp;
    SpriteRenderer _sr;
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        tmp = GameObject.FindWithTag("Player");
        _sr = tmp.GetComponent<SpriteRenderer>();
        setvelocity();
    }

    void Update ()
    {
        
    }
    void setvelocity()
    {
        if (_sr.flipX == false)
            rb.velocity = new Vector2(6, 0);
        if (_sr.flipX == true)
            rb.velocity = new Vector2(-6, 0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
