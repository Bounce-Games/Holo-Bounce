using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;
    public bool spawnRandom;

    [SerializeField] private Scrollbar sizeScrollbar;

    private ObjectController[] objs;

    private float sizeToSpawn;
    private float birdSize;
    private float bonkSize;
    private float thisIsTrueSize;

    public void Start()
    {
        spawnRandom = true;
        objs = Resources.LoadAll<ObjectController>("Prefabs/HoloPrefabs"); //INSERT PATH OF OBJECT PREFABS

        foreach (ObjectController obj in objs)
        {
            switch (obj.name)
            {
                case "Bird":
                    birdSize = obj.gameObject.transform.localScale.x;
                    break;
                case "Bonk":
                    bonkSize = obj.gameObject.transform.localScale.x;
                    break;
                case "This is True":
                    thisIsTrueSize = obj.gameObject.transform.localScale.x;
                    break;
            }
        }
    }

    public void InstantiateObject()
    {
        if (spawnRandom)
        {
            objToSpawn = objs[Random.Range(0, objs.Length)].gameObject;
        }

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
