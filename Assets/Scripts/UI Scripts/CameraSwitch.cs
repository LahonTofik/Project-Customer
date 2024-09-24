using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Yarn.Unity;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject playerViewPos;
    [SerializeField] GameObject computerZoomPos;
    [SerializeField] GameObject screenViewPos;


    float testTime = 0f;

    bool camSwitch = false;
    bool cameraZoomedIn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            testTime = 0f;
            camSwitch = true;
            if (cameraZoomedIn)
            {
                gameObject.transform.position = computerZoomPos.transform.position; // position
                gameObject.transform.rotation = computerZoomPos.transform.rotation; // rotation
            }
        }
        if (camSwitch)
        {
            testTime += Time.deltaTime;
            if (!cameraZoomedIn)
            {
                gameObject.transform.rotation = Quaternion.Lerp(playerViewPos.transform.rotation, computerZoomPos.transform.rotation, testTime); // rotation
                gameObject.transform.position = Vector3.Lerp(playerViewPos.transform.position, computerZoomPos.transform.position, testTime); // position
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Lerp(computerZoomPos.transform.rotation, playerViewPos.transform.rotation, testTime); // rotation
                gameObject.transform.position = Vector3.Lerp(computerZoomPos.transform.position, playerViewPos.transform.position, testTime); // position
            }
        }
        if (testTime > 1f)
        {
            cameraZoomedIn = !cameraZoomedIn;
            camSwitch = false;
            testTime = 0f;
            if (cameraZoomedIn)
            {
                gameObject.transform.rotation = screenViewPos.transform.rotation; // rotation
                gameObject.transform.position = screenViewPos.transform.position; // position
            }

        }
    }

}
