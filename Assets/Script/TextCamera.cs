using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextCamera : MonoBehaviour
{
    public Camera camera;
    public GameObject[] buildingTexts;
    public int count;
    void Start()
    {
        buildingTexts = GameObject.FindGameObjectsWithTag("TEXTS");
        count = buildingTexts.Length;
    }

    void Update()
    {
        for(int a=0; a < count; a++)
        {
            buildingTexts[a].transform.rotation = Quaternion.LookRotation(camera.transform.position - buildingTexts[a].transform.position);
        }
    }
}
