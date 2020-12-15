using UnityEngine;

public class SceneController : MonoBehaviour
{
    private SpawnObject mySpawnObj;

    //Array of objects to bounce
    public static GameObject[] objs;
    //Scales of objects
    public static float[] objSizes;
    public static bool gamePaused;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;

        mySpawnObj = FindObjectOfType<SpawnObject>();

        objs = Resources.LoadAll<GameObject>("Prefabs/HoloPrefabs"); //INSERT PATH OF OBJECT PREFABS;
        objSizes = new float[objs.Length];
        objSizes[0] = 0.22f; //bird
        objSizes[1] = 0.2f; //bonk
        objSizes[2] = 0.2f; //books
        objSizes[3] = 0.2f; //confession
        objSizes[4] = 0.2f; //consume noodles
        objSizes[5] = 0.18f; //controller smash
        objSizes[6] = 0.17f; //driving
        objSizes[7] = 0.2f; //fitness shark
        objSizes[8] = 0.25f; //gold mining
        objSizes[9] = 0.19f; //holobirds
        objSizes[10] = 0.2f; //interrupted by bird
        objSizes[11] = 0.22f; //karaoke
        objSizes[12] = 0.17f; //minecraft rap
        objSizes[13] = 0.18f; //polkatsu
        objSizes[14] = 0.22f; //reading
        objSizes[15] = 0.2f; //rolling
        objSizes[16] = 0.18f; //spicy noodles
        objSizes[17] = 1f; //this is true
        objSizes[18] = 0.18f; //ukulele practice
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !gamePaused)
        {
            mySpawnObj.InstantiateObject();
        }
        if (Input.GetKeyDown(KeyCode.C) && !gamePaused)
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
