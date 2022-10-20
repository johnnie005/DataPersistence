using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
  
  
    public static Manager Instance;
    private int score;
    public string player_name;

    void Awake() { 
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this; 
            LoadName();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
      
    }//singleton

    public void scene() { SceneManager.LoadScene(1); }
   public string GetPlayerName(){ return player_name;}
    public void HighScore(int i){score = i;}
    public int GetScore() { return score; }

    [System.Serializable]
    class SaveData { public string name;}
    public void SaveName(string name)
    {
        SaveData data = new SaveData();
        data.name = name;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            player_name = data.name;
           
        }

    }
 



}
