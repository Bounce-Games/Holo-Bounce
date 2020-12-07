using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;
    public bool spawnRandom;

    private ObjectController[] objs;

    public void Start()
    {
        spawnRandom = true;
        objs = Resources.LoadAll<ObjectController>("Prefabs/FumoPrefabs"); //INSERT PATH OF OBJECT PREFABS
    }
    public void InstantiateObject()
    {
        if (spawnRandom)
        {
            objToSpawn = objs[Random.Range(0, objs.Length)].gameObject;
        }

        Instantiate(objToSpawn, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    public void Clear()
    {
        ObjectController[] objs = FindObjectsOfType<ObjectController>();

        foreach (ObjectController obj in objs)
        {
            StartCoroutine(obj.DisappearObjectCoroutine());
        }
    }
}
