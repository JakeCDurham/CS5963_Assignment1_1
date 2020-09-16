using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using TMPro;

public class lazerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> lazers;
    [SerializeField] private TMP_Text scoreText;
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
        score = 5;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
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
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            bool triggerValue;
            if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                scoreText.text = "Trigger pressed!";
                foreach(GameObject current in lazers) {
                    if (current.GetComponent<lazer>().inZone) {
                        score += 1;
                        SwitchLights();
                    }
                }
            }
        }
    }

    public void SwitchLights()
    {
        triggerSwitch = true;
    }
}
