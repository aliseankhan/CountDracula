using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimationController : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        TileDrop tileDropScript = this.gameObject.GetComponent<TileDrop>();
        if (tileDropScript.isAbove == true)
        {
            anim.SetBool("Drop", true);
        }
        else
        {
            anim.SetBool("Drop", false);
        }
        
    }
}

