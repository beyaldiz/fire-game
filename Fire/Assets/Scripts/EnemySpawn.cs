using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    public GameObject Enemy;
    public float spawntime = 3F;
    float timer;
    void Start ()
    {
	    
	}
	
	void Update ()
    {
        if (timer == 0)
            spawn();
        if (timer > 0)
            timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
        }
    }

    void spawn()
    {
        int a = Random.Range(0, 2);
        if(a==0)
            Instantiate(Enemy, new Vector2(-7,4), Quaternion.identity);
        if(a==1)
            Instantiate(Enemy, new Vector2(7, 4), Quaternion.identity);
        spawntime -= 1;
        if (spawntime < 3)
            spawntime = 3;
        timer = spawntime;
    }
}
