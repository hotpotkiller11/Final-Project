using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Scene : MonoBehaviour
{
    /// <summary>
    /// ³¡¾°Ìø×ª °´Å¥
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Btn_Goto(int i)
    {
        SceneManager.LoadScene(i);
    }
}
