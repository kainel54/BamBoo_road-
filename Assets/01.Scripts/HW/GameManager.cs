using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        scoreText.text = string.Format($"{score}");
    }

    public void ScorePlus()
    {
        score++;
        scoreText.text = string.Format($"{score}");
        StartCoroutine(PlusRoutine());
    }

    private IEnumerator PlusRoutine()
    {
        scoreText.transform.DOScale(new Vector3(0.65f, 0.65f, 0.65f), 0.1f);
        yield return new WaitForSeconds(0.2f);
        scoreText.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f);

    }
}
