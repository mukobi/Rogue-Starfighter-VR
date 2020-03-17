﻿using UnityEngine;
using System.Threading.Tasks;

public class GameSequencer : MonoBehaviour
{
    async void Start()
    {
        await MainGameTask();
    }

    private async Task MainGameTask()
    {
        Debug.Log("Start main game sequence");

        await Task.Delay(4300);

        GameSceneManager.AddSceneIfNotLoaded(1);

        Debug.Log("End main game sequence");
    }
}
