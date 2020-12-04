using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarMenu : MonoBehaviour
{
    public Animator[] rightArrow;
    public Animator[] leftArrow;

    public GameObject grabber,graberLayout;
    public GameObject[] Ships;
    public GameObject exportLight, importLight;

    private int checkClickRightArrow = 0, checkClickLeftArrow = 0;
    //Открывает новую "страницу" со скинами
    public void clickRightArrow()
    {
        if(checkClickLeftArrow == 1)
        {
            rightArrow[0].SetBool("left_Arrow_is_clicked", false);
            leftArrow[1].SetBool("ShipInPlatform", false);
            StartCoroutine(layoutshipSetActive());
        }

        rightArrow[1].SetBool("right_Arrow_is_clicked", true);
        StartCoroutine(ChangeRightArrow());

        if(checkClickRightArrow == 0)
        {
            importLight.SetActive(true);
            rightArrow[3].SetBool("right_Arrow_is_clicked", true);
        }

        Ships[2].SetActive(true);
        rightArrow[2].SetBool("right_Arrow_is_clicked", true);

        checkClickRightArrow = 1;
        checkClickLeftArrow = 0;
    }
    IEnumerator ChangeRightArrow()//изменить название 
    {
        yield return new WaitForSeconds(1f);
        Ships[0].SetActive(false);
        Ships[4].SetActive(true);
        rightArrow[1].SetBool("Ship_is_fixed", true);

        rightArrow[0].SetBool("right_Arrow_is_clicked", true);

        yield return new WaitForSeconds(1f);
        rightArrow[3].SetBool("right_Arrow_is_clicked", false);
        rightArrow[2].SetBool("right_Arrow_is_clicked", false);
        rightArrow[0].SetBool("right_Arrow_is_clicked", false);

        yield return new WaitForSeconds(1.5f);
        grabber.SetActive(false);
        importLight.SetActive(false);

    }

    //Возвращает старую "страницу" со скинами
    public void clickLeftArrow()
    {

        if(checkClickRightArrow == 1)
        {
            exportLight.SetActive(true);
            leftArrow[0].SetBool("left_Arrow_is_clicked", true);

            rightArrow[2].SetBool("left_Arrow_is_clicked", true);
            StartCoroutine(ChangeLeftArrow());

            rightArrow[0].SetBool("left_Arrow_is_clicked", true);
            graberLayout.SetActive(true);

            checkClickLeftArrow = 1;
            checkClickRightArrow = 0;
        }
    }
    IEnumerator ChangeLeftArrow()//изменить название
    {
        yield return new WaitForSeconds(1f);
        Ships[2].SetActive(false);

        yield return new WaitForSeconds(3f);
        leftArrow[1].SetBool("IsFixed", true);

        yield return new WaitForSeconds(1f);
        leftArrow[1].SetBool("ShipInPlatform", true);
        Ships[3].SetActive(false);
        Ships[0].SetActive(true);
    }
    IEnumerator layoutshipSetActive()
    {
        yield return new WaitForSeconds(1f);
        Ships[0].SetActive(false);
        Ships[3].SetActive(true);

        yield return new WaitForSeconds(2f);
        rightArrow[1].SetBool("Ship_is_fixed", false);
        graberLayout.SetActive(false);
    }

}

