using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject playerViewPos;
    [SerializeField] GameObject computerZoomPos;
    [SerializeField] GameObject screenViewPos;
    [SerializeField] GameObject closeUpBoard;

    [SerializeField] GameObject notYetPromt;

    float lerpTime = 0f;

    bool camSwitch = false;
    bool cameraZoomedIn = false;
    bool isOnScreen = false;

    bool camSwitchBoard = false;
    bool zoomedInBoard = false;
    bool isOnBoard = false;

    bool codeSeen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isOnScreen == false) // board zoom-in
        {
            lerpTime = 0f;
            camSwitchBoard = true;
            isOnBoard = !isOnBoard;
        }
        if (camSwitchBoard)
        {
            lerpTime += Time.deltaTime;
            if (!zoomedInBoard)
            {
                gameObject.transform.rotation = Quaternion.Lerp(playerViewPos.transform.rotation, closeUpBoard.transform.rotation, lerpTime); // rotation
                gameObject.transform.position = Vector3.Lerp(playerViewPos.transform.position, closeUpBoard.transform.position, lerpTime); // position
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Lerp(closeUpBoard.transform.rotation, playerViewPos.transform.rotation, lerpTime); // rotation
                gameObject.transform.position = Vector3.Lerp(closeUpBoard.transform.position, playerViewPos.transform.position, lerpTime); // position
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && isOnBoard == false && codeSeen == true) // computer zoom-in
        {
            lerpTime = 0f;
            camSwitch = true;
            isOnScreen = !isOnScreen;
        }
        else if (Input.GetKeyDown(KeyCode.E) && codeSeen == false)
        {
            notYetPromt.SetActive(true);
        }
        if (camSwitch)
        {
            lerpTime += Time.deltaTime;
            if (!cameraZoomedIn)
            {
                gameObject.transform.rotation = Quaternion.Lerp(playerViewPos.transform.rotation, computerZoomPos.transform.rotation, lerpTime); // rotation
                gameObject.transform.position = Vector3.Lerp(playerViewPos.transform.position, computerZoomPos.transform.position, lerpTime); // position
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Lerp(computerZoomPos.transform.rotation, playerViewPos.transform.rotation, lerpTime); // rotation
                gameObject.transform.position = Vector3.Lerp(computerZoomPos.transform.position, playerViewPos.transform.position, lerpTime); // position
            }
        }
        if (lerpTime > 1f && camSwitch)
        {
            SceneManager.LoadScene("Computer screen");
        }
        if (lerpTime > 1f && camSwitchBoard)
        {
            zoomedInBoard = !zoomedInBoard;
            camSwitchBoard = false;
            lerpTime = 0f;
        }
    }

    public void CodeIsSeen()
    {
        codeSeen = true;
    }

}
