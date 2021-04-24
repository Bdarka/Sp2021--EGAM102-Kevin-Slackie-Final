using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform SpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = SpawnPoint.transform.position;
    }
}
