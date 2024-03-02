using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenuUI : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit");
        #if !UNITY_EDITOR
                Debug.Log("Quit");
                Application.Quit();
        #else
                UnityEditor.EditorApplication.ExitPlaymode();
        #endif
    }
}
