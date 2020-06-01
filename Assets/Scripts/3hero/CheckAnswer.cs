using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour
{
    private GameObject content;
    private GameObject timer;
    private string[] answer = new string[3];
    private string nameThisObj;

    private void Start()
    {
        content = GameObject.FindGameObjectWithTag("GameController");
        timer = GameObject.FindGameObjectWithTag("Timer");

        InitAnswer();
        nameThisObj = gameObject.GetComponent<Image>().sprite.name;
    }

    private void InitAnswer()
    {
        for(int i=0; i < answer.Length; i++)
        {
            answer[i] = content.GetComponent<GenerationHeroes>().searchHero[i];
        }
    }

    public void OnClick()
    {
        if(nameThisObj==answer[1] || nameThisObj==answer[2] || nameThisObj == answer[0])
        {
            TrueAnswer();
        }
        else
        {
            FalseAnswer();
        }
    }

    private void TrueAnswer()
    {
        if (timer.GetComponent<Image>().fillAmount > 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
            gameObject.GetComponent<Image>().color = Color.green;

            GameObject obj = GameObject.FindGameObjectWithTag("Timer");
            obj.GetComponent<Timer>().PlusTime();

            content.GetComponent<GenerationHeroes>().answerTrue += 1;
            if (content.GetComponent<GenerationHeroes>().answerTrue >= 3)
            {
                content.GetComponent<GenerationHeroes>().NewGame();
            }

            obj = GameObject.FindGameObjectWithTag("Music");
            obj.GetComponent<Audio>().PlayCorrectAudio();
        }
    }

    private void FalseAnswer()
    {
        gameObject.GetComponent<Button>().interactable = false;
        gameObject.GetComponent<Image>().color = Color.red;

        GameObject obj = GameObject.FindGameObjectWithTag("Timer");
        obj.GetComponent<Timer>().MinusTime();

        obj = GameObject.FindGameObjectWithTag("Music");
        obj.GetComponent<Audio>().PlayNoCorrectAudio();
    }
}
