using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeller : MonoBehaviour
{
    public int hp;
    public int enemyHp;


    public float reloadHeal, coolDownd;

    private Boss _boss;
    private PlayerControllers pC;
    void Start()
    {
        _boss = GameObject.Find("Boss_m1").GetComponent<Boss>();
        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _boss.transform.position;

        HealSystem();
    }
    private void HealSystem()
    {
        if (_boss.enemyHp <= 20 && reloadHeal <= 0)
        {
            reloadHeal = coolDownd;
            _boss.enemyHp++;
        }
        if (reloadHeal >= 0)
        {
            reloadHeal -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LaserBullet"))
        {
            Dm(1);
            Destroy(collision.gameObject);
            if (enemyHp < 1)
            {
                pC.enemyDestroy = true;
                Destroy(gameObject);
            }
        }
    }
    //Уменьшение здоровья 
    void Dm(int dm)
    {
        enemyHp -= dm;
    }
}
