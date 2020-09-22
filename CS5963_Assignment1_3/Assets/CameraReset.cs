using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRPlayerController player = gameObject.GetComponent<OVRPlayerController>();
        CharacterController cc = player.GetComponent<CharacterController>();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cc.Move(new Vector3(-transform.position.x, -transform.position.y, -transform.position.z));
        }
    }
}
