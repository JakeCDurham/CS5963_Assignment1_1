using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour
{
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            light.color = randColor();
        }
    }
    
    public Color randColor()
    {
        return new Color(Random.Range(0, 256), Random.Range(0, 256), Random.Range(0, 256), Random.Range(0, 156));
    }
}
