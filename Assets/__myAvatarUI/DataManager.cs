using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class DataManager 
{
    public const string dataKey = "data";

    public static DataModel GetData()//方法 返回datamodel
    {
        if(PlayerPrefs.HasKey(dataKey))
        {
            return JsonMapper.ToObject<DataModel>(PlayerPrefs.GetString("data"));//data字段
        }
        return null;
    }
    public static void ClearData()
    {
        PlayerPrefs.DeleteKey(dataKey);
    }
    public static void SaveData()
    {
       PlayerPrefs.SetString(dataKey, JsonMapper.ToJson(DataModel.Model));
    }
    
}
