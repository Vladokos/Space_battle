using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKeepers : MonoBehaviour
{
    public int hp;
    public int enemyHp;

    public float speed = 5f;

    private Transform playerBullet;
    public Rigidbody2D rB2D;

    private PlayerControllers pC;
    void Start()
    {
        enemyHp = hp;

        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
    }

    // Update is called once per frame
    void Update()
    {
        SearchBullet();
    }
    //Ищет пули игрока и летит на них чтоб защитить босса
    private void SearchBullet()
    {
        playerBullet = GameObject.FindWithTag("LaserBullet").transform;
        if (playerBullet != null)
        {
            Vector2 charge = new Vector2(playerBullet.position.x - transform.position.x, 
                playerBullet.position.y - transform.position.y);
            /*transform.Translate(charge * Time.deltaTime * speed);*/
            transform.DOMove(charge  * speed, 1);
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
