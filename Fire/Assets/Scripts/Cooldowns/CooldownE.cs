using UnityEngine;
using System.Collections;

public class CooldownE : MonoBehaviour {
    Transform cdq;
    void Start()
    {
        cdq = GetComponent<Transform>();
    }

    void Update()
    {
        GameObject tmp = GameObject.FindWithTag("GameManager");
        Skills temp = tmp.GetComponent<Skills>();
        float remainingcd = temp.getCooldownE();
        cdq.localScale = new Vector3(cdq.localScale.x, remainingcd * 3.6F / temp.cooldownE, cdq.localScale.z);
    }
}
