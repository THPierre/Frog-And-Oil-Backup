using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUi : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = "Pas encore fait";
    }
}
