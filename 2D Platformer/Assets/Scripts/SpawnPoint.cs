﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        Instantiate(player, transform.position, transform.rotation);
    }

    public void Respawn(GameObject p)
    {
        PlayerController pc = p.GetComponent<PlayerController>();
        pc.DelayMovement();
        Debug.Log(transform.position);
        p.transform.position = transform.position;
    }
}
