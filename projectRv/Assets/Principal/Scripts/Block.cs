using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {

    private Vector3 p1;
    private Vector3 p2;
    private Vector3 p3;
    private Vector3 p4;

    private float width;
    private float height;

    // Use this for initialization
    void Start () {

        width = this.GetComponent<RectTransform>().rect.width;
        height = this.GetComponent<RectTransform>().rect.height;
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void updatePoints()
    {
        p1.x = Input.mousePosition.x - width / 2;
        p1.y = Input.mousePosition.y - height / 2;

        p2.x = Input.mousePosition.x + width / 2;
        p2.y = Input.mousePosition.y - height / 2;

        p3.x = Input.mousePosition.x + width / 2;
        p3.x = Input.mousePosition.y - height / 2;

        p4.x = Input.mousePosition.x - width / 2;
        p4.x = Input.mousePosition.y - height / 2;

        
    }

    public Vector3 getP1() {
        return p1;
    }
    public Vector3 getP2()
    {
        return p2;
    }
    public Vector3 getP3()
    {
        return p3;
    }
    public Vector3 getP4()
    {
        return p4;
    }
}
