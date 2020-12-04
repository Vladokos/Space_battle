using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightBoss : MonoBehaviour
{
    public int hp;
    public int enemyHp;

    public float waitTime, coolDownd;

    public GameObject enemyBullet;

    private Boss _boss;
    private PlayerControllers pC;
    // Start is called before the first frame update
    void Start()
    {
        _boss = GameObject.Find("Boss_m1").GetComponent<Boss>();
        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Reload();
    }
    private void Reload()
    {
        if (_boss.enemyHp <= 20 && waitTime <= 0 && pC._gameOver == false)
        {
            waitTime = coolDownd;
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
        }
        if (waitTime >= 0 && pC._gameOver == false)
        {
            waitTime -= Time.deltaTime;
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
