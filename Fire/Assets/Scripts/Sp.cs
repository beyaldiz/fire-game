using UnityEngine;
using System.Collections;

public class Sp : MonoBehaviour {
    public float sP = 100;
    public float maxSp = 100F;
    public float spRegen=0.01F;
    Transform barValue;
    void Start ()
    {
        
	}
	
	void Update ()
    {
        GameObject tmp = GameObject.FindWithTag("SpBar");
        barValue = tmp.GetComponent<Transform>();
        barValue.localScale = new Vector3((sP / maxSp), barValue.localScale.y, barValue.localScale.z);
        sP += spRegen;
        if (sP >= maxSp)
            sP = maxSp;
    }
}
