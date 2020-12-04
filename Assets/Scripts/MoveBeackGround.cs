using UnityEngine;

public class MoveBeackGround : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 startPos;
    private float repeat = -83.8f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveUp();
    }
    //Бэкграунд движется вверх и потом повторяется еслии позиция по Y меньше repeat
    void moveUp()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < repeat)
        {
            transform.position = startPos;
        }
    }
}
