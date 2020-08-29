using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    [SerializeField] private Transform room1Center;
    [SerializeField] private Transform room2Center;
    private bool atRoomOne = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            if (atRoomOne)
            {
                transform.position = room2Center.position;
            }
            else
            {
                transform.position = room1Center.position;
            }

            atRoomOne = !atRoomOne;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
