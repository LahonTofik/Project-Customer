using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputValidator : MonoBehaviour
{
    private string input;

    public void ValidateInput(string s)
    {
        input = s;
        Console.WriteLine(input);
        if (input == "1638914427")
        {
            Console.WriteLine("Yippee");
        }
        else
        {
            Console.WriteLine("did not work :(");
        }
    }
}
