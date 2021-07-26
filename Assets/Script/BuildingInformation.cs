using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingInformation : MonoBehaviour
{
    public Travel Player;
    public Camera mainCamera;
    public GameObject destination;

    public Renderer[] renders;
    public TMP_Text textObject;

    public Color MouseEnter;
    public Color MouseExit;

    public string buildingName;
    public Text buildingName_Text;

    public string buildingInfo;
    public Text buildingInfo_Text;

    public bool mouseEntered = false;

    public GameObject Menu;
    public Transform wayPoint;

    void Start()
    {
        renders = GetComponentsInChildren<Renderer>();

        mouseEntered = false;
        Menu.SetActive(false);

        textObject = gameObject.GetComponentInChildren<TMP_Text>();
        textObject.text = buildingName;
        textObject.gameObject.SetActive(false);
    }

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Travel>();
    }

    public void OnMouseEnter()
    {
        mouseEntered = true;
        textObject.gameObject.SetActive(true);

        for (int i=0; i < renders.Length; i++)
        {
            renders[i].material.SetColor("_Color", MouseEnter);
        }
        
    }
    public void OnMouseExit()
    {
        mouseEntered = false;
        textObject.gameObject.SetActive(false);

        for (int i = 0; i < renders.Length; i++)
        {
            renders[i].material.SetColor("_Color", MouseExit);
        }
    }
    private void OnMouseDown()
    {
        Player.lastPoint = destination.transform;

        buildingName_Text.text = buildingName;
        buildingInfo_Text.text = buildingInfo;

        Menu.SetActive(true);
    }
}
