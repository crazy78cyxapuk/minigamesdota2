using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip[] correctAnswer;
    [SerializeField] private AudioClip[] noCorrectAnswer;
    [SerializeField] private AudioClip lakatMatatag;
    private AudioSource music;

    private void Start()
    {
        music = gameObject.GetComponent<AudioSource>();
        music.clip = lakatMatatag;
        music.Play();
    }

    public void PlayCorrectAudio()
    {
        int rand = Random.Range(0, correctAnswer.Length - 1);

        music.clip = correctAnswer[rand];
        music.Play();
    }

    public void PlayNoCorrectAudio()
    {
        int rand = Random.Range(0, noCorrectAnswer.Length - 1);

        music.clip = noCorrectAnswer[rand];
        music.Play();
    }
}
