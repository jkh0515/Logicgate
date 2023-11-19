using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputwire : MonoBehaviour
{
    void OnTriggerStay(Collider col)
    {
        if(col.tag == "1" && col.name != "inputwire")
        {
            gameObject.tag = "1";
        }
        else if(col.tag == "0" && col.name != "inputwire")
        {
            gameObject.tag = "0";
        }
        else if(col.name != "input")
        {
            gameObject.tag = "none";
        }
    }

    void OnTriggerExit(Collider col)
    {
        gameObject.tag = "none";
    }
}
