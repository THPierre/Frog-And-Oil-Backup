using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manage_Debug : MonoBehaviour
{
    public string scenename;

    // Update is called once per frame
    public void ChangeScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
