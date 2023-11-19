using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class not : MonoBehaviour
{
    public GameObject inputpre;
    private GameObject inputone;
    private GameObject output;
    private GameObject inputonechi;
    private int result;
    private Vector3 vec1;

    // Start is called before the first frame update
    void Start()
    {
        inputone = Instantiate(inputpre);
        output = transform.GetChild(0).gameObject;
        inputonechi = transform.GetChild(3).gameObject;
        inputone.name = "notinputone";
        vec1 = new Vector3(0.825f, 0.25f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        inputone.transform.position = gameObject.transform.position - vec1;
        inputonechi.tag = inputone.tag;
        if(inputone.tag == "1")
            output.tag = "0";
        else if(inputone.tag == "0") 
            output.tag = "1";
        else
            output.tag = "none";
    }
}
