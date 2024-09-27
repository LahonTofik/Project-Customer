using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScriptOpeningScene : MonoBehaviour
{
    [SerializeField] VideoPlayer gameCinematics;

    [SerializeField] bool isOpeningScene;
    // Start is called before the first frame update
    void Start()
    {
        gameCinematics.loopPointReached += LoadNextSceneOnFinish;
    }

    void LoadNextSceneOnFinish(VideoPlayer vp)
    {
        if (isOpeningScene)
        {
        Debug.Log("video has ended");
        SceneManager.LoadScene("LevelOne");
        }
        else
        {
            SceneManager.LoadScene("MainMenu(Finished");
        }
    }
}
