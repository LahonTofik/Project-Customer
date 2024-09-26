using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip titlescreen;
    public AudioClip selecting;


private void Start()
{
    musicSource.clip = titlescreen;
        musicSource.Play();

}


}