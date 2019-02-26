using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string nextScene;
    public int numOfFreezes;

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public int getFreezesLeft()
    {
        return numOfFreezes;
    }

    public void alterFreezesLeft(int amountDecreased)
    {
        numOfFreezes -= amountDecreased;
    }

    public void resetFreezes(int freezes)
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
