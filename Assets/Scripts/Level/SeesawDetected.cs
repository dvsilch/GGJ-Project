using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawDeteced : MonoBehaviour
{
    private GameObject curObject;

    public GameObject CurObject => curObject;

    public Collider2D collider2DCircle;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        curObject = collision.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        curObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        curObject = null;
    }
}
