using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    private CinemachineConfiner2D confiner2D;

    private void Awake(){
        confiner2D=GetComponent<CinemachineConfiner2D>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
   private  void Start()
    {
        GetNewCameraBound();
    }

    private void GetNewCameraBound(){
        var obj=GameObject.FindGameObjectWithTag("Bound");
        if(obj==null)
        {return;}
        confiner2D.m_BoundingShape2D=obj.GetComponent<Collider2D>();
        confiner2D.InvalidateCache();
    }
}
