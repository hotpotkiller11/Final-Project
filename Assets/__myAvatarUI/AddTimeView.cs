using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DreamerTool.UI;
using LitJson;
using System.IO;
using System.Text;

public class AddTimeView : View
{
    public InputField desText;
    public Text timeText;
    public DayTime dayTime = new DayTime();
    private void Awake()
    {
        UpdateText();
    }
    void UpdateText()
    {
        timeText.text = dayTime.GetString();
    }
    public void MinusTenMinute()
    {
        dayTime.AddMinute(-10);
        UpdateText();
    }
    public void MinusMinute()
    {
        dayTime.AddMinute(-1);
        UpdateText();
    }
    public void MinusHour()
    {
        dayTime.AddHour(-1);
        UpdateText();
    }
    public void AddTenMinute()
    {
        dayTime.AddMinute(10);
        UpdateText();
    }
    public void  AddMinute()
    {
        dayTime.AddMinute(1);
        UpdateText();
    }
    public void AddHour()
    {
        dayTime.AddHour(1);
        UpdateText();
    }
    public void AddClock()
    {
        DataModel.Model.AddRemainTime(new ClockModel(dayTime, desText.text));
        gameObject.SetActive(false);
        EventHandler.OnAddClock?.Invoke();
        CreateJson();
    }
    public void CreateJson()
    {
        string path = Application.streamingAssetsPath + "\\StudProf.txt";
        FileInfo t = new FileInfo(path);

        StreamWriter sw = t.CreateText();

        StringBuilder sb = new StringBuilder();
        JsonWriter writer = new JsonWriter(sb);
        //相当于写下了'{'
        writer.WriteObjectStart();
        //相当于写下了"Name":
        writer.WritePropertyName("UserName");
        //相当于写下了"name of user"
        writer.Write(PlayerPrefs.GetString("userName", "Empty"));

        writer.WritePropertyName("prefWorkplace");
        //writer.Write(PlayerPrefs.GetString("prefWorkplace"));
        writer.Write(PlayerPrefs.GetString("prefWorkplace", "Empty"));

        writer.WritePropertyName("prefCharacter");
        //writer.Write(PlayerPrefs.GetString("prefCharacter"));
        writer.Write(PlayerPrefs.GetString("prefCharacter", "Empty"));

        writer.WritePropertyName("learningGoal");
        //writer.Write(desText.text);
        writer.Write(desText.text);

        writer.WriteObjectEnd();
        //相当于写下了']'
        sw.WriteLine(sb.ToString());
        sw.Close();
        Debug.Log("this is json-----------");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
