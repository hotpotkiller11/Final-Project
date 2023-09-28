using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obj;
    public GameObject Flower_Face;

    private float r = 1f;
    private float g = 0.7f;
    private float b = 0.4f;

    private float r1 = 0.9f;
    private float g1 = 0.9f;
    private float b1 = 0.5f;

    void Start()
    {
        //Obj.GetComponent<Renderer>().material.color = new Color(0.8f, 0.7f, 0.5f);
        //toWhite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toRed()
    {
            Invoke("reder", 0.1f);
            Obj.GetComponent<Renderer>().material.color = new Color(r, 0.7f, 0.5f);
        
        
    }
    public void toWhite()
    {
        Invoke("whiter", 0.1f);
        Obj.GetComponent<Renderer>().material.color = new Color(r, g, b); 
        Obj.GetComponent<Renderer>().material.color = new Color(r1, g1, b1);
        
    }
    public void reder()
    {
        if (g > 0)
        {
            g -= 0.02f;
        }
    }
    public void whiter()
    {
        if (b1 < 1)
        {
            g1 += 0.02f;
            b1 += 0.02f;
            r1 += 0.02f;
        }
        if (b < 0.8)
        {
            r += 0.02f;
            g += 0.02f;
            b += 0.02f;
        }
    }
    public void backColor()
    {
        r = 0.8f;
        g = 0.7f;
        b = 0.5f;
        r1 = 0.9f;
        g1 = 0.9f;
        b1 = 0.5f;
        Obj.GetComponent<Renderer>().material.color = new Color(r, g, b);
        Flower_Face.GetComponent<Renderer>().material.color = new Color(r1, g1, b1);
    }
}
