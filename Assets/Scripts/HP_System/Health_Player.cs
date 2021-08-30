using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Player : MonoBehaviour
{ 
    public float healthPoints;
    public SkinnedMeshRenderer playerMesh;
    UIController uiController;
    LevelLoader levelLoader;
    public AudioSource damageFx;
    Collider playerColli;
    public AudioSource deathFx;
    public GameObject explosionFx;
    public Slider hpSLider;

    private void Start()
    {
        hpSLider = GameObject.Find("hpSlider").GetComponent<Slider>();
        playerColli = GameObject.Find("Player").GetComponent<Collider>();
        uiController = GameObject.Find("Main Camera").GetComponent<UIController>();
        levelLoader = GameObject.Find("GameManager").GetComponent<LevelLoader>();
    }
    
    public IEnumerator RecoveryTime()
    {
        damageFx.Play();
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
    
    public void Damage(float damagesToApply)
    {
        healthPoints -= damagesToApply;
        hpSLider.value = healthPoints;
        Debug.Log("Hit");
        if (healthPoints >= 1)
        {
            StartCoroutine(RecoveryTime());
        }
        
        if (healthPoints < 1)
        {
            StartCoroutine(GameOverTransition());
        }
    }

    public IEnumerator GameOverTransition()
    {
        deathFx.Play();
        Instantiate(explosionFx, transform.position + new Vector3(0,4,0), explosionFx.transform.rotation) ;
        yield return new WaitForSeconds(0.5f);
        playerMesh.enabled = false;
        playerColli.enabled = false;
        yield return new WaitForSeconds(3);
        uiController.canvas[3].SetActive(true);
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(levelLoader.LoadGameOverScene());
    }

    
}
