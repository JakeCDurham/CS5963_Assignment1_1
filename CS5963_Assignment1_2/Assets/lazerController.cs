using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class lazerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> lazers;
    [SerializeField] private float switchTime = 3f;
    private int currentIndex;
    private int score;
    private float timeLeft;
    private bool triggerSwitch = false;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = switchTime;
        foreach (GameObject G in lazers)
        {
            G.SetActive(false);
        }
        lazers[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0 || triggerSwitch)
        {
            timeLeft = switchTime;
            triggerSwitch = false;
            int temp = currentIndex;
            while (temp == currentIndex)
            {
                temp = Random.Range(0, lazers.Count);
            }

            lazers[currentIndex].SetActive(false);
            lazers[temp].SetActive(true);
            currentIndex = temp;
        }
    }

    public void SwitchLights()
    {
        triggerSwitch = true;
    }
}
