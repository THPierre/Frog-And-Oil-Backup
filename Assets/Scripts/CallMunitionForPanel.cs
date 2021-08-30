using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMunitionForPanel : MonoBehaviour
{
    private BulletShot bulletshotScript;
    // Start is called before the first frame update
    void Start()
    {
        bulletshotScript = GameObject.Find("Player").GetComponent(typeof(BulletShot)) as BulletShot;
    }

    public void SetChosenMunition(int munitionIndex)
    {
        bulletshotScript.chosenMunition = munitionIndex;
    }
}
