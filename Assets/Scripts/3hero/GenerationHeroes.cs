using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerationHeroes : MonoBehaviour
{
    //[SerializeField] private List<Sprite> heroes; //вообще все герои

    [SerializeField] private Sprite[] heroesSprite;

    private GameObject[] prefabHero = new GameObject[49]; //кнопки на поле

    [SerializeField] private GameObject prefab; //готовый префаб

    [SerializeField] private Text taskHeroesTxt; //текст с героями, которых нужно найти
    public string[] searchHero = new string[3];

    public int answerTrue = 0;

    [SerializeField] private GameObject GGpanel;

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        taskHeroesTxt.text = "";
        ClearField();

        InitListHeroes();
        InitTask();
        answerTrue = 0;

        GameObject obj = GameObject.FindGameObjectWithTag("Timer");
        obj.GetComponent<Image>().fillAmount = 1f;
    }

    private void InitListHeroes()
    {
        List<Sprite> newHeroes = new List<Sprite>();

        for (int i = 0; i < heroesSprite.Length; i++)
        {
            newHeroes.Add(heroesSprite[i]);
        }

        for (int i = 0; i < prefabHero.Length; i++)
        {
            prefabHero[i] = Instantiate(prefab, gameObject.transform) as GameObject;

            int rand = Random.Range(0, newHeroes.Count);
            prefabHero[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("icons/" + newHeroes[rand].name);

            newHeroes.RemoveAt(rand);
        }
    }

    private void InitTask()
    {
        int i = 0;
        while (i <= 2)
        {
            int rand = Random.Range(0, prefabHero.Length - 1);

            string nameSprite = prefabHero[rand].GetComponent<Image>().sprite.name;

            if (nameSprite != searchHero[0] && nameSprite != searchHero[1] && nameSprite != searchHero[2])
            {
                if (i == 1 || i == 0)
                {
                    taskHeroesTxt.text += nameSprite + ", ";
                }
                else
                {
                    taskHeroesTxt.text += nameSprite;
                }

                searchHero[i] = nameSprite;
                i++;
            }
        }
    }

    public void ClearField()
    {
        for (int i = 0; i < prefabHero.Length; i++)
        {
            if (prefabHero[i] != null)
            {
                Destroy(prefabHero[i]);
            }
        }
    }

    public void GameOver()
    {
        StartCoroutine(BanPrefab());
    }

    IEnumerator BanPrefab() //показываем в конце, где правильные и неправильные ответы
    {
        for(int i=0; i < prefabHero.Length; i++)
        {
            string nameThisPrefab = prefabHero[i].GetComponent<Image>().sprite.name;

            prefabHero[i].GetComponent<Button>().interactable = false;

            if (nameThisPrefab == searchHero[0] || nameThisPrefab == searchHero[1] || nameThisPrefab == searchHero[2])
            {
                prefabHero[i].GetComponent<Image>().color = Color.green;
            }
            else
            {
                prefabHero[i].GetComponent<Image>().color = Color.red;
            }

            yield return new WaitForSeconds(0.05f);

            if (i == prefabHero.Length - 1)
            {
                GGpanel.SetActive(true);
                yield return new WaitForSeconds(1f);

                GameObject obj = GameObject.FindGameObjectWithTag("GG");
                obj.GetComponent<GameOver>().ShowGGPanel();
            }
        }
    }

    public void ReloadGameBtn()
    {
        StartCoroutine(ReloadGame());
    }

    IEnumerator ReloadGame()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GG");
        obj.GetComponent<GameOver>().HideGGPanel();

        yield return new WaitForSeconds(1f);

        NewGame();
    }
}
