using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    [SerializeField] string previousLevelName;
    [SerializeField] string currentLevel;

    Monster[] _monsters;


    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }
    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
        {
            GoToNextLevel(_nextLevelName);
        }
        if (Input.GetKey("right"))
        {
            GoToNextLevel(_nextLevelName);
        }
        if (Input.GetKey("left"))
        {
            GoToNextLevel(previousLevelName);
        }
        if (Input.GetKey("space")) {
            GoToNextLevel(currentLevel);

        }
    }
     void GoToNextLevel([SerializeField] string level)
    {
        Debug.Log(level);
        SceneManager.LoadScene(level);
    }

    bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
