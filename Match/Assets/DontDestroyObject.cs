using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour {

    private static bool created = false;
    public GameObject dot;
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(dot);
            created = true;
            Debug.Log("Awake: " + dot);
        }
    }

}
