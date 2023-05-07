using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawnerManager : BaseSingleton<BotSpawnerManager>
{
    [SerializeField] private GameObject cube;
    [SerializeField] private List<GameObject> roads;
    [SerializeField] private List<GameObject> bots;
    private GameObject tempObject;
    private JSONReader reader;



    private void Start()
    {
        reader = JSONReader.GetInstance();
        for (int i = 0; i < transform.childCount; i++)
        {
            tempObject = bots[i];
            tempObject.transform.position = transform.GetChild(i).position;
            tempObject.GetComponent<BotController>().MoveRoad = roads[0];
            tempObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = reader.GetRandomName();
        }
    }
}
