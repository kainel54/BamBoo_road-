using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawntongnamu : MonoBehaviour
{
    public GameObject Tongnamu;
    void Start()
    {
        SpawnTreed();
    }

    void SpawnTreed()
    {
        StartCoroutine("SpawnTree");
    }

    IEnumerator SpawnTree()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(Tongnamu);
        SpawnTreed();
    }
}
