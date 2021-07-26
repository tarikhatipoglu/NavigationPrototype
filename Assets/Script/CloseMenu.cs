using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour
{
    public Travel Player;
    public GameObject[] buildingClicks;
    public GameObject camera;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Travel>();

        this.gameObject.SetActive(false);
    }
    public void Update()
    {
        buildingClicks = GameObject.FindGameObjectsWithTag("A");
        if (this.gameObject.activeSelf)
        {
            for (int a=0; a < buildingClicks.Length; a++)
            {
                buildingClicks[a].GetComponent<BuildingInformation>().enabled = false;
            }

            Time.timeScale = 0f;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                this.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        else
        {

        }
    }

    public void X()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    public void TravelButton()
    {
        Time.timeScale = 1f;
        Player.Travelling = true;
        Player.NMA.enabled = true;
        Player.CameraFollow = true;

        for (int a = 0; a < buildingClicks.Length; a++)
        {
            buildingClicks[a].GetComponent<BuildingInformation>().enabled = true;
        }
        this.gameObject.SetActive(false);
    }
    public void IAmHere()
    {
        Time.timeScale = 1f;

        Player.NMA.enabled = false;
        Player.Travelling = false;
        Player.CameraFollow = false;

        Player.transform.position = Player.lastPoint.position;
        Player.CameraButton();

        for (int a = 0; a < buildingClicks.Length; a++)
        {
            buildingClicks[a].GetComponent<BuildingInformation>().enabled = true;
        }
        this.gameObject.SetActive(false);
        //StartCoroutine(OnClick());
    }

    //IEnumerator OnClick()
    //{
    //    yield return StartCoroutine(WaitForOne(1));
    //    this.gameObject.SetActive(false);
    //}
    //IEnumerator WaitForOne(float AAA)
    //{
    //    float start = Time.realtimeSinceStartup;

    //    while (Time.realtimeSinceStartup < start + AAA)
    //    {
    //        yield return null;
    //    }
    //}
}
