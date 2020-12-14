using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System.Collections.Generic;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private TMP_Dropdown dropdown = null;

    public bool gamePaused;
    private SpawnObject mySpawnObj;

    void Start()
    {
        mySpawnObj = FindObjectOfType<SpawnObject>();

        List<string> options = new List<string>();
        options.Add("Random");
        foreach(GameObject obj in SceneController.objs)
        {
            options.Add(obj.name);
        }
        AddDropdownOptions(dropdown, options);

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

    public void AddDropdownOptions(TMP_Dropdown dropdown, List<string> options)
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    public void SelectObj(int selection)
    {
        mySpawnObj.spawnRandom = selection == 0;
        if (selection == 0) return;
        mySpawnObj.objToSpawn = SceneController.objs[selection - 1];
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
