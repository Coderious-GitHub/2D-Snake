using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveHighScore()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscore.bin";

        FileStream stream = new FileStream(path, FileMode.Create);

        HighScore highScore = new HighScore();

        formatter.Serialize(stream, highScore);
        stream.Close();
    }

    public static HighScore LoadHighScore()
    {
        
        string path = Application.persistentDataPath + "/highscore.bin";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighScore highScore = formatter.Deserialize(stream) as HighScore;

            stream.Close();

            return highScore;

        }
        else
        {
            Debug.Log("Save file not found!");
            return null;
        }
    }

}
