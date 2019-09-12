using UnityEngine;
using System.Collections;

public class Hp : MonoBehaviour {
    public float hP = 100;
    public float maxHp = 100F;
    Transform barValue;
    void Start()
    {

    }

    void Update()
    {
        GameObject tmp = GameObject.FindWithTag("HpBar");
        barValue = tmp.GetComponent<Transform>();
        barValue.localScale = new Vector3((hP / maxHp), barValue.localScale.y, barValue.localScale.z);
        if (hP >= maxHp)
            hP = maxHp;
        if (hP <= 0)
            Time.timeScale = 0;
    }
}
