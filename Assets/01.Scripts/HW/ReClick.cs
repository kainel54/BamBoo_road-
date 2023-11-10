using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ReClick : MonoBehaviour
{
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), .3f);
        }
        else
        {
            transform.DOScale(new Vector3(1f, 1f, 1f), .3f);
        }
    }
}
