using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    //quit click
    private void OnClick()
    {
        /*将状态设置false才能退出游戏*/

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    #endif
    }
    void Update()
    {
        
    }
}
