using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private int countTime;
    public Image timerImage;

    public float totalTime;
    public int totalCorrectHero;

    private bool callGG;

    void Start()
    {
        timerImage = GetComponent<Image>();
        totalTime = 0;
        totalCorrectHero = 0;

        callGG = false;

        //colorImage = timerImage.GetComponent<Image>().color;
        //colorImage = Color.green;
    }

    void Update()
    {
        if (timerImage.fillAmount != 0)
        {
            timerImage.fillAmount -= 1.0f / countTime * Time.deltaTime;
            totalTime += Time.deltaTime;
        }
        else
        {
            if (callGG == false)
            {
                GameObject obj = GameObject.FindGameObjectWithTag("GameController");
                obj.GetComponent<GenerationHeroes>().GameOver();

                callGG = true;
            }
        }
    }

    public void PlusTime()
    {
        if (timerImage.fillAmount > 0)
        {
            timerImage.fillAmount += 3.0f / countTime;
            totalCorrectHero++;
        }
    }

    public void MinusTime()
    {
        timerImage.fillAmount -= 4.0f / countTime;
    }
}
