using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    private Boss _boss;
    // Start is called before the first frame update
    void Start()
    {
        _boss = GameObject.Find("Boss_m1").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        HeathBarChange();
    }
    public void HeathBarChange()
    {
        healthSlider.value = _boss.enemyHp;
    }
}
