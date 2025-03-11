using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleSceneButtonController : MonoBehaviour
{
    public TextMeshProUGUI text;
    Color textColor;
    
    //Color changeColor;
    float r;
    float g;
    float b;

    //bool isMouseEnter = false;

    public float changeValue;

    // Start is called before the first frame update
    void Start()
    {
        textColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void MouseEnter() 
    {
        Debug.Log("mouse ENTER");
        //isMouseEnter = true;
        text.alpha = 255;
        //changeColor.r = 0;
        Color c = text.color;
        c.r = 100;
        text.color = c;
    }
    

    public void MouseExit() 
    {
        Debug.Log("mouse EXIT");
    }

    Color ChangeTextColor(Color color, float init, float goal) 
    {
        r = Mathf.Lerp(init, goal, 0);

        return color;
    }

    
}
