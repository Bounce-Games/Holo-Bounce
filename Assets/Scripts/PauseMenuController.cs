using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;

    [SerializeField] private GameObject bird = null;
    [SerializeField] private GameObject bonk = null;
    [SerializeField] private GameObject thisIsTrue = null;

    private bool gamePaused;
    private SpawnObject mySpawnObj;

    void Start()
    {
        bird.transform.localScale = new Vector3(0.21f, 0.21f, 0f);
        bonk.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        thisIsTrue.transform.localScale = new Vector3(1f, 1f, 0f);

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
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseMenu.transform.Find("ResumeButton").transform.localScale = new Vector3(1f, 1f, 1f);
        gamePaused = false;
    }

    public void Pause()
    {
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
                mySpawnObj.objToSpawn = bird;
                break;
            case 2:
                mySpawnObj.objToSpawn = bonk;
                break;
            case 3:
                mySpawnObj.objToSpawn = thisIsTrue;
                break;
        }
    }
}
