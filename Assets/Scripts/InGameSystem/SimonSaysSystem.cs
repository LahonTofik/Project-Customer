using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ButtonColors
{
    Red,
    Yellow,
    Blue
}

public class SimonSaysSystem : MonoBehaviour
{
    [SerializeField] GameObject redCircle;
    [SerializeField] GameObject yellowCircle;
    [SerializeField] GameObject blueCircle;

    [SerializeField] Color redOnColor;
    public Color redOffColor;
    [SerializeField] Color yellowOnColor;
    public Color yellowOffColor;
    [SerializeField] Color blueOnColor;
    public Color blueOffColor;

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
            
            livesDisplay.text = "lives: " + lives;
            if (lives <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
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
            ChangeColors(simonColors[i]);
            colorCount++;
            yield return new WaitForSeconds(delay);
        }
    }

    void ChangeColors(ButtonColors buttonColors)
    {
        Image colorRedCircle = redCircle.GetComponent<Image>();
        Image colorYellowCircle = yellowCircle.GetComponent<Image>();
        Image colorBlueCircle = blueCircle.GetComponent<Image>();

        colorRedCircle.color = redOffColor;
        colorYellowCircle.color = yellowOffColor;
        colorBlueCircle.color = blueOffColor;

        switch(buttonColors)
        {
            case ButtonColors.Red:
                Console.WriteLine("this is red now");
                colorRedCircle.color = redOnColor;
                break;
            case ButtonColors.Yellow:
                colorYellowCircle.color = yellowOnColor;
                Console.WriteLine("this is yellow now");
                break;
            case ButtonColors.Blue:
                colorBlueCircle.color = blueOnColor;
                Console.WriteLine("this is blue now");
                break;
        }
    }

    void Start()
    {
        // Init
        simonColors = new();
        playerColors = new();
    }
}
