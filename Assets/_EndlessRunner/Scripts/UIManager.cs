using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;

#endif
        Application.Quit();
    }

   
    
}
