using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    public Button buttonResume;
    public Button buttonPause;
    public Button buttonMenu;
    void Start()
    {
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
        buttonMenu.onClick.AddListener(()=>GameManager.instance.ChangeScene(0));
    }

    // Update is called once per frame
    void HandleButtonClick()
    {
        if (GameManager.instance.isPaused == true)
        {
            GameManager.instance.Resume();
            buttonPause.gameObject.SetActive(true);
            buttonResume.gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.Pause();
            buttonPause.gameObject.SetActive(false);
            buttonResume.gameObject.SetActive(true);
        }
    }
}
