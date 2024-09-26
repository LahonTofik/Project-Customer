using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEditor;
using UnityEngine.SceneManagement;

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
    int WINS_NEEDED = 3;


    public TMP_Text simonDisplayText;
    public TMP_Text roundDisplay;



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
        Debug.Log("Simon: " + color.ToString());
        simonDisplayText.text = "Simon says: " + color.ToString();
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
            if (winCounter >= WINS_NEEDED)
            {
                // Player won, do something...
                Debug.Log("Player has finished the game");
                SceneManager.LoadScene("MainMenuWithAsset");
            }
            else
            {
                Debug.Log("Player won");

                // Reset lists
                FillSimonColors(5);
                playerColors.Clear();

                StartCoroutine(ShowColors(2));
            }
        }
        else
        {
            // Incorrect player input, punish...
            StopAllCoroutines();
            Debug.Log("Player has failed");
        }
    }

    IEnumerator ShowColors(float delay)
    {
        for (int i = 0; i < simonColors.Count; i++)
        {
            UpdateUIText(simonColors[i]);
            yield return new WaitForSeconds(delay);
        }
    }

    void Start()
    {
        // Init
        simonColors = new();
        playerColors = new();

        FillSimonColors(5);

        StartCoroutine(ShowColors(2));
    }


    /*List<ButtonColors> simonColors;
    List<ButtonColors> playerColors;

    public TMP_Text SimonOders;

    float simonDisplaytimer = 0f;

    bool simonPlayerCorrect; // checks if the list of simoncolors and playercolors have the same values and names

    bool nextColor = true;

    int nextIndex = 0;

    enum ButtonColors
    {
        Green,
        Red,
        Blue
    }

    void SimonSays()
    {
        ButtonColors randomColor = (ButtonColors)UnityEngine.Random.Range(2, 3);

        simonColors.Add(randomColor);

        randomColor = (ButtonColors)UnityEngine.Random.Range(0, 1);

        simonColors.Add(randomColor);
    }

    // Buttons
    public void PlayerInput(int playerInput)
    {
        ButtonColors playerInputColor = (ButtonColors)playerInput;

        playerColors.Add(playerInputColor);

    }

    public void ComparePlayerSimon()
    {

        if (simonColors.Count == playerColors.Count)
        {
            Debug.Log("both counts allign");

            for (int i = 0; i < simonColors.Count; i++)
            {
                if (simonColors[i] == playerColors[i])
                {
                    Debug.Log("IT WORKS!!!  simon is:" + simonColors[i] + " and player is: " + playerColors[i]);
                    simonPlayerCorrect = true;
                }
                else
                {
                    Debug.Log("watafaq... simon is: " + simonColors[i] + " and player is: " + playerColors[i]);
                    simonPlayerCorrect = false;
                    playerColors.Clear();
                    break;
                }
            }
        }
        else
        {
            Debug.Log("both list amounts not the same");
            playerColors.Clear();
        }
        if (simonPlayerCorrect)
        {
            SimonSays();
            SimonDisplay();
        }
    }

    public void SimonDisplay()
    {
        for (int i = nextIndex; i < simonColors.Count; i++)
        {
            if (nextColor)
            {
                SimonOders.text = "simon says:" + simonColors[i];

                nextColor = false;
                simonDisplaytimer = 0;
                if (nextIndex >= simonColors.Count)
                {
                    SimonOders.text = "Your turn to put in the colors!";
                    break;
                }
                nextIndex++;
                break;
            }
        }

    }

    private void Start()
    {
        playerColors = new List<ButtonColors>();
        simonColors = new List<ButtonColors>();
        SimonSays();
        SimonDisplay();
    }

    //public void ComparePSButton()
    private void Update()
    {
        SimonDisplay();
        simonDisplaytimer += Time.deltaTime;
        if (simonDisplaytimer >= 2f)
        {
            nextColor = true;
        }
    }*/
}
