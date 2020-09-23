using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VRMirrorOVR : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    private Vector3 previousPos;
    private bool matching;
    
    void Start()
    {
        //cube.transform.position = new Vector3(0, 1.5f, 0);
        gameObject.AddComponent<OVRCameraRig>();
        previousPos = gameObject.GetComponent<OVRCameraRig>().centerEyeAnchor.position;
        matching = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            matching = !matching;
        }

        if(matching)
        {
            OVRCameraRig camera = gameObject.GetComponent<OVRCameraRig>();
            cube.transform.position += camera.centerEyeAnchor.position - previousPos;
            previousPos = camera.centerEyeAnchor.position;
            cube.transform.rotation = camera.centerEyeAnchor.rotation;
        }
        else
        {
            OVRCameraRig camera = gameObject.GetComponent<OVRCameraRig>();
            cube.transform.rotation = Quaternion.Inverse(camera.centerEyeAnchor.rotation);
            cube.transform.rotation *= Quaternion.Euler(0, 180f, 0);
            cube.transform.rotation *= Quaternion.Euler(2 * (-cube.transform.rotation.eulerAngles.x), 0, 0);
            cube.transform.position = camera.centerEyeAnchor.position;
            cube.transform.position = cube.transform.position.ToFlippedZVector3f().FromVector3f();
        }
    }
}
