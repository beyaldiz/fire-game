using UnityEngine;
using System.Collections;

public class CooldownQ : MonoBehaviour {
    Transform cdq;
	void Start ()
    {
        cdq = GetComponent<Transform>();
	}

	void Update ()
    {
        GameObject tmp = GameObject.FindWithTag("GameManager");
        Skills temp = tmp.GetComponent<Skills>();
        float remainingcd = temp.getCooldownQ();
        cdq.localScale = new Vector3(cdq.localScale.x, remainingcd * 3.6F / temp.cooldownQ, cdq.localScale.z);
	}
}
