using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeze : MonoBehaviour
{

    public KeyCode freezeControl;
    public KeyCode resetKey;
    public GameObject frozenPlayer;
    private SpawnPoint spawnPoint;
    public float spawnPointMinDistance;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnPoint = GameObject.Find("Spawn Point").GetComponent<SpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(freezeControl) && gameManager.getFreezesLeft() > 0)
        {
            Vector2 direction = spawnPoint.transform.position - transform.position;
            float distance = direction.magnitude;
            if(distance >= spawnPointMinDistance)
            {
                Instantiate(frozenPlayer, transform.position, transform.rotation);
                SpawnPoint sp = spawnPoint.GetComponent<SpawnPoint>();
                sp.Respawn(gameObject);
                gameManager.alterFreezesLeft(1);
            }
        }

        if(Input.GetKeyDown(resetKey))
        {
            SpawnPoint sp = spawnPoint.GetComponent<SpawnPoint>();
            sp.Respawn(gameObject);
            gameManager.RemoveFrozen();
            gameManager.resetFreezes();
        }
    }
}
