using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeze : MonoBehaviour
{

    public KeyCode freezeControl;
    public GameObject frozenPlayer;
    public GameObject spawnPoint;
    public float spawnPointMinDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(freezeControl))
        {
            Vector2 direction = spawnPoint.transform.position - transform.position;
            float distance = direction.magnitude;
            if(distance >= spawnPointMinDistance)
            {
                Instantiate(frozenPlayer, transform.position, transform.rotation);
<<<<<<< HEAD
                SpawnPoint sp = spawnPoint.GetComponent<SpawnPoint>();
                sp.Respawn(gameObject);
=======
                transform.position = spawnPoint.transform.position;
>>>>>>> parent of 1a6e8ad... Spawn Point
            }
        }
    }
}
