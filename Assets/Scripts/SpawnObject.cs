﻿using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;
    public bool spawnRandom;

    [SerializeField] private Scrollbar sizeScrollbar;
    [SerializeField] private Toggle toggleSpawnRandom;

    private ObjectController[] objs;

    private float sizeToSpawn;

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
                    sizeToSpawn = SceneController.birdSize * Random.Range(0.5f, 1.5f);
                    break;
                case "Bonk":
                    sizeToSpawn = SceneController.bonkSize * Random.Range(0.5f, 1.5f);
                    break;
                case "This is True":
                    sizeToSpawn = SceneController.thisIsTrueSize * Random.Range(0.5f, 1.5f);
                    break;
            }
        }
        else
        {
            switch (objToSpawn.name)
            {
                case "Bird":
                    sizeToSpawn = SceneController.birdSize * (sizeScrollbar.value + 0.5f);
                    break;
                case "Bonk":
                    sizeToSpawn = SceneController.bonkSize * (sizeScrollbar.value + 0.5f);
                    break;
                case "This is True":
                    sizeToSpawn = SceneController.thisIsTrueSize * (sizeScrollbar.value + 0.5f);
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