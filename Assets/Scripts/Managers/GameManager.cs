using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Awake,
    Started,
    Finish
}
public class GameManager : BaseSingleton<GameManager>
{
    [SerializeField] private List<GameObject> runners;
    private AnimationManager animationManager;
    public GameState GameState { get; set; }

    void Start()
    {
        animationManager = AnimationManager.GetInstance();
        GameState = GameState.Awake;
    }

    public void StartGame()
    {
        GameState = GameState.Started;
        for (int i = 0; i < runners.Count; i++)
        {
            animationManager.StartGameAnim(runners[i].GetComponentInChildren<Animator>());
        }
    }

}
