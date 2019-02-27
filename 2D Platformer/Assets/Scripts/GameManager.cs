using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string nextScene;
    public int maxFreezes;
    private int usedFreezes;
    private UIPanel ui;

    private void Start() {
        usedFreezes = 0;
        ui = GameObject.Find("UI").GetComponent<UIPanel>();
        ui.UpdateLives(getFreezesLeft());
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public int getFreezesLeft()
    {
        return maxFreezes - usedFreezes;
    }

    public void alterFreezesLeft(int amountIncreased)
    {
        usedFreezes += amountIncreased;
        ui.UpdateLives(getFreezesLeft());
    }

    public void resetFreezes()
    {
        usedFreezes = 0;
        ui.UpdateLives(getFreezesLeft());
    }

    public void RemoveFrozen()
    {
        foreach (GameObject frozen in GameObject.FindGameObjectsWithTag("Frozen"))
        {
            Destroy(frozen);
        }
    }
}
