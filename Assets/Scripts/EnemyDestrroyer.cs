using System.Collections;
using UnityEngine;

public class EnemyDestrroyer : MonoBehaviour
{
    public int hp;
    public int enemyHp;

    private float speed = 5f;

    public BoxCollider2D bC;
    public Rigidbody2D rB2D;
    public Animator fireEngine;

    private GameObject player;
    private PlayerControllers pC;

    public GameObject _fireEngine;

    private GameObject explosion;
    private Vector3 _position;
    // Start is called before the first frame update
    void Start()
    {
        explosion = GameObject.Find("Explosion");

        enemyHp = hp;

        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Charge();
    }
    //Если дотронулся пуля игрока то отнимается жизнь || eсли дотрагивается до игрока то вызрывается 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LaserBullet"))
        {
            Dm(1);
            Destroy(collision.gameObject);
            if (enemyHp < 1)
            {
                pC.enemyDestroy = true;
                bC.enabled = false;
                Destroy(gameObject);
                _position = new Vector3(transform.position.x, transform.position.y, -38f);
                Instantiate(explosion, _position, Quaternion.identity);
                speed = 0;
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            _position = new Vector3(transform.position.x, transform.position.y, -38f);
            Instantiate(explosion, _position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("DetectColl"))
        {
            Destroy(gameObject);
        }

    }
    //Уменьшение здоровья 
    void Dm(int dm)
    {
        enemyHp -= dm;
    }
    //Если есть игрок на сцене то летит на него
    void Charge()
    {
        if (player != null && hp == 1)
        {
            Vector3 charge = (player.transform.position - transform.position).normalized;
            rB2D.AddForce(charge * speed);
            _fireEngine.gameObject.SetActive(true);
            fireEngine.SetBool("move", true);
        }
    }
}
