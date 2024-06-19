using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    private int myLevel;
    public Button[] buttons;
    void Start()
    {
        GameManager.instance.CheckSaveFile();
        myLevel = GameManager.instance.levelCurrent;
        DisableLockedLevel();
        AddChangeSceneListener();
    }

    void DisableLockedLevel()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i > myLevel) buttons[i].interactable = false;
        }
    }

    void AddChangeSceneListener()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int sceneIndex = i + 1;
            buttons[i].onClick.AddListener(()=> GameManager.instance.ChangeScene(sceneIndex));
        }
    }


    
}
