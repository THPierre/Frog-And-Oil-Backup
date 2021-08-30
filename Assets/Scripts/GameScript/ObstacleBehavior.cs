using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ObstacleBehavior : MonoBehaviour
{
    public static ObstacleBehavior obstacleBehavior;
    Health_Player gameoverTrigger;
    public GameObject player;
    public SkinnedMeshRenderer playerMesh;
    public float hitCounts;
    public GameObject instructionsText;
    public GameObject parkourSuccess;
    LevelLoader levelLoader;
    UIController uIController;
    public float survivalTime;
    public AudioSource damageFx;
    //public TextMeshProUGUI hitCountText;
    Slider hpSlider; 

    private void Start()
    {
        hpSlider = GameObject.Find("hpSlider").GetComponent<Slider>();
        uIController = GameObject.Find("Main Camera").GetComponent<UIController>();
        levelLoader = GameObject.Find("GameManager").GetComponent<LevelLoader>();
        gameoverTrigger = GameObject.Find("Player").GetComponent<Health_Player>();
        StartCoroutine(ParkourInstructions());
        StartCoroutine(SurvivalTime());
    }

    public IEnumerator SurvivalTime()
    {
        yield return new WaitForSeconds(survivalTime);
        gameObject.GetComponent<Collider>().enabled = false;
        playerMesh.enabled = false;
        parkourSuccess.SetActive(true);
        yield return new WaitForSeconds(6);
        uIController.canvas[3].SetActive(true);
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(levelLoader.LoadBossCutsceneScene());
    }

    public IEnumerator ParkourInstructions()
    {
        instructionsText.SetActive(true);
        yield return new WaitForSeconds(6);
        instructionsText.SetActive(false);
        yield return null;
    }

    public IEnumerator RecoveryTime()
    {
        damageFx.Play();
        //gameoverTrigger = GameObject.Find("Player").GetComponent<Health_Player>();
        player = GameObject.Find("Player");
        hitCounts -= 1;
        hpSlider.value = hitCounts;
        if (hitCounts == 0)
        {
            yield return StartCoroutine(gameoverTrigger.GameOverTransition());
        }
        else
        {
            yield return null;
        }
        gameObject.GetComponent<Collider>().enabled = false;
        playerMesh.enabled = false;
        yield return new WaitForSeconds(0.2f);
        playerMesh.enabled = true;
        yield return new WaitForSeconds(0.2f);
        playerMesh.enabled = false;
        yield return new WaitForSeconds(0.2f);
        playerMesh.enabled = true;
        yield return new WaitForSeconds(0.2f);
        playerMesh.enabled = false;
        yield return new WaitForSeconds(0.2f);
        playerMesh.enabled = true;
        yield return new WaitForSeconds(0.2f);
        playerMesh.enabled = false;
        yield return new WaitForSeconds(0.2f);
        playerMesh.enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(RecoveryTime());
    }

    private void Update()
    {
        
    }
}
