using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeze : MonoBehaviour
{

    public KeyCode freezeControl;
    public GameObject frozenPlayer;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(freezeControl))
        {
            Instantiate(frozenPlayer, transform.position, transform.rotation);
            transform.position = spawnPoint.transform.position;
        }
    }
}
