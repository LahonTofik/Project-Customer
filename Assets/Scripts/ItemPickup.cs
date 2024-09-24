using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Pickupmechanic : MonoBehaviour
{
    [SerializeField] GameObject OriginalPos; // Original position the specific item was laying at
    [SerializeField] GameObject ViewPos; // position of the item while holding it (Raycast)

    [SerializeField] CameraSwitch cameraSwitch;
    void Start()
    {
        cameraSwitch = FindObjectOfType<CameraSwitch>();
    }

    void Update()
    {
        
    }
}
