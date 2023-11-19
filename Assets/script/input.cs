using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    private GameObject tf;
    private GameObject output;

    // Start is called before the first frame update
    void Start()
    {
        tf = transform.GetChild(0).gameObject;
        output = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(tf.gameObject.name == "1")
        {
            output.tag = "1";
        }
        else if(tf.gameObject.name == "0")
        {
            output.tag = "0";
        }
        else
            output.tag = "none";
    }
}
