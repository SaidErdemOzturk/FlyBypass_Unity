using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPlayerManager : BaseSingleton<BotPlayerManager>
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject cube;
    [SerializeField] private List<GameObject> roads;
    private GameObject tempObject;



    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            //tempObject=Instantiate(playerPrefab);
            //tempObject.AddComponent<PlayerController>();
            //Instantiate(cube);
        }
    }
}
