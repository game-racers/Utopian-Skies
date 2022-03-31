using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsPage;
    public bool creditsIn;

    private void Start()
    {
        creditsIn = false;
    }

    public void MoveCredits()
    {
        if (creditsIn == false)
        {
            creditsPage.transform.DOMoveX(155, 1);
            creditsIn = true;
        }
        else
        {
            creditsPage.transform.DOMoveX(-200, 1);
            creditsIn = false;
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
