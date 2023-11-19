using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class result : MonoBehaviour
{
    
    public GameObject inputpre;
    private GameObject inputobj;
    private GameObject input;
    private GameObject resultbox;
    private Renderer color;

    // Start is called before the first frame update
    void Start()
    {
        inputobj = Instantiate(inputpre);
        inputobj.name = "resultinput";
        input = transform.GetChild(0).gameObject;
        resultbox = transform.GetChild(1).gameObject;
        color = resultbox.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputobj.transform.position = gameObject.transform.position - new Vector3(1.075f, 0.25f, 0);
        if(inputobj.tag == "1")
        {
            color.material.color = Color.white;
        }
        else if(inputobj.tag == "0")
        {
            color.material.color = Color.black;
        }
        else
            color.material.color = Color.gray;
    }
}
