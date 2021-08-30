using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public int enemiesLeft;
    public int actualWave;
    private bool waveisstarting;
    LevelLoader levelLoader;
    Collider playerCollider;
    UIController uiCOntroller;
    public GameObject waveSuccess;
    public float numberOFWave;

    public List<Vector3> gridPositions = new List<Vector3>();

    public List<Vector3> gridTemplate = new List<Vector3>();
    private Vector3 lastRandomPos;

    


    private void Start()
    {
        uiCOntroller = GameObject.Find("Main Camera").GetComponent<UIController>();
        playerCollider = GameObject.Find("Player").GetComponent<Collider>();
        levelLoader = GameObject.Find("GameManager").GetComponent<LevelLoader>();
        actualWave = 0;
        waveisstarting = false;
        gridPositions.AddRange(new List<Vector3>(gridTemplate));
        StartCoroutine(WaitForFirstWave());


    }

    IEnumerator WaitForFirstWave()
    {
        yield return new WaitForSeconds(5);
        GenerateWaveEnemyUnits();
    }

    IEnumerator SceneTransition()
    {
        playerCollider.enabled = false;
        waveSuccess.SetActive(true);
        yield return new WaitForSeconds(3);
        uiCOntroller.canvas[3].SetActive(true);
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(levelLoader.LoadObstacleParkourScene());
    }

    private void Update()
    {
        if (actualWave > numberOFWave)
        {
            StartCoroutine(SceneTransition());
        }

        if (enemiesLeft< 1 && waveisstarting)
        {
            Debug.Log("wave " + actualWave + " = " + enemiesLeft);
            actualWave += 1;
            //Clear the list and add the Template
            gridPositions.Clear();
            gridPositions.AddRange(new List<Vector3>(gridTemplate));

            GenerateWaveEnemyUnits();
            
        }


    }

    private void GenerateWaveEnemyUnits()
    {
        for (int i = 0; i < waves[actualWave].enemyUnits.Length; i++)
            GenerateEnemyType(i);
    }

    Vector3 RandomPosition()
    {
        
        int randomIndex = Random.Range(0, gridPositions.Count);        
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;

    }
    private void GenerateEnemyType(int index)
    {

        enemiesLeft += waves[actualWave].enemyUnits[index].count;

        for (int i = 0; i < waves[actualWave].enemyUnits[index].count; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject EnemiesChoice = (waves[actualWave].enemyUnits[index].prefab);

            Instantiate(EnemiesChoice, randomPosition , Quaternion.Euler(0f, 180f, 0f));
            lastRandomPos = randomPosition;

        }

        waveisstarting = true;

        
    }
}

[System.Serializable]
public class Wave 
{
    public string waveName;
    public WaveEnemyDetails[] enemyUnits;
    
}

[System.Serializable] 
public class WaveEnemyDetails
{
    public GameObject prefab;
    public int count;
}


