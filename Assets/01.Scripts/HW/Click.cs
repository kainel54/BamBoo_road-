using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] Image GearImg;
    [SerializeField] Image ExpImg;
    public void OnStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnExplain()
    {
        if(ExpImg.enabled)
        {
            ExpImg.enabled = false;
        }
        GearImg.enabled = true;

    }

    public void OnGear()
    {
        if(GearImg.enabled)
        {
            ExpImg.enabled = false;
        }
        ExpImg.enabled = true;
    }
}
