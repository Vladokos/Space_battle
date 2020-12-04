using UnityEngine;

public class MoveEnemyBullet : MonoBehaviour
{
    private float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Движение вражеских пуль
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    //Если дотрагивается до коллайдера DetectColl то удаляется
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DetectColl"))
        {
            Destroy(gameObject);
        }
    }
}
