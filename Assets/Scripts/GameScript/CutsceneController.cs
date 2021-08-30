using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    LevelLoader bossSceneLoader;
    public Transform[] bossCutsceneViews;
    Transform currentView;
    float transitionSpeed;
    public GameObject bossCutsceneLoadingCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        bossSceneLoader = GetComponent<LevelLoader>();
        currentView = bossCutsceneViews[0];
        transitionSpeed = 1f;
        if (GameObject.Find("BossCutsceneElements").activeInHierarchy == true)
        {
            StartCoroutine(BossCutsceneTransition());
        }
    }

    IEnumerator BossCutsceneTransition()
    {
        yield return new WaitForSeconds(3);
        currentView = bossCutsceneViews[1];
        transitionSpeed = 2f;
        yield return new WaitForSeconds(3);
        currentView = bossCutsceneViews[2];
        transitionSpeed = 2f;
        yield return new WaitForSeconds(3);
        currentView = bossCutsceneViews[3];
        transitionSpeed = 2f;
        yield return new WaitForSeconds(3);
        currentView = bossCutsceneViews[4];
        transitionSpeed = 2f;
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(3);
        
        yield return bossSceneLoader.LoadBossScene();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
    }
}
