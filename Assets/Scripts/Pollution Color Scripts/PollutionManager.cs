using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PollutionManager : MonoBehaviour
{
    [Header("Water Shader Material")]
    public Material WaterShaderMat;  // The material used for the water shader

    [Header("Pollution Colors")]
    public Color cleanWaterColor = new Color(0.0f, 0.3f, 1.0f); // Blue (clean water)
    public Color pollutedWaterColor = new Color(0.0f, 0.5f, 0.0f); // Green (polluted water)
    public Color cleanFoamColor = new Color(1.0f, 1.0f, 1.0f); // White (clean foam)
    public Color pollutedFoamColor = new Color(0.5f, 0.5f, 0.0f); // Yellowish (polluted foam)

    private float pollutionLevel = 50.0f;  // Initial pollution level (range 0 to 100)
    private DialogueRunner dialogueRunner;
    private static HashSet<string> registeredCommands = new HashSet<string>();

    void Start()
    {
        // Check if WaterShaderMat is assigned
        if (WaterShaderMat == null)
        {
            Debug.LogError("WaterShaderMat is not assigned. Please assign it in the Inspector.");
            return;
        }

        // Test: Manually apply colors to verify the shader responds to changes
        WaterShaderMat.SetColor("_WaterColor", Color.blue);  // Set water to blue
        WaterShaderMat.SetColor("_FoamColor", Color.white);  // Set foam to white
        Debug.Log("Test: Setting Water Color to blue and Foam Color to white on Start.");

        // Find the DialogueRunner in the scene
        dialogueRunner = FindObjectOfType<DialogueRunner>();

        if (dialogueRunner == null)
        {
            Debug.LogError("DialogueRunner not found in the scene. Please ensure it's added to the scene.");
            return;
        }

        // Register the command handler for adjusting pollution
        RegisterCommandHandlers();

        // Initialize the water shader with the current pollution level
        UpdateWaterShader();
    }

    // Method to register command handlers
    private void RegisterCommandHandlers()
    {
        string commandName = "adjust_pollution";

        // Check if command is already registered
        if (!registeredCommands.Contains(commandName))
        {
            dialogueRunner.AddCommandHandler(commandName, (string[] parameters) => AdjustPollution(parameters));
            registeredCommands.Add(commandName);
            Debug.Log($"Command handler for '{commandName}' registered.");
        }
        else
        {
            Debug.LogWarning($"Command handler for '{commandName}' is already registered.");
        }
    }

    // Update the water shader with the appropriate colors based on pollution level
    void UpdateWaterShader()
    {
        float pollutionPercentage = pollutionLevel / 100.0f;

        // Interpolate between clean and polluted water colors
        Color waterColor = Color.Lerp(cleanWaterColor, pollutedWaterColor, pollutionPercentage);
        Color foamColor = Color.Lerp(cleanFoamColor, pollutedFoamColor, pollutionPercentage);

        // Debugging: Log the current pollution percentage and the colors being set
        Debug.Log($"Pollution Percentage: {pollutionPercentage * 100}%");
        Debug.Log($"Setting Water Color to: {waterColor}");
        Debug.Log($"Setting Foam Color to: {foamColor}");

        // Apply the colors to the water material using the correct shader property names
        WaterShaderMat.SetColor("_WaterColor", waterColor);
        WaterShaderMat.SetColor("_FoamColor", foamColor);
    }

    // Adjust the pollution level based on Yarn command
    public void AdjustPollution(string[] parameters)
    {
        if (parameters.Length > 0 && float.TryParse(parameters[0], out float changeAmount))
        {
            pollutionLevel += changeAmount;
            pollutionLevel = Mathf.Clamp(pollutionLevel, 0.0f, 100.0f); // Clamp between 0 and 100

            // Debugging: Log the pollution adjustment details
            Debug.Log($"Pollution adjusted by {changeAmount}. New pollution level: {pollutionLevel}");

            UpdateWaterShader();
        }
        else
        {
            Debug.LogWarning("Invalid pollution adjustment parameters.");
        }
    }

    // Method to get the current pollution level (optional for further uses)
    public float GetPollutionLevel()
    {
        return pollutionLevel;
    }
}
