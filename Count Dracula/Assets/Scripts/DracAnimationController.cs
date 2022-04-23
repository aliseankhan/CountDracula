using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracAnimationController : MonoBehaviour
{
    Animator anim;
    public GameObject thePlayer;

    public List<GameObject> fakeFloorTiles;

    Vector3 startPos;
    Vector3 midPos;
    Vector3 endPos;
    Vector3 finalPos;

    Vector3 startMove;
    Vector3 endMove;

    float currentTime = 0;
    float timeToDrop = 5;

    bool canDrop = true;
    bool stage1 = false;
    bool stage2 = false;
    bool stage3 = false;


    //int count = 0;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        thePlayer.transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        //Bounce bounceScript = thePlayer.GetComponent<Bounce> ();
        //if (bounceScript.justJump == true)
        //{
        //    anim.SetBool("Jump", true);
        //}
        //else
        //{
        //    anim.SetBool("Jump", false);
        //}
        startMove = thePlayer.transform.position;
        if (Input.GetButtonDown("right"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            endMove = new Vector3(thePlayer.transform.position.x + 2, thePlayer.transform.position.y, thePlayer.transform.position.z);
            thePlayer.transform.position = Vector3.Lerp(startMove, endMove, 1);
        }
        if (Input.GetButtonDown("left"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            endMove = new Vector3(thePlayer.transform.position.x - 2, thePlayer.transform.position.y, thePlayer.transform.position.z);
            thePlayer.transform.position = Vector3.Lerp(startMove, endMove, 1);
        }
        if (Input.GetButtonDown("up"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            endMove = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, thePlayer.transform.position.z + 2);
            thePlayer.transform.position = Vector3.Lerp(startMove, endMove, 1);
        }
        if (Input.GetButtonDown("down"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            endMove = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, thePlayer.transform.position.z - 2);
            thePlayer.transform.position = Vector3.Lerp(startMove, endMove, 1);
        }
        

        foreach (GameObject gO in fakeFloorTiles) 
        {
            DoTheDrop(gO);
        }
    }

    void DoTheDrop(GameObject gO)
    {
        if (canDrop)
        {
            if (
                (gO.transform.position.x == thePlayer.transform.position.x + 1)
                & (gO.transform.position.z == thePlayer.transform.position.z - 1)
                )
            {
                canDrop = false;
                startPos = thePlayer.transform.position;
                midPos = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y - 30, thePlayer.transform.position.z);
                endPos = new Vector3(thePlayer.transform.position.x - 2, thePlayer.transform.position.y, thePlayer.transform.position.z - 6);
                finalPos = new Vector3(thePlayer.transform.position.x - 2, thePlayer.transform.position.y, thePlayer.transform.position.z);
                stage1 = true;
            }
        }

        if (!canDrop)
        {
            if (stage1)
            {
                if (currentTime <= timeToDrop)
                {
                    currentTime += Time.deltaTime;
                    thePlayer.transform.position = Vector3.Lerp(startPos, midPos, currentTime / timeToDrop);
                }
                else
                {
                    currentTime = 0f;
                    stage1 = false;
                    stage2 = true;
                }
            }

            if (stage2)
            {
                if (currentTime <= timeToDrop)
                {
                    currentTime += Time.deltaTime;
                    thePlayer.transform.position = Vector3.Lerp(midPos, endPos, currentTime / timeToDrop);
                }
                else
                {
                    currentTime = 0f;
                    stage2 = false;
                    stage3 = true;
                }
            }

            if (stage3)
            {
                if (currentTime <= timeToDrop)
                {
                    currentTime += Time.deltaTime;
                    thePlayer.transform.position = Vector3.Lerp(endPos, finalPos, currentTime / timeToDrop);
                }
                else
                {
                    currentTime = 0f;
                    stage3 = false;
                    canDrop = true;
                }
            }
        }
    }
}
