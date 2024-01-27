using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    public enum Mode
    {
        LeftUp,
        RightUp,
        TransitionToLeftUp,
        TransitionToRightUp,
    }

    private Mode curMode = Mode.LeftUp;

    [SerializeField]
    private GameObject square;

    [SerializeField]
    private float circleLeftUpHeight, circleRightDownHeight, circleRightUpHeight, circleLeftDownHeight;

    [SerializeField]
    private float duration;

    [SerializeField]
    private SeesawDeteced left, right;

    [SerializeField]
    private float squareLeftUpHeight, squareRightUpHeight;

    [SerializeField]
    private Quaternion squareLeftUpRotation, squareRightUpRotation;

    public GameObject Square => square;

    public SeesawDeteced Left => left;

    public SeesawDeteced Right => right;

    private Tweener curTweener;

    public void ChangeRUpMode(Action onComplete = null)
    {
        if (curMode != Mode.LeftUp) return;
        curTweener?.Kill();
        curTweener = DOTween.To(progress =>
        {
            curMode = Mode.TransitionToLeftUp;
            //left.collider2DCircle.enabled = false;
            //right.collider2DCircle.enabled = false;

            var localPosition = Square.transform.localPosition;
            localPosition.y = Mathf.Lerp(squareLeftUpHeight, squareRightUpHeight, progress);
            Square.transform.localPosition = localPosition;

            var localRotation = Square.transform.localRotation;
            localRotation = Quaternion.Lerp(squareLeftUpRotation, squareRightUpRotation, progress);
            Square.transform.localRotation = localRotation;

            var leftLocalPosition = Left.transform.localPosition;
            leftLocalPosition.y = Mathf.Lerp(circleLeftUpHeight, circleLeftDownHeight, progress);
            Left.transform.localPosition = leftLocalPosition;

            var rightLocalPosition = Right.transform.localPosition;
            rightLocalPosition.y = Mathf.Lerp(circleRightDownHeight, circleRightUpHeight, progress);
            Right.transform.localPosition = rightLocalPosition;
        }, 0, 1, duration).OnComplete(() =>
        {
            //left.collider2DCircle.enabled = true;
            //right.collider2DCircle.enabled = true;
            curMode = Mode.RightUp;

            onComplete?.Invoke();
        });
    }

    public void ChangeLUpMode(Action onComplete = null)
    {
        if (curMode != Mode.RightUp) return;
        curTweener?.Kill();

        curTweener = DOTween.To(progress =>
        {
            curMode = Mode.TransitionToRightUp;
            //left.collider2DCircle.enabled = false;
            //right.collider2DCircle.enabled = false;

            var localPosition = Square.transform.localPosition;
            localPosition.y = Mathf.Lerp(squareRightUpHeight, squareLeftUpHeight, progress);
            Square.transform.localPosition = localPosition;

            var localRotation = Square.transform.localRotation;
            localRotation = Quaternion.Lerp(squareRightUpRotation, squareLeftUpRotation, progress);
            Square.transform.localRotation = localRotation;

            var leftLocalPosition = Left.transform.localPosition;
            leftLocalPosition.y = Mathf.Lerp(circleLeftDownHeight, circleLeftUpHeight, progress);
            Left.transform.localPosition = leftLocalPosition;

            var rightLocalPosition = Right.transform.localPosition;
            rightLocalPosition.y = Mathf.Lerp(circleRightUpHeight, circleRightDownHeight, progress);
            Right.transform.localPosition = rightLocalPosition;
        }, 0, 1, duration).OnComplete(() =>
        {
            //left.collider2DCircle.enabled = true;
            //right.collider2DCircle.enabled = true;
            curMode = Mode.LeftUp;

            onComplete?.Invoke();
        });
    }
}
