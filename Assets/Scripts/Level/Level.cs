using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Seesaw omoteSeeSaw, urateSeeSaw;

    [SerializeField]
    private Transform deadzone;

    [SerializeField]
    private Transform point;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (omoteSeeSaw.Left.CurObject && urateSeeSaw.Right.CurObject && omoteSeeSaw.Right.CurObject)
        {
            if (omoteSeeSaw.Left.CurObject.CompareTag("Player1") && urateSeeSaw.Right.CurObject.CompareTag("Player2") && omoteSeeSaw.Right.CurObject.CompareTag("Monster"))
            {
                if (omoteSeeSaw.Left.CurObject.TryGetComponent<PlayerController>(out var player) && player.Change)
                {
                    var monster = omoteSeeSaw.Right.CurObject;
                    var x1 = monster.transform.position.x;
                    var y1 = monster.transform.position.y;
                    if (monster.TryGetComponent<Rigidbody2D>(out var rigidbody2D))
                        DestroyImmediate(rigidbody2D);
                    if (monster.TryGetComponent<Collider2D>(out var collider2D))
                        DestroyImmediate(collider2D);

                    monster.transform.DOMove(point.transform.position, 1f).ToUniTask().ContinueWith(() =>
                    {
                        monster.transform.DOMove(deadzone.transform.position, 1f).ToUniTask().ContinueWith(() =>
                        {
                            monster.SetActive(false);
                        }).Forget();
                    }).Forget();
                    omoteSeeSaw.ChangeRUpMode();
                    urateSeeSaw.ChangeRUpMode();
                }
            }
        }
        else if ((omoteSeeSaw.Left.CurObject || urateSeeSaw.Left.CurObject) && !omoteSeeSaw.Right.CurObject && !urateSeeSaw.Right.CurObject)
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
        //else if (!urateSeeSaw.Left.CurObject && !omoteSeeSaw.Left.CurObject && !omoteSeeSaw.Right.CurObject && !urateSeeSaw.Right.CurObject)
        //{
        //    omoteSeeSaw.ChangeLUpMode();
        //    urateSeeSaw.ChangeLUpMode();
        //}
    }
}
