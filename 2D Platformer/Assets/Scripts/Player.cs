using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject spawnPoint;
    private GameManager gameManager;
    private float freezes;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        freezes = gameManager.getFreezesLeft();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Fall"))
        {
            SpawnPoint sp = spawnPoint.GetComponent<SpawnPoint>();
            sp.Respawn(gameObject);
            gameManager.RemoveFrozen();
            gameManager.resetFreezes(freezes);
        }
        if(collider.gameObject.CompareTag("Goal"))
        {
            gameManager.NextScene();
        }
        if(collider.gameObject.CompareTag("Spike"))
        {
            SpawnPoint sp = spawnPoint.GetComponent<SpawnPoint>();
            sp.Respawn(gameObject);
            gameManager.RemoveFrozen();
            gameManager.resetFreezes(freezes);
        }
    }
}
