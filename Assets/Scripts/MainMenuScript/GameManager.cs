using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public KeyCode MoveForward { get; set; }
    public KeyCode MoveBackward { get; set; }
    public KeyCode MoveLeft { get; set; }
    public KeyCode MoveRight { get; set; }
    public KeyCode Fire { get; set; }

    public KeyCode Jump { get; set; }
    
    public TMP_Dropdown graphicQualityDropdown;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public Texture2D basicCursor;
    public Texture2D selectionCursor;
    public Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        //Destroy or keep the gameManager when the scene change
        if (gameManager != this && gameManager != null)
        {
            Destroy(gameManager.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        gameManager = this;
        
        //Interrogate PlayerPrefs to set the controls
        MoveForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveForwardKey", "Z"));
        MoveBackward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveBackwardKey", "S"));
        MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeftKey", "Q"));
        MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRightKey", "D"));
        Fire = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("FireKey", "Space"));
        Jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", "LeftShift"));

        //set the quality settings with PlayerPrefs
        graphicQualityDropdown.value = PlayerPrefs.GetInt("qualityLevel");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityLevel"));
        if (PlayerPrefs.GetFloat("fullscreenValue") == 1)
        {
            Screen.fullScreen = true;
        }
        else if (PlayerPrefs.GetFloat("fullscreenValue") == 0)
        {
            Screen.fullScreen = false;
        } 
        
        //Set the resolutions
        List<string> resolutionOptions = new List<string>();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        SetBasicCursor();
    }


    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityLevel", qualityIndex);
    }

    public void SetFullscreen(Toggle fullscreenToggle)
    {
        if (fullscreenToggle.isOn == true)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetFloat("fullscreenValue", 1);
        }
        else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetFloat("fullscreenValue", 0);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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
    

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
