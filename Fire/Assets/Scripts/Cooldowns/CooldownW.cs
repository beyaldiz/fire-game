using UnityEngine;
using System.Collections;

public class CooldownW : MonoBehaviour {
    Transform cdq;
    void Start()
    {
        cdq = GetComponent<Transform>();
    }

    void Update()
    {
        GameObject tmp = GameObject.FindWithTag("GameManager");
        Skills temp = tmp.GetComponent<Skills>();
        float remainingcd = temp.getCooldownW();
        cdq.localScale = new Vector3(cdq.localScale.x, remainingcd * 3.6F / temp.cooldownW, cdq.localScale.z);
    }
}
