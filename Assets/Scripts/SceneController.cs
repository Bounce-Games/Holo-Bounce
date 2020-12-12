using UnityEngine;

public class SceneController : MonoBehaviour
{
    private SpawnObject mySpawnObj;
    private PauseMenuController pauseMenu;

    public GameObject bird;
    public GameObject bonk;
    public GameObject thisIsTrue;

    public const float birdSize = 0.22f;
    public const float bonkSize = 0.2f;
    public const float thisIsTrueSize = 1f;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;

        mySpawnObj = FindObjectOfType<SpawnObject>();
        pauseMenu = FindObjectOfType<PauseMenuController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !pauseMenu.gamePaused)
        {
            mySpawnObj.InstantiateObject();
        }
        if (Input.GetKeyDown(KeyCode.C) && !pauseMenu.gamePaused)
        {
            mySpawnObj.Clear();
        }
    }

    private void OnApplicationQuit()
    {
        bird.transform.localScale = new Vector3(birdSize, birdSize, 0f);
        bonk.transform.localScale = new Vector3(bonkSize, bonkSize, 0f);
        thisIsTrue.transform.localScale = new Vector3(thisIsTrueSize, thisIsTrueSize, 0f);
    }
}
