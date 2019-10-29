using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    [SerializeField]
    private Vector3Reference LastCheckpointPosition;
    [SerializeField]
    private GameObject playerPrefab;
    private GameObject currentPlayer;

    public void InstantiatePlayer()
    {
        GameObject player = Instantiate(playerPrefab, LastCheckpointPosition.Value, Quaternion.identity);
        currentPlayer = player;
    }

    public void DestroyPlayer()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag(Global.PLAYERTAG))
        {
            DestroyImmediate(item);
        }
    }
}
