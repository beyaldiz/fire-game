using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {
    Animator anim;
    public float AnimTime = 0.2F;
    float timerq;
    float timerw;
    float timere;
    Skills skill;
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	void Update ()
    {
        GameObject tmp = GameObject.FindWithTag("GameManager");
        skill = tmp.GetComponent<Skills>();
        if (Input.GetKeyDown("q") && skill.getCooldownQ() == 0)
            setanimq();
        if (timerq > 0)
            timerq -= Time.deltaTime;
        if (timerq < 0)
        {
            timerq = 0;
            anim.SetInteger("Action", 0);
        }

        if (Input.GetKeyDown("w") && skill.getCooldownW() == 0)
            setanimw();
        if (timerw > 0)
            timerw -= Time.deltaTime;
        if (timerw < 0)
        {
            timerw = 0;
            anim.SetInteger("Action", 0);
        }

        if (Input.GetKeyDown("e") && skill.getCooldownE() == 0)
            setanime();
        if (timere > 0)
            timere -= Time.deltaTime;
        if (timere < 0)
        {
            timere = 0;
            anim.SetInteger("Action", 0);
        }
    }
    void setanimq()
    {
        timerq = AnimTime;
        anim.SetInteger("Action", 1);
    }

    void setanimw()
    {
        timerw = AnimTime;
        anim.SetInteger("Action", 2);
    }

    void setanime()
    {
        timere = AnimTime;
        anim.SetInteger("Action", 1);
    }
    public void setanimqforTouch()
    {
        GameObject tmp = GameObject.FindWithTag("GameManager");
        skill = tmp.GetComponent<Skills>();
        if (skill.getCooldownQ() == 0)
            setanimq();
    }

    public void setanimwforTouch()
    {
        GameObject tmp = GameObject.FindWithTag("GameManager");
        skill = tmp.GetComponent<Skills>();
        if (skill.getCooldownW() == 0)
            setanimw();
    }

    public void setanimeforTouch()
    {
        GameObject tmp = GameObject.FindWithTag("GameManager");
        skill = tmp.GetComponent<Skills>();
        if (skill.getCooldownE() == 0)
            setanime();
    }
}
