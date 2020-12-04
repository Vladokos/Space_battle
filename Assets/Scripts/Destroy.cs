using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroyLaserBullet();
    }
    // Уничтожение пулек которые по y > 23
    void DestroyLaserBullet()
    {
        if (CompareTag("LaserBullet") && transform.position.y > 23f)
        {
            Destroy(gameObject);
            Debug.Log("bulletDestroy");
        }
    }
}
