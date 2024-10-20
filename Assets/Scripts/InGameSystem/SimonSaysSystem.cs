using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public enum ButtonColors
{
    Red,
    Green,
    Blue
}

public class SimonSaysSystem : MonoBehaviour
{
    List<ButtonColors> simonColors;
    List<ButtonColors> playerColors;

    int winCounter;
    int WINS_NEEDED = 2;
    int colorCount = 1;
    int lives = 3;

    public TMP_Text simonDisplayText;
    public TMP_Text roundDisplay;
    public TMP_Text livesDisplay;

    // Add this for the lose sound
    public AudioClip loseSound; // Reference to the lose sound clip
    public AudioClip winSound; // Reference to the win sound clip
    private AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Init
        simonColors = new List<ButtonColors>();
        playerColors = new List<ButtonColors>();

        // Get the AudioSource component to play sounds
        audioSource = GetComponent<AudioSource>();

        // Start the game
        StartORRetry();
    }

    void FillSimonColors(int colorAmount)
    {
        // Create an empty list
        simonColors = new List<ButtonColors>();

        for (int i = 0; i < colorAmount; i++)
        {
            // Add random color from ButtonColors to list
            simonColors.Add((ButtonColors)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ButtonColors)).Length));
        }
    }

    void UpdateUIText(ButtonColors color)
    {
        Debug.Log(colorCount + ": Simon: " + color.ToString());
        simonDisplayText.text = colorCount + ": Simon says: " + color.ToString();
    }

    bool CompareLists()
    {
        // Lists are not the same size
        if (simonColors.Count != playerColors.Count) return false;

        // Check if every element is the same
        for (int i = 0; i < simonColors.Count; i++)
        {
            if (simonColors[i] != playerColors[i]) return false;
        }

        // If everything is correct return true
        return true;
    }

    public void ColorButtonPress(int color)
    {
        // Cringe unity
        playerColors.Add((ButtonColors)color);
    }

    public void CheckColors()
    {
        if (CompareLists())
        {
            // Player got it correct
            winCounter++;

            // Play the win sound
            if (audioSource != null && winSound != null)
            {
                audioSource.PlayOneShot(winSound);
            }

            if (winCounter >= WINS_NEEDED)
            {
                // Player won, do something...
                Debug.Log("Player has finished the game");
                SceneManager.LoadScene("EndingCinematics");
            }
            else
            {
                Debug.Log("Player won");

                // Reset lists
                FillSimonColors(5);
                playerColors.Clear();
                colorCount = 1;
                StartCoroutine(ShowColors(2));
            }
        }
        else
        {
            // Incorrect player input, punish...
            StopAllCoroutines();
            lives--; // Decrease lives

            // Play the lose sound
            if (audioSource != null && loseSound != null)
            {
                audioSource.PlayOneShot(loseSound);
            }

            playerColors.Clear();
            Debug.Log("Player has failed");
        }
    }

    public void StartORRetry()
    {
        colorCount = 1;
        FillSimonColors(5);
        StartCoroutine(ShowColors(2));
    }

    IEnumerator ShowColors(float delay)
    {
        for (int i = 0; i < simonColors.Count; i++)
        {
            UpdateUIText(simonColors[i]);
            colorCount++;
            yield return new WaitForSeconds(delay);
        }
    }

    private void Update()
    {
        // Update the lives display
        livesDisplay.text = "Lives: " + lives;
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
