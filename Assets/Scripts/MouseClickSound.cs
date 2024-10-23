using UnityEngine;

public class MouseClickSound : MonoBehaviour
{
    public AudioClip clickSound; // Drag your mouse click sound file here in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource if not already attached
        audioSource.playOnAwake = false; // Do not play the sound on awake
    }

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            PlayMouseClickSound();
        }
    }

    // Method to play mouse click sound
    private void PlayMouseClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound); // Play the sound
        }
    }
}

