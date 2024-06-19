using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    #region LevelManagement
    
    LevelData levelData;
    public int levelCurrent;

    private void SaveLevel()
    {
        levelData = new LevelData();
        levelData.level = levelCurrent;
        string json = JsonUtility.ToJson(levelData,true);
        File.WriteAllText(Application.dataPath + "/Level.json",json);
    }
    private void LoadLevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/Level.json");
        LevelData levelData = JsonUtility.FromJson<LevelData>(json);
        levelCurrent = levelData.level;
    }

    public void CheckSaveFile()
    {
        if (File.Exists(Application.dataPath + "/Level.json"))
        {
            LoadLevel();
        }
        else
        {
            SaveLevel();
        }

    }

    public void ChangeLevel(int newLevelUnlocked)
    {
        levelCurrent = newLevelUnlocked;
        SaveLevel();
    }


        
    #endregion

    #region Pause&Scene
        public bool isPaused;
        public void Pause()
        {
            Time.timeScale = 0f;
            isPaused = true;
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            isPaused = false;
        }

        public void ChangeScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

    #endregion
  
}
