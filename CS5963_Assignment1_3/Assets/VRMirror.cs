using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMirror : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    private bool matching = true;

    private Vector3 previousPlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        previousPlayerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            matching = !matching;
        }


        if (matching)
        {
            Vector3 offset = player.transform.position - previousPlayerPos;
            transform.position += offset;
            transform.rotation = player.transform.rotation;
            previousPlayerPos = player.transform.position;
        }
        else
        {

        }

    }
}
