using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.UI;
public class FunctionMenuView : View
{ 
    public void Exit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    
}
