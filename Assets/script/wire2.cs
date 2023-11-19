using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire2 : MonoBehaviour
{
    // public Camera main;
    public GameObject inputpre;
    public GameObject outputpre;
    private GameObject line;
    private GameObject input;
    private GameObject output;
    private GameObject inputwire;
    private GameObject outputwire;
    // Start is called before the first frame update
    void Start()
    {
        inputwire = Instantiate(inputpre);
        outputwire = Instantiate(outputpre);
        inputwire.name = "inputwire";
        outputwire.name = "outputwire";
        line = transform.GetChild(0).gameObject;
        input = transform.GetChild(1).gameObject;
        output = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        inputwire.transform.position = input.transform.position;
        outputwire.transform.position = output.transform.position;
        if(inputwire.tag == "1")
        {
            outputwire.tag = "1";
        }
        else if(inputwire.tag == "0")
        {
            outputwire.tag = "0";
        }
        else
            outputwire.tag = "none";
    }
}
