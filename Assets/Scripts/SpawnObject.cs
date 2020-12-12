using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;
    public bool spawnRandom;

    [SerializeField] private Scrollbar sizeScrollbar;
    [SerializeField] private Toggle toggleSpawnRandom;

    private ObjectController[] objs;

    private float sizeToSpawn;
    private const float birdSize = 0.22f;
    private const float bonkSize = 0.2f;
    private const float thisIsTrueSize = 1f;

    public void Start()
    {
        spawnRandom = true;
        objs = Resources.LoadAll<ObjectController>("Prefabs/HoloPrefabs"); //INSERT PATH OF OBJECT PREFABS
    }

    public void InstantiateObject()
    {
        if (spawnRandom)
        {
            objToSpawn = objs[Random.Range(0, objs.Length)].gameObject;
        }

        if (toggleSpawnRandom.isOn)
        {
            switch (objToSpawn.name)
            {
                case "Bird":
                    sizeToSpawn = birdSize * Random.Range(0.5f, 1.5f);
                    break;
                case "Bonk":
                    sizeToSpawn = bonkSize * Random.Range(0.5f, 1.5f);
                    break;
                case "This is True":
                    sizeToSpawn = thisIsTrueSize * Random.Range(0.5f, 1.5f);
                    break;
            }
        }
        else
        {
            switch (objToSpawn.name)
            {
                case "Bird":
                    sizeToSpawn = birdSize * (sizeScrollbar.value + 0.5f);
                    break;
                case "Bonk":
                    sizeToSpawn = bonkSize * (sizeScrollbar.value + 0.5f);
                    break;
                case "This is True":
                    sizeToSpawn = thisIsTrueSize * (sizeScrollbar.value + 0.5f);
                    break;
            }
        }

        objToSpawn.transform.localScale = new Vector3(sizeToSpawn, sizeToSpawn, 0f);

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
