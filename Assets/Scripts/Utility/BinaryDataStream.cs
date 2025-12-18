using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinaryDataStream : MonoBehaviour
{
    public static void Save<T>(T serializedObject, string fileName)
    {
        string dirpath = Path.Combine(Application.persistentDataPath, "saves");
        Directory.CreateDirectory(dirpath);

        string filePath = Path.Combine(dirpath, fileName + ".dat");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        try
        {
            formatter.Serialize(fileStream, serializedObject);
        }
        catch (SerializationException e)
        {
            Debug.Log("Save Filed. Error: " + e.Message);
        }
        finally
        {
            fileStream.Close();
        }
    }

    public static bool Exist(string fileName)
    {
        string filePath = Path.Combine(
        Application.persistentDataPath,
        "saves",
        fileName + ".dat"
        );

        return File.Exists(filePath);
    }

    public static T Read<T>(string fileName)
    {
        string filePath = Path.Combine(
        Application.persistentDataPath,
        "saves",
        fileName + ".dat"
        );

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        T returnType = default;

        try
        {
            returnType = (T)formatter.Deserialize(fileStream);
        }
        catch (SerializationException e)
        {
            Debug.Log("Read Failed. Error: " + e.Message);
        }
        finally
        {
            fileStream.Close();
        }

        return returnType;
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
