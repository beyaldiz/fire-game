using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour {
    public GameObject fb;
    public GameObject fs;
    public GameObject sf;
    GameObject tmp;
    public float cooldownQ = 1F;
    public float cooldownW = 5F;
    public float cooldownE = 10F;
    public float cooldownR = 15F;
    public float cooldownD = 25F;
    public float cooldownF = 20F;
    public float stuntime = 10F;
    private float cooldownQtimer;
    private float cooldownWtimer;
    private float cooldownEtimer;
    private float cooldownRtimer;
    private float cooldownDtimer;
    private float cooldownFtimer;
    private float stuntimetimer;
    Transform _player;
    SpriteRenderer _pr;
    Sp _mana;
    Hp _hp;
	void Start ()
    {
        
	}
	void Update ()
    {
        tmp = GameObject.FindWithTag("Player");
        _player = tmp.GetComponent<Transform>();
        _pr = tmp.GetComponent<SpriteRenderer>();
        _mana = tmp.GetComponent<Sp>();
        _hp = tmp.GetComponent<Hp>();
        if (Input.GetKeyDown("q") && cooldownQtimer==0)
            throwFb();
        if (cooldownQtimer > 0)
            cooldownQtimer -= Time.deltaTime;
        if (cooldownQtimer < 0)
            cooldownQtimer = 0;

        if (Input.GetKeyDown("w") && cooldownWtimer == 0 && _mana.sP>=10)
            throwFs();
        if (cooldownWtimer > 0)
            cooldownWtimer -= Time.deltaTime;
        if (cooldownWtimer < 0)
            cooldownWtimer = 0;

        if (Input.GetKeyDown("e") && cooldownEtimer == 0 && _mana.sP >= 20)
            throwSf();
        if (cooldownEtimer > 0)
            cooldownEtimer -= Time.deltaTime;
        if (cooldownEtimer < 0)
            cooldownEtimer = 0;

        if (Input.GetKeyDown("r") && cooldownRtimer == 0 && _mana.sP >= 30)
            stun();
        if (cooldownRtimer > 0)
            cooldownRtimer -= Time.deltaTime;
        if (cooldownRtimer < 0)
            cooldownRtimer = 0;

        if (Input.GetKeyDown("d") && cooldownDtimer == 0)
            gainhp();
        if (cooldownDtimer > 0)
            cooldownDtimer -= Time.deltaTime;
        if (cooldownDtimer < 0)
            cooldownDtimer = 0;

        if (Input.GetKeyDown("f") && cooldownFtimer == 0)
            gainsp();
        if (cooldownFtimer > 0)
            cooldownFtimer -= Time.deltaTime;
        if (cooldownFtimer < 0)
            cooldownFtimer = 0;

        if (stuntimetimer == 0)
            finstun();
        if (stuntimetimer > 0)
            stuntimetimer -= Time.deltaTime;
        if (stuntimetimer < 0)
            stuntimetimer = 0;
    }
    void throwFb()
    {
        if (_pr.flipX == false)
            Instantiate(fb, new Vector2(_player.position.x + 1, _player.position.y), Quaternion.identity);
        else if (_pr.flipX == true)
            Instantiate(fb, new Vector2(_player.position.x - 1, _player.position.y), Quaternion.identity);
        cooldownQtimer = cooldownQ;
    }
    public void fbforTouch()
    {
        if (cooldownQtimer == 0)
            throwFb();
    }

    void throwFs()
    {
        if (_pr.flipX == false)
            Instantiate(fs, new Vector2(_player.position.x + 4, _player.position.y + 10), Quaternion.identity);
        else if (_pr.flipX == true)
            Instantiate(fs, new Vector2(_player.position.x - 4, _player.position.y + 10), Quaternion.identity);
        cooldownWtimer = cooldownW;
        _mana.sP -= 10;
    }

    public void fsforTouch()
    {
        if (cooldownWtimer == 0 && _mana.sP >= 10)
            throwFs();
    }
    void throwSf()
    {
        if (_pr.flipX == false)
            Instantiate(sf, new Vector2(_player.position.x + 2, _player.position.y), Quaternion.identity);
        else if (_pr.flipX == true)
            Instantiate(sf, new Vector2(_player.position.x - 2, _player.position.y), Quaternion.identity);
        cooldownEtimer = cooldownE;
        _mana.sP -= 20;
    }
    public void sfforTouch()
    {
        if (cooldownEtimer == 0 && _mana.sP >= 20)
            throwSf();
    }
    void gainhp()
    {
        _hp.hP = _hp.maxHp;
        cooldownDtimer = cooldownD;
    }

    public void gainhpforTouch()
    {
        if (cooldownDtimer == 0)
            gainhp();
    }
    void gainsp()
    {
        _mana.sP = _mana.maxSp;
        cooldownFtimer = cooldownF;
    }

    public void gainspforTouch()
    {
        if (cooldownFtimer == 0)
            gainsp();
    }
    void stun()
    {
        GameObject[] go;
        go = GameObject.FindGameObjectsWithTag("Enemy");
        int length = go.Length;//Length 1 kere cekmek onemli

        Enemy[] enemy = new Enemy[length];

        for(int i = 0; i < length; i++)
        {
            enemy[i] = go[i].GetComponent<Enemy>();
            enemy[i].isStunned = true;
        }
        cooldownRtimer = cooldownR;
        stuntimetimer = stuntime;
    }

    void finstun()
    {
        GameObject[] go;
        go = GameObject.FindGameObjectsWithTag("Enemy");
        int length = go.Length;//Length 1 kere cekmek onemli

        Enemy[] enemy = new Enemy[length];

        for (int i = 0; i < length; i++)
        {
            enemy[i] = go[i].GetComponent<Enemy>();
            enemy[i].isStunned = false;
        }
    }

    public void stunforTouch()
    {
        if (cooldownRtimer == 0 && _mana.sP >= 30)
            stun();
    }
    public float getCooldownQ()
    {
        return cooldownQtimer;
    }

    public float getCooldownW()
    {
        return cooldownWtimer;
    }

    public float getCooldownE()
    {
        return cooldownEtimer;
    }
    public float getCooldownD()
    {
        return cooldownDtimer;
    }
    public float getCooldownR()
    {
        return cooldownRtimer;
    }
    public float getCooldownF()
    {
        return cooldownFtimer;
    }
}
