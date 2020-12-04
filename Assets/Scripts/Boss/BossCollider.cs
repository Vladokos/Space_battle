using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    public bool IsHere;

    public int typeOfAttack;
    public int typeLaserAttack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsHere = true;

            typeLaserAttack = Random.Range(0, 3);
            typeOfAttack = Random.Range(1, 3);
        }
    }
}
