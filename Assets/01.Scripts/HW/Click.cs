using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Click : MonoBehaviour
{
    [SerializeField] Image ExpImg;
    bool isOn;
    public void OnStart()
    {
        SceneManager.LoadScene("Main");
        
    }

    public void OnExplain()
    {
        
        if (!isOn)
        {
            ExpImg.transform.DOScale(new Vector3(1, 1, 1), .5f);
            isOn = true;
        }
        else
        {
            ExpImg.transform.DOScale(new Vector3(0, 0, 0), .5f);
            isOn = false;
        }
    }

    public void OnX()
    {
        ExpImg.transform.DOScale(new Vector3(0, 0, 0), .5f);
        isOn = false;
    }
}
