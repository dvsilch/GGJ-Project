using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    [SerializeField]
    private Seesaw omoteSeeSaw, urateSeeSaw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((omoteSeeSaw.Left.CurObject || urateSeeSaw.Left.CurObject) && !omoteSeeSaw.Right.CurObject && !urateSeeSaw.Right.CurObject)
        {
            omoteSeeSaw.ChangeRUpMode();
            urateSeeSaw.ChangeRUpMode();
        }
        else if ((omoteSeeSaw.Right.CurObject || urateSeeSaw.Right.CurObject) && !omoteSeeSaw.Left.CurObject && !urateSeeSaw.Left.CurObject)
        {
            omoteSeeSaw.ChangeLUpMode();
            urateSeeSaw.ChangeLUpMode();
        }
        else if (omoteSeeSaw.Left.CurObject && urateSeeSaw.Right.CurObject)
        {
            if (omoteSeeSaw.Left.CurObject.TryGetComponent<PlayerController>(out var player) && player.Change)
            {
                omoteSeeSaw.ChangeRUpMode();
                urateSeeSaw.ChangeRUpMode();
            }
            else
            {
                omoteSeeSaw.ChangeLUpMode();
                urateSeeSaw.ChangeLUpMode();
            }
        }
        else if (urateSeeSaw.Left.CurObject && omoteSeeSaw.Right.CurObject)
        {
            if (urateSeeSaw.Left.CurObject.TryGetComponent<PlayerController>(out var player) && !player.Change)
            {
                omoteSeeSaw.ChangeLUpMode();
                urateSeeSaw.ChangeLUpMode();
            }
            else
            {
                omoteSeeSaw.ChangeRUpMode();
                urateSeeSaw.ChangeRUpMode();
            }
        }
    }
}