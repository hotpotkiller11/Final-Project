using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginUI : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// 登陆界面UI
    /// </summary>
    /// public static int testcount;
    /// addcount = LoginUI.testcount;
    public InputField input_Name;//输入用户名
    public static string sex;
    public static string prefWorkplace;
    public static string prefChar;
    void Start()
    {
        //print(input_Name.txt);
        prefWorkplace = "classroom";
        prefChar = "supervisor";
    }

    // Update is called once per frame
    void Update()
    {
        print(input_Name.text);
    }
    public void Btn_M()
    {
        sex = "male";
    }
    public void Btn_FM()
    {
        sex = "female";
    }
    public void Btn_cafe()
    {
        prefWorkplace = "cafe";
    }
    public void Btn_bedroom()
    {
        prefWorkplace = "bedroom ";
    }
    public void Btn_library()
    {
        prefWorkplace = "library";
    }
    public void Btn_companion()
    {
        prefChar = "companion";
    }
    public void Btn_supervisor()
    {
        prefChar = "supervisor";
    }
    public void Btn_friend()
    {
        prefChar = "friend";
    }
    public void Btn_Login()
    {
        if (input_Name.text == "")
        {
            print("no name");
        #if UNITY_EDITOR
            UnityEditor.EditorUtility.DisplayDialog("pop out", "Please enter name", "confirm", "cancle");
        #endif
        }
        else if (input_Name.text == "") {
            print("no sex");
        #if UNITY_EDITOR
            UnityEditor.EditorUtility.DisplayDialog("pop out", "Please enter your gender", "male", "female");
        #endif
        }
        else if (input_Name.text != "" && sex != "" && prefWorkplace != "")
        {
            print(sex);
            print(prefWorkplace);
            print(prefChar);
            PlayerPrefs.SetString("userName", input_Name.text);
            PlayerPrefs.SetString("prefWorkplace", prefWorkplace);
            PlayerPrefs.SetString("prefCharacter", prefChar);
            Debug.Log(PlayerPrefs.GetString("this is studets profile"+"userName"));
            SceneManager.LoadScene(1);
        }
    }
    
}
