using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class AppDataSystem
{
    //This system will have generic methods to serialize and deserialize almost any kind of data we want,except...
    //MonoBehaviour,GameObjects,prefabs, etc...
    //However, almost everytjing is ok: built in types, your own POCO

    //2 generic method

    //one method to save objects of any type
    //needs to check if a directory exists, and if not... create it automatically!
    //needs to save the file, with the serialized object
    //public static Save<T>...

    //For example using Save will look like this...
    //AppDataSystem.Save(obj,fileName);

    //One methid to Load objects of any Type
    //public static Load<T>
    //Needs to load and return the requested object, if the file exists...
    //needs to load and return to a default object, if the file doesn't exist(perhaps ot should call save if not)

    //for example using  load will look like this..
    //var level=AppDataSystem.Load<LevelGrid>(fileName);

    public static void Save<T>(T obj, string fileName)
    {
        var directoryPath= $"{Application.dataPath}/StreamingAssets/{typeof(T)}";
        var filePath = $"{Application.dataPath}/StreamingAssets/{typeof(T)}/{fileName}";
        if (!Directory.Exists(directoryPath))
        {
            var fileStream = Directory.CreateDirectory(directoryPath);           
        }
        if (!File.Exists(filePath))
        {
            var fileStream = File.Create(filePath);
            fileStream.Close();
        }
        var serializedData = JsonConvert.SerializeObject(obj);
        File.WriteAllText(filePath, serializedData);
    }
    public static T Load<T>(string fileName)
    {
        var fullFilePath = $"{Application.dataPath}/StreamingAssets/{typeof(T)}/{fileName}";
        if (!File.Exists(fullFilePath))
        {
            Debug.Log("The filename is incorrect!");
            return default(T);
        }
        var obj = File.ReadAllText(fullFilePath);
        var data = JsonConvert.DeserializeObject<T>(obj);
        return data;
    }

}
