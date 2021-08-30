using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    //Input of differents waypoint for the camera, the speed of the camera transition and the current view of the camera(where the
    //camera need to be)
    public Transform[] views;
    private float transitionSpeed;
    [HideInInspector]
    public Transform currentView;
    public LevelLoader levelLoader;
    
    //input of Menu Canvas
    public GameObject[] canvas;
    // Start is called before the first frame update
    void Awake()
    {
        currentView = views[0];
        transitionSpeed = 1f;
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void GoToOptions()
    {
        currentView = views [1];
        transitionSpeed = 2f;
        canvas[1].SetActive(false);
        canvas[2].SetActive(true);
    }
    public void GoToCredits()
    {
        currentView = views[2];
        transitionSpeed = 2f;
        canvas[1].SetActive(false);
        canvas[6].SetActive(true);
    }
    public void BackToMainMenu()
    {
        currentView = views[0];
        transitionSpeed = 3f;
        canvas[1].SetActive(true);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        canvas[6].SetActive(false);
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
    }
    public void GoToQuitMenu()
    {
        currentView = views[3];
        canvas[7].SetActive(true);
        canvas[1].SetActive(false);
        transitionSpeed = 3f;
    }
    public void GoToPlayGame()
    {
        currentView = views[4];
        transitionSpeed = 3f;
        canvas[8].SetActive(true);
        canvas[1].SetActive(false);
    }
    public void GoToControls()
    {
        currentView = views[5];
        transitionSpeed = 2f;
        canvas[3].SetActive(true);
        canvas[2].SetActive(false);
    }
    public void GoToGraphicsSettings()
    {
        currentView = views[7];
        transitionSpeed = 3f;
        canvas[2].SetActive(false);
        canvas[5].SetActive(true);
    }
    public void GoToAudioSettings()
    {
        currentView = views[6];
        transitionSpeed = 3f;
        canvas[2].SetActive(false);
        canvas[4].SetActive(true);
    }
    public void BackToOptions()
    {
        currentView = views[1];
        transitionSpeed = 3f;
        canvas[2].SetActive(true);
        canvas[3].SetActive(false);
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
    }
    public void YesPlayGame()
    {
        canvas[0].SetActive(false);
        canvas[9].SetActive(true);
        StartCoroutine(levelLoader.LoadWavePhaseOne());
    }
    public void YesQuitGame()
    {
        Application.Quit();
        Debug.Log("Game Shutting Down");
    }
    private void Update()
    {
        //Camera Transition using Lerp. both position and rotation.
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, Time.deltaTime * transitionSpeed);
        
        //Behavior of escape input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentView == views[5] || currentView == views[6] || currentView == views[7])
            {
                BackToOptions();
            }
            else if (currentView == views[1] || currentView == views[2] || currentView == views[3] || currentView == views[4])
            {
                BackToMainMenu();
            }
            else if (currentView == views[0])
            {
                GoToQuitMenu();
            }
        }
    }
}
