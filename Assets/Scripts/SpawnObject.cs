using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;
    public bool spawnRandom;

    [SerializeField] private Scrollbar sizeScrollbar;
    [SerializeField] private Toggle randomSizeToggle;

    private float sizeToSpawn;
    private float sizeMultiplier;

    public void Start()
    {
        spawnRandom = true;
        foreach (GameObject obj in SceneController.objs)
        {
            Debug.Log(obj.name);
        }
    }

    public void InstantiateObject()
    {
        if (spawnRandom)
        {
            objToSpawn = SceneController.objs[Random.Range(0, SceneController.objs.Length)];
        }

        switch (randomSizeToggle.isOn)
        {
            case true:
                sizeMultiplier = Random.Range(0.5f, 1.5f);
                break;
            case false:
                sizeMultiplier = sizeScrollbar.value + 0.5f;
                break;
        }

        for (int i = 0; i < SceneController.objs.Length; i++)
        {
            if (objToSpawn.name == SceneController.objs[i].name)
            {
                sizeToSpawn = SceneController.objSizes[i] * sizeMultiplier;
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
