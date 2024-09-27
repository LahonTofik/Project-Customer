using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                // ATTENTION: THIS IS A TEST SCRIPT FOR NOW, ONCE I HAVE FIGURED THIS PART OUT IT WILL BE FINALIZED!
[CreateAssetMenu(fileName = "SUPER NEAT THING", menuName = "SUPER/NEAT/THING")]
public class SOExample : ScriptableObject
{
    public string message;
    public List<SOExample> examples;
}
