using System;
using UnityEngine;

[Serializable]
public class SightBlock
{
    [SerializeField]
    private GameObject first, second;

    public void deactivate()
    {
        first.SetActive(false);
        second.SetActive(false);
    }

    public void activate()
    {
        first.SetActive(true);
        second.SetActive(true);
    }
}
