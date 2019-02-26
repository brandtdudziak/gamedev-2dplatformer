using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject player;
    private GameManager gameManager;
    private UIPanel ui;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, transform.rotation);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ui = GameObject.FindObjectOfType<UIPanel>();
        ui.UpdateLives(gameManager.getFreezesLeft());
    }

    public void Respawn(GameObject p)
    {
        PlayerController pc = p.GetComponent<PlayerController>();
        pc.DelayMovement();
        p.transform.position = transform.position;
        ui.UpdateLives(gameManager.getFreezesLeft());
    }
}
