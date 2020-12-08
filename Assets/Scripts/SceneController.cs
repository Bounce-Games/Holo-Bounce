using UnityEngine;

public class SceneController : MonoBehaviour
{
    private SpawnObject mySpawnObj;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        mySpawnObj = FindObjectOfType<SpawnObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            mySpawnObj.InstantiateObject();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mySpawnObj.Clear();
        }
    }
}
