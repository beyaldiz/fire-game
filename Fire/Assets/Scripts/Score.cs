using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public int score = 0;
    public Text scoreText;
	void Start ()
    {
	    
	}

	void Update ()
    {
        
	}

    public void SetScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
