using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;
using System;
using UnityEditor.SceneManagement;
public class VariableManager : MonoBehaviour
{

    InMemoryVariableStorage variableStorage;

    [SerializeField] TMP_Text pollution;
    [SerializeField] Single pollutionCount;

    // Start is called before the first frame update
    void Start()
    {
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        variableStorage.TryGetValue<Single>("$adjust_pollution", out pollutionCount);
        pollution.text = "pollution: " + pollutionCount;
    }
}
