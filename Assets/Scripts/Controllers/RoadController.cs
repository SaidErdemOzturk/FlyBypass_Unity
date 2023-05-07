using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour,IRoad
{
    [SerializeField] private GameObject nextRoad;
    private bool isComplate;

    public void MoveNextRoad(BotController bot)
    {
        if (bot.MoveRoad == nextRoad)
        {
            return;
        }
        bot.MoveRoad = nextRoad;
    }
}
