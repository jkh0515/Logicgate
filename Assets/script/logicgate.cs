using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicgate : MonoBehaviour
{
    public Camera main;
    public GameObject cmr;
    public GameObject createbt;
    public GameObject cameraset;
    public GameObject reset;
    public GameObject create;
    public GameObject createpoint;
    public GameObject wirepre;
    public GameObject inputpre;
    public GameObject andpre;
    public GameObject orpre;
    public GameObject resultpre;
    public GameObject notpre;
    private GameObject clickobj;
    private GameObject clickchi;
    private GameObject wireinput;
    private GameObject wireoutput;
    private GameObject wireobj;
    private GameObject inputobj;
    private GameObject andobj;
    private GameObject orobj;
    private GameObject resultobj;
    private GameObject notobj;
    private Renderer color;
    private GameObject idxnum;
    private GameObject idxobj;
    private float cmrx = 0;
    private float cmry = 10;
    private float cmrz = 0;
    private float cmrview = 60;
    private bool click = false;
    private bool move = true;
    private bool btact = false;
    private bool wirecreate = false;
    private List<GameObject> list = new List<GameObject>();
    private List<List<int>> wirelist = new List<List<int>>(); 
    private int idx = 0;

    void Start()
    {   
        createbt.SetActive(btact);
        createpoint.SetActive(btact);
        reset.SetActive(move);
        create.SetActive(move);
        cameraset.SetActive(false);
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            cmr.transform.Translate(new Vector3(0,0.03f,0));
        if(Input.GetKey(KeyCode.A))
            cmr.transform.Translate(new Vector3(-0.03f,0,0));
        if(Input.GetKey(KeyCode.S))
            cmr.transform.Translate(new Vector3(0,-0.03f,0));
        if(Input.GetKey(KeyCode.D))
            cmr.transform.Translate(new Vector3(0.03f,0,0));
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * 15.0f;
        if(distance != 0 && main.fieldOfView <= 100 && main.fieldOfView >= 20)
        {
            main.fieldOfView += distance;
        }
        if(main.fieldOfView > 100)
            main.fieldOfView = 100;
        else if(main.fieldOfView < 20)
            main.fieldOfView = 20;
        if(cmr.transform.position != new Vector3(cmrx,cmry,cmrz) || main.fieldOfView != cmrview)
            cameraset.SetActive(true);
        else
            cameraset.SetActive(false);
        if(click == false)
        {
            if(Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.transform.gameObject.CompareTag("gate"))
                    {
                        hit.transform.gameObject.tag = "click";
                        clickobj = GameObject.FindWithTag("click");
                        clickchi = clickobj.transform.GetChild(0).gameObject;
                        if(clickobj.gameObject.name == "INPUT")
                        {
                            color = clickchi.GetComponent<Renderer>();
                            if(clickchi.gameObject.name == "1")
                            {
                                clickchi.gameObject.name = "0";
                                color.material.color = Color.black;
                                clickobj.tag = "gate";
                            }
                            else
                            {
                                clickchi.gameObject.name = "1";
                                color.material.color = Color.white;
                                clickobj.tag = "gate";
                            }
                        }
                        else if(clickobj.gameObject.name == "WIRE" && move == true)
                        {
                            clickobj.tag = "gate";
                            wireinput = clickobj.transform.GetChild(1).gameObject;
                            wireoutput = clickobj.transform.GetChild(3).gameObject;
                            if(clickchi.transform.localScale.x != 5)
                            {
                                clickchi.transform.localScale += new Vector3(1.0f, 0, 0);
                                wireinput.transform.localPosition -= new Vector3(0.5f, 0, 0);
                                wireoutput.transform.localPosition += new Vector3(0.5f, 0, 0); 
                            }
                            else
                            {
                                clickchi.transform.localScale = new Vector3(1.0f, 0.5f, 0.05f);
                                wireinput.transform.localPosition += new Vector3(2.0f, 0, 0);
                                wireoutput.transform.localPosition -= new Vector3(2.0f, 0, 0);
                            }
                        }
                        else
                        {
                            clickobj.tag = "gate";
                        }
                    }
                }
            }
            else if(Input.GetMouseButton(2) && wirecreate == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.transform.name == "WIRE")
                    {
                        hit.transform.eulerAngles -= new Vector3(0, 1.0f, 0);
                    }
                }
            }
        }
        if(move == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(click == false)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit))
                    {
                        if(hit.transform.gameObject.CompareTag("gate"))
                        {   
                            click = true;
                            Cursor.visible = false;
                            hit.transform.gameObject.tag = "click";
                            clickobj = GameObject.FindWithTag("click");
                        }
                    }
                }
                else
                {
                    Cursor.visible = true;
                    clickobj.tag = "gate";
                    click = false;
                }
            }
            if(click == true)
            {
                movegate();
            }

        }
        if(wirecreate == true && Input.GetMouseButton(2))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name != "input" && hit.transform.name != "createpoint")
                {
                    idxobj = hit.transform.GetChild(2).gameObject;
                    Debug.Log(idxobj.transform.name);
                }
            }
        }
    }

    void movegate()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z+10.0f));
        clickobj.transform.position = new Vector3(point.x, 0.5f, point.z);
        // Debug.Log(new Vector3(point.x, point.y, point.z));
    }

    public void movecheck()
    {
        if(move == false)
        {
            move = true;
            reset.SetActive(move);
            create.SetActive(move);
        }
        else
        {
            move = false;
            reset.SetActive(move);
            create.SetActive(move);
            if(btact == true)
                btactivate();
        }    
    }

    public void btactivate()
    {
        if(btact == false)
        {
            btact = true;
            createbt.SetActive(btact);
            createpoint.SetActive(btact);
        }
        else
        {
            btact = false;
            createbt.SetActive(btact);
            createpoint.SetActive(btact);
        }
    }

    public void createinput()
    {
        inputobj = Instantiate(inputpre);
        inputobj.name = "INPUT";
        inputobj.transform.position = createpoint.transform.position;
        idxnum = inputobj.transform.GetChild(2).gameObject;
        idxnum.name = idx+"";
        list.Add(inputobj);
        Debug.Log(list[idx]);
        idx = idx + 1;
    }

    public void createand()
    {
        andobj = Instantiate(andpre);
        andobj.name = "AND";
        andobj.transform.position = createpoint.transform.position;
        idxnum = andobj.transform.GetChild(2).gameObject;
        idxnum.name = idx+"";
        list.Add(andobj);
        Debug.Log(list[idx]);
        idx = idx + 1;
    }

    public void createor()
    {
        orobj = Instantiate(orpre);
        orobj.name = "OR";
        orobj.transform.position = createpoint.transform.position;
        idxnum = orobj.transform.GetChild(2).gameObject;
        idxnum.name = idx+"";
        list.Add(orobj);
        Debug.Log(list[idx]);
        idx = idx + 1;
    }

    public void createwire()
    {
        wireobj = Instantiate(wirepre);
        wireobj.name = "WIRE";
        wireobj.transform.position = createpoint.transform.position;
        idxnum = wireobj.transform.GetChild(2).gameObject;
        idxnum.name = idx+"";
        list.Add(wireobj);
        Debug.Log(list[idx]);
        idx = idx + 1;
    }

    public void createresult()
    {
        resultobj = Instantiate(resultpre);
        resultobj.name = "RESULT";
        resultobj.transform.position = createpoint.transform.position;
        idxnum = resultobj.transform.GetChild(2).gameObject;
        idxnum.name = idx+"";
        list.Add(resultobj);
        Debug.Log(list[idx]);
        idx = idx + 1;
    }

    public void createnot()
    {
        notobj = Instantiate(notpre);
        notobj.name = "NOT";
        notobj.transform.position = createpoint.transform.position;
        idxnum = notobj.transform.GetChild(2).gameObject;
        idxnum.name = idx+"";
        list.Add(notobj);
        Debug.Log(list[idx]);
        idx = idx + 1;
    }

    public void wireangle()
    {   
        if(wirecreate == false)
        {
            wirecreate = true;
        }
        else
        {
            wirecreate = false;
        }
    }

    public float checkdis(int idx1, int idx2)
    {
        return 0;
    }

    public void deletebt()
    {

    }

    public void camerasetbt()
    {
        cmrview = main.fieldOfView;
        cmrx = cmr.transform.position.x;
        cmry = cmr.transform.position.y;
        cmrz = cmr.transform.position.z;
    }

    public void cameraresetbt()
    {
        main.fieldOfView = cmrview;
        cmr.transform.position = new Vector3(cmrx,cmry,cmrz);
    }

    public void resetbt()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
