using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class or : MonoBehaviour
{
    public GameObject inputpre;
    private GameObject inputone;
    private GameObject inputtwo;
    private GameObject output;
    private GameObject inputonechi;
    private GameObject inputtwochi;
    private int result;
    private Vector3 vec1;
    private Vector3 vec2;

    // Start is called before the first frame update
    void Start()
    {
        inputone = Instantiate(inputpre);
        inputtwo = Instantiate(inputpre);
        output = transform.GetChild(0).gameObject;
        inputonechi = transform.GetChild(3).gameObject;
        inputtwochi = transform.GetChild(4).gameObject;
        inputone.name = "orinputone";
        inputtwo.name = "orinputtwo";
        vec1 = new Vector3(0.825f, 0.25f, -0.25f);
        vec2 = new Vector3(0.825f, 0.25f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        inputone.transform.position = gameObject.transform.position - vec1;
        inputtwo.transform.position = gameObject.transform.position - vec2;
        inputonechi.tag = inputone.tag;
        inputtwochi.tag = inputtwo.tag;
        if(inputone.tag != "none" && inputtwo.tag != "none")
        {
            result = int.Parse(inputone.tag) | int.Parse(inputtwo.tag);
            output.tag = result.ToString();
        }
        else
            output.tag = "none";
    }
}
