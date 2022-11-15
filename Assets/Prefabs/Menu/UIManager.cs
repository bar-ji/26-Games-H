using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMPro.TMP_Text scoreTxt;
    [SerializeField] private TMPro.TMP_Text scoreTxt2;

    int score;

    void Start()
    {
        UpdateScore(0);
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
    }

    public void UpdateScore(int _score)
    {
        score += _score;
        scoreTxt.text = "Score: " + score;
        scoreTxt2.text = "Score: " + score;
    }

}
