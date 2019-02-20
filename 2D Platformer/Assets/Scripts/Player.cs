using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject spawnPoint;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Fall"))
        {
            SpawnPoint sp = spawnPoint.GetComponent<SpawnPoint>();
            sp.Respawn(gameObject);
        }
        if(collider.gameObject.CompareTag("Goal"))
        {
            GameManager gm = gameManager.GetComponent<GameManager>();
            gm.NextScene();
        }
    }
}
