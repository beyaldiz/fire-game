using UnityEngine;
using System.Collections;

public class ScorchingFire : MonoBehaviour {
    Rigidbody2D rb;
    GameObject tmp;
    SpriteRenderer _srplayer;
    SpriteRenderer _sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tmp = GameObject.FindWithTag("Player");
        _srplayer = tmp.GetComponent<SpriteRenderer>();
        _sr = GetComponent<SpriteRenderer>();
        setvelocity();
        flipx();
    }

    void Update()
    {

    }
    void setvelocity()
    {
        if (_srplayer.flipX == false)
            rb.velocity = new Vector2(10, 0);
        if (_srplayer.flipX == true)
            rb.velocity = new Vector2(-10, 0);
    }
    void flipx()
    {
        if (_srplayer.flipX == false)
            _sr.flipX = false;
        if (_srplayer.flipX == true)
            _sr.flipX = true;
    }
    
}
