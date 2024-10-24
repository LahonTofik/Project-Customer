using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class VariableAquisation : MonoBehaviour
{
    InMemoryVariableStorage storage;
    
    void Start()
    {
        storage = FindObjectOfType<InMemoryVariableStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        /*storage.TryGetValue<Single>("$adjust_pollution", out Single variable);
        storage.SetValue("$adjust_pollution", 5);
        Debug.Log(variable);*/
    }
}
