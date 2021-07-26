using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Travel : MonoBehaviour
{
    public Transform lastPoint;
    public float carSpeed;
    public NavMeshAgent NMA;

    public bool Travelling;
    public Travel Instance;

    public LineRenderer LR;

    public bool CameraFollow;
    public float smoothSpeed = 1f;

    public Vector3 offSet;
    public GameObject camera;

    void Start()
    {
        carSpeed = 0;

        Travelling = false;
        CameraFollow = false;

        NMA = GetComponent<NavMeshAgent>();
        LR = GetComponent<LineRenderer>();

        LR.startWidth = 1f;
        LR.endWidth = 1f;
        LR.positionCount = 0;

        NMA.GetComponent<NavMeshAgent>().enabled = false;
    }
    void Update()
    {
        NMA.speed = carSpeed;
        if (Travelling)
        {
            CameraFollow = true;
            carSpeed = 25;
            NMA.SetDestination(lastPoint.position);

            DrawShortestPath();
        }
        else if(!Travelling)
        {
            carSpeed = 0;
        }

        CameraStartFollowing();
    }

    void DrawShortestPath()
    {
        LR.positionCount = NMA.path.corners.Length;
        LR.SetPosition(0, transform.position);

        if(NMA.path.corners.Length < 2)
        {
            CameraFollow = false;
            return;
        }

        for(int i=1; i < NMA.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(NMA.path.corners[i].x, NMA.path.corners[i].y, NMA.path.corners[i].z);
            LR.SetPosition(i, pointPosition);
        }
    }

    public void CameraStartFollowing()
    {
        offSet = new Vector3(transform.position.x - 30, 150, transform.position.z + 100);
        Vector3 follow = Vector3.Lerp(gameObject.transform.position, offSet, 5);

        if (CameraFollow)
        {
            camera.transform.position = follow;
        }
    }

    public void CameraButton()
    {
        offSet = new Vector3(transform.position.x - 30, 150, transform.position.z + 100);
        Vector3 follow = Vector3.Lerp(gameObject.transform.position, offSet, 5);
        camera.transform.position = follow;
    }
}
