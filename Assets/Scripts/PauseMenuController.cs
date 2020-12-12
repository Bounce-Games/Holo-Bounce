﻿using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;

    public bool gamePaused;
    private SceneController sceneController;
    private SpawnObject mySpawnObj;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        mySpawnObj = FindObjectOfType<SpawnObject>();
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (gamePaused)
            {
                case true:
                    Resume();
                    break;
                case false:
                    Pause();
                    break;
            }
        }
    }

    public void Resume()
    {
        OnDemandRendering.renderFrameInterval = 1;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseMenu.transform.Find("ResumeButton").transform.localScale = new Vector3(1f, 1f, 1f);
        gamePaused = false;
    }

    public void Pause()
    {
        OnDemandRendering.renderFrameInterval = 2;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gamePaused = true;
    }

    public void SelectObj(int selection)
    {
        if (selection != 0)
        {
            mySpawnObj.spawnRandom = false;
        }

        switch (selection)
        {
            case 0:
                mySpawnObj.spawnRandom = true;
                break;
            case 1:
                mySpawnObj.objToSpawn = sceneController.bird;
                break;
            case 2:
                mySpawnObj.objToSpawn = sceneController.bonk;
                break;
            case 3:
                mySpawnObj.objToSpawn = sceneController.thisIsTrue;
                break;
        }
    }

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/Bounce-Games/Holo-Bounce");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/walfieee");
    }
}
