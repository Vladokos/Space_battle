using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private float speed = 10f;

    private EnemyLife _enemyLife;

    public int dammage;
    void Start()
    {

    }

    // Пуля двигается
    void Update()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

}
