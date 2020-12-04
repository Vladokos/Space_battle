using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int hp;
    public int enemyHp;
    public int dm = 1;

    public BoxCollider2D bC, bc2;
    public Rigidbody2D rB2D;

    public float speed;
    [SerializeField] private float speedAttack;

    public List<Transform> moveSpots;

    private int randomSpot;

    private float waitTime;
    public float startWaitTime;

    private Statistick _statistick;
    private PlayerControllers pC;
    private BossCollider _bossCollider;

    private Vector3 _position;
    private GameObject explosion;

    public Animator animat;

    private GameObject player;

    public SpriteRenderer[] spriteRend;

    public GameObject[] bossKeepers;
    public Transform[] spotsMoveKeep;

    public GameObject BossHealler;
    public GameObject BossKnight;
    private void Start()
    {
        enemyHp = hp;

        randomSpot = Random.Range(0, moveSpots.Count);
        waitTime = startWaitTime;

        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();
        _bossCollider = GameObject.Find("BoxAttackCollider").GetComponent<BossCollider>();

        explosion = GameObject.Find("Explosion");
        player = GameObject.Find("Player");


    }

    private void Update()
    {
        //Запрещает боссу передвигаться во время атаки лазером
        if (_bossCollider.IsHere == false && pC._gameOver == false)
        {
            MoveBoss();
        }
        if(pC._gameOver == false)
        {
            TypeOfAttackBoss();
            TwoStageBoss();
        }
        if(pC._gameOver != false)
        {
            speed = 0;
            speedAttack = 0;
        }
        else
        {
            speed = 4;
            speedAttack = 1000;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Получениее  урона при соприкосновения с пулей
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
    }
    void Dm()
    {
        enemyHp -= _statistick.dm;
    }
    //Движение босса по 2 точкам
    private void MoveBoss()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)//Отсчет времени чтобы передвинуться на следующую точку
            {
                randomSpot = Random.Range(0, moveSpots.Count);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    IEnumerator Charge()
    {
        yield return new WaitForSeconds(1f);

        Vector3 charge = (player.transform.position - transform.position).normalized;
        rB2D.AddForce(charge * speedAttack);
    }
    //Остановка атаки и возвращение к движению босса
    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(4f);
        animat.SetBool("IsDone", true);
        animat.SetInteger("Ready", 0);
        animat.SetInteger("TypeOfAttack", 0);

        _bossCollider.IsHere = false;
    }
    private void TypeOfAttackBoss()
    {
        //Если игрок вошёл в коллайдер босса то происxодит атака
        if (_bossCollider.IsHere == true )
        {

            animat.SetBool("IsDone", false);

            animat.SetInteger("Ready", _bossCollider.typeOfAttack);//Выбирается тип атаки лазером или корпусом
            animat.SetInteger("TypeOfAttack", _bossCollider.typeLaserAttack);//Выбирается тип атаки лазером 
            if (_bossCollider.typeOfAttack == 1 && pC._gameOver == false)
            {
                StartCoroutine(Charge());
            }
            StartCoroutine(StopAttack());
        }

    }
    //Смена спрайта босса при второй стадии когда меньше 20 хп
    private void TwoStageBoss()
    {
        if(enemyHp <= 20)
        {

            spriteRend[0].sprite = spriteRend[1].sprite;
            for (int i = 0; i < bossKeepers.Length; i++)
            {
                bossKeepers[i].gameObject.SetActive(true);
            }
            bossKeepers[0].transform.DOMoveY(spotsMoveKeep[0].transform.position.y, 1);
            bossKeepers[1].transform.DOMoveX(spotsMoveKeep[1].transform.position.x, 1);
            bossKeepers[2].transform.DOMoveX(spotsMoveKeep[2].transform.position.x, 1);
            BossHealler.transform.DOMoveX(spotsMoveKeep[3].transform.position.x, 1);
            BossKnight.gameObject.SetActive(true);
        }
    }
}
