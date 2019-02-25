using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string nextScene;
    public float numOfFreezes;

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public float getFreezesLeft()
    {
        return numOfFreezes;
    }

    public void alterFreezesLeft(float amountDecreased)
    {
        numOfFreezes -= amountDecreased;
    }
    public void resetFreezes(float freezes)
    {
        numOfFreezes = freezes;
    }

    public void RemoveFrozen()
    {
        foreach (GameObject frozen in GameObject.FindGameObjectsWithTag("Frozen"))
        {
            Destroy(frozen);
        }
    }
}
