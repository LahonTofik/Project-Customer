using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camera_1;
    public GameObject camera_2;
    public int camManager;

    public void ManageCamera()
    {
        if (camManager == 0)
        {
            Cam_2();
            camManager = 1;
        }
        else
        {
            Cam_1();
            camManager = 0;
        }
    }

    void Cam_1()
    {
        camera_1.SetActive(true);
        camera_2.SetActive(false);
    }

    void Cam_2()
    {
        camera_1.SetActive(false);
        camera_2.SetActive(true);
    }

}
