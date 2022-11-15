using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform[] camPoints;
    int currentCamPointIndex;
    Transform currentCamPoint;

    void Start()
    {
        ChangeCamPoint(0);
    }

    void Update()
    {
        const float lerpSpeed = 10f;
        transform.position = Vector3.Lerp(transform.position, currentCamPoint.position, Time.deltaTime * lerpSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentCamPoint.rotation, Time.deltaTime * lerpSpeed);


        if(Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeCamPoint(1);
        else if(Input.GetKeyDown(KeyCode.RightArrow))
            ChangeCamPoint(-1);
    }

    void ChangeCamPoint(int direction)
    {
        currentCamPointIndex += direction;
        if(currentCamPointIndex == -1)
            currentCamPointIndex = camPoints.Length - 1;
        currentCamPointIndex %= camPoints.Length;

        currentCamPoint = camPoints[currentCamPointIndex];
    }

    public Transform GetCurrentCamPoint() => currentCamPoint;
}
