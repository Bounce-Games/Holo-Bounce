using UnityEngine;

public class SceneController : MonoBehaviour
{
    private SpawnObject mySpawnObj;
    private PauseMenuController pauseMenu;

    //Array of objects to bounce
    public static GameObject[] objs;
    //Scales of objects
    public static float[] objSizes;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;

        mySpawnObj = FindObjectOfType<SpawnObject>();
        pauseMenu = FindObjectOfType<PauseMenuController>();

        objs = Resources.LoadAll<GameObject>("Prefabs/HoloPrefabs"); //INSERT PATH OF OBJECT PREFABS;
        objSizes = new float[objs.Length];
        objSizes[0] = 0.22f; //birdSize
        objSizes[1] = 0.2f; //bonkSize
        objSizes[2] = 0.22f; //booksSize
        objSizes[3] = 1f; //thisIsTrueSize
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
        //Resets prefab scales
        for (int i = 0; i < objSizes.Length; i++)
        {
            objs[i].transform.localScale = new Vector3(objSizes[i], objSizes[i], 0f);
        }
    }
}
