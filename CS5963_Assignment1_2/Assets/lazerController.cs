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
            G.AddComponent<lazer>();
        }
        lazers[0].SetActive(true);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        timeLeft -= Time.deltaTime;

        if (OVRInput.Get(OVRInput.Button.Start, OVRInput.Controller.LTouch))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
        }

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

        foreach (GameObject go in lazers)
        {
            lazer laz = go.GetComponent<lazer>();
            if (laz.inZone && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0)
            {
                score++;
                triggerSwitch = true;
                laz.inZone = false;
            }
        }
    }
}
