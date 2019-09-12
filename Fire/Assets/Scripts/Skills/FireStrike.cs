using UnityEngine;
using System.Collections;

public class FireStrike : MonoBehaviour {

	void Start ()
    {
	    
	}

	void Update ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Enemy")
            Destroy(gameObject);
    }
}
