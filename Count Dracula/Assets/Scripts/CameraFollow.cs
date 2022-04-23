using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject dracPlayer;
    Vector3 exitPos;

    void Update()
    {
        exitPos = Vector3.Lerp(gameObject.transform.position, dracPlayer.transform.position, Time.deltaTime);
        gameObject.transform.position = new Vector3(exitPos.x, 1, exitPos.z);
    }
}
