using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                // ATTENTION: THIS IS A TEST SCRIPT FOR NOW, ONCE I HAVE FIGURED THIS PART OUT IT WILL BE FINALIZED!
public class IkBenScript : MonoBehaviour
{
    [SerializeField] SOExample SOExample;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SOExample.message);
        //Debug.Log(SOExample.);
        foreach(SOExample example in SOExample.examples)
        {
            SOExample = example;
            Debug.Log (SOExample.message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
