using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader levelLoader;
    AsyncOperation loadingOperation;
    readonly string wavePhaseOne = "Wave_Phase_1";
    readonly string mainMenuScene = "MainMenu";
    readonly string bossScene = "BossScene";
    readonly string bossCutsceneScene = "BossCutscene";
    readonly string gameOverScene = "GameOver";
    readonly string youWinScene = "YouWin";
    readonly string obstacleParkourScene = "Wave_Obstacles";
    public Slider loadingBar;
   

    public IEnumerator YouWinTransition()
    {
        yield return new WaitForSeconds(3);
        //print("pd");
        UIController uicontrol = GameObject.Find("Main Camera").GetComponent<UIController>();
        uicontrol.canvas[3].SetActive(true);
        yield return new WaitForSeconds(1);
        //if(LevelLoader.levelLoader != null)
        yield return StartCoroutine(LoadYouWinScene());
    }
    public IEnumerator LoadYouWinScene()
    {
        loadingOperation = SceneManager.LoadSceneAsync(gameOverScene);
        yield return null;
        while (loadingOperation != null && !loadingOperation.isDone)
        {
            loadingBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
    }

    public IEnumerator LoadObstacleParkourScene()
    {
        loadingOperation = SceneManager.LoadSceneAsync(obstacleParkourScene);
        yield return null;
        while (loadingOperation != null && !loadingOperation.isDone)
        {
            loadingBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
    }
    public IEnumerator LoadGameOverScene()
    {
        //GameOverController gameOver = GameObject.Find("GameOverManager").GetComponent<GameOverController>();
        //gameOver.loadingCanvas.SetActive(true);
        //yield return new WaitForSeconds(3);
        loadingOperation = SceneManager.LoadSceneAsync(youWinScene);
        yield return null;
        while (loadingOperation != null && !loadingOperation.isDone)
        {
            loadingBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
    }

    public IEnumerator LoadWavePhaseOne()
    {

        loadingOperation = SceneManager.LoadSceneAsync(wavePhaseOne);
        yield return null;
        while (loadingOperation != null && !loadingOperation.isDone)
        {
            loadingBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
    }

    public IEnumerator RestartWavePhaseOne()
    {
        GameOverController gameOver = GameObject.Find("GameOverManager").GetComponent<GameOverController>();
        gameOver.loadingCanvas.SetActive(true);
        yield return new WaitForSeconds(3);
        loadingOperation = SceneManager.LoadSceneAsync(wavePhaseOne);
        yield return null;
        while (loadingOperation != null && !loadingOperation.isDone)
        {
            loadingBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
    }

    public IEnumerator LoadMainMenuScene()
    {
        loadingOperation = SceneManager.LoadSceneAsync(mainMenuScene);
        yield return null;
        while (loadingOperation != null && !loadingOperation.isDone)
        {
            loadingBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
    }

    public IEnumerator LoadBossCutsceneScene()
    {
        loadingOperation = SceneManager.LoadSceneAsync(bossCutsceneScene);
        yield return null;
        while (loadingOperation != null && !loadingOperation.isDone)
        {
            loadingBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
    }


    public IEnumerator LoadBossScene()
    {
        CutsceneController cutsceneControl = GameObject.Find("Main Camera").GetComponent<CutsceneController>();
        cutsceneControl.bossCutsceneLoadingCanvas.SetActive(true);
        loadingOperation = SceneManager.LoadSceneAsync(bossScene);
        yield return null;
        while (loadingOperation != null && !loadingOperation.isDone)
        {
            loadingBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
        yield return null;
    }
}
