using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	void Start ()
    {
	
	}

	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
