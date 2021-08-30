using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public static GameOverController gameOverController;
    public Texture2D basicCursor;
    public Texture2D selectionCursor;
    public Vector2 hotSpot = Vector2.zero;
    LevelLoader levelLoader;
    public GameObject loadingCanvas;

    private void Awake()
    {
        levelLoader = GameObject.Find("GameOverManager").GetComponent<LevelLoader>();
        SetBasicCursor();
    }
    public void SetSelectionCursor()
    {
        Cursor.SetCursor(selectionCursor, hotSpot, CursorMode.Auto);
        Cursor.visible = true;
    }

    public void SetBasicCursor()
    {
        Cursor.SetCursor(basicCursor, hotSpot, CursorMode.Auto);
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        //loadingCanvas.SetActive(true);
        StartCoroutine(levelLoader.RestartWavePhaseOne());
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quiting");
    }

    public void BackMainMenu()
    {
        loadingCanvas.SetActive(true);
        StartCoroutine(levelLoader.LoadMainMenuScene());
    }
}
