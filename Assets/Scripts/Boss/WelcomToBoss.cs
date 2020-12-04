using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomToBoss : MonoBehaviour
{
    public List<GameObject> offGm;
    public ParticleSystem wave;
    void Start()
    {
        foreach (GameObject sprites in offGm)
        {
            sprites.gameObject.SetActive(false);
        }
        wave.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(onGm());
    }
    IEnumerator onGm()
    {
        yield return new WaitForSeconds(5f);
        foreach (GameObject sprites in offGm)
        {
            sprites.gameObject.SetActive(true);
            wave.gameObject.SetActive(false);
        }
    }
}
