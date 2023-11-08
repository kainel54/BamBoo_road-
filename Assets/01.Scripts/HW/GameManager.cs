using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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


        
    }
}
