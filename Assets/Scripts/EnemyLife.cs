using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    public int hp;
    public int enemyHp;
    public int dm = 1;

    public BoxCollider2D bC, bc2;
    public Rigidbody2D rB2D;

    private PlayerControllers pC;

    public GameObject enemyBullet;

    public float timeShoot, coolDownd;

    private GameObject explosion;

    private Vector3 _position;

    private Statistick _statistick;

    private Vector2 localPos;

    private float randomPosX;
    private float randomPosY;
    Vector2 forward;

    float speed = 7f;

    // Start is called before the first frame update
    void Start()
    {

        enemyHp = hp;

        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();

        bC = GetComponent<BoxCollider2D>();
        rB2D = GetComponent<Rigidbody2D>();

        explosion = GameObject.Find("Explosion");

        randomPosX = Random.Range(6f,-6f);
        randomPosY = Random.Range(-2f, 15f);

        forward = new Vector2(randomPosX, randomPosY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();
        movePoint();
    }
    //Если дотронулся пуля игрока то отнимается жизнь
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LaserBullet"))
        {
            Dm();
            Destroy(collision.gameObject);
            if (enemyHp < 1)
            {
                Destroy(gameObject);
                pC.enemyDestroy = true;
                bC.enabled = false;
                bc2.enabled = false;
                _position = new Vector3(transform.position.x, transform.position.y, -38f);
                Instantiate(explosion, _position, Quaternion.identity);
            }
        }
        //Если дотрагивается игрок то физика будет Kinematic чтоб игрок не мог толкать врага
        if (collision.gameObject.CompareTag("Player"))
        {
            rB2D.bodyType = RigidbodyType2D.Kinematic;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            localPos = new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, forward, Time.fixedDeltaTime * speed);
            print(forward);
            rB2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }
    //Уменьшение здоровья 
    void Dm()
    {
        enemyHp -= _statistick.dm;
    }
    //Вермя через которое может выстрелить враг
    void Shoot()
    {
        if (timeShoot <= 0 && pC._gameOver == false)
        {
            timeShoot = coolDownd;
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
        }
        if (timeShoot > 0 && pC._gameOver == false)
        {
            timeShoot -= Time.deltaTime;
        }
    }
    void movePoint()
    {
        transform.position = Vector2.MoveTowards(transform.position,forward,Time.fixedDeltaTime * speed);
        print(forward);
    }
}
