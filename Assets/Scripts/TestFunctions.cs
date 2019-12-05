using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFunctions : MonoBehaviour
{
    public GameObject testObj;
    public LevelManager levelManager;
    public int testObjX;
    public int testObjY;

    private void Awake()
    {
        levelManager.InstantiateOnGrid(testObjX, testObjY, testObj);
    }
}
