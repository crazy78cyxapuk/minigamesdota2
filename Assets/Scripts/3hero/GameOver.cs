using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text timeTxt, countHeroTxt;
    private int time, countHero;
    private GameObject obj;

    private void Start()
    {
        timeTxt.text = "";
        countHeroTxt.text = "";

        obj = GameObject.FindGameObjectWithTag("Timer");
    }

    public void StartPrintAllText()
    {
        StartCoroutine(PrintText());
    }

    IEnumerator PrintText()
    {
        float waitTime = 0.1f;

        timeTxt.text += "в";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "р";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "е";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "м";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "е";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "н";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "и ";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "с";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "ы";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "г";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "р";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "а";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "н";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += "о";
        yield return new WaitForSeconds(waitTime);
        timeTxt.text += ": ";
        yield return new WaitForSeconds(waitTime);

        double roundTime = Math.Round(obj.GetComponent<Timer>().totalTime, 1, MidpointRounding.AwayFromZero);
        timeTxt.text += roundTime;
        yield return new WaitForSeconds(waitTime);

        countHeroTxt.text += "г";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "е";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "р";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "о";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "е";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "в ";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "н";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "а";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "й";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "д";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "е";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "н";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += "о";
        yield return new WaitForSeconds(waitTime);
        countHeroTxt.text += ": ";
        yield return new WaitForSeconds(waitTime);

        countHeroTxt.text += obj.GetComponent<Timer>().totalCorrectHero;
    }
}
