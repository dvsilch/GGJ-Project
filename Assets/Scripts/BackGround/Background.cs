using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Vector3 movementScale = Vector3.one;

    private Transform _camera;

    private void Awake()
    {
        _camera = Camera.main!.transform;
    }

    /**
     * 如果启用了 Behaviour，则每帧调用 LateUpdate。
     * LateUpdate 在调用所有 Update 函数后调用。 这对于安排脚本的执行顺序很有用。
     *      例如，跟随摄像机应始终在 LateUpdate 中实现， 因为它跟踪的对象可能已在 Update 中发生移动。
     */
    private void LateUpdate()
    {
        // Vector3.Scale 将两个向量的分量相乘
        transform.position = Vector3.Scale(_camera.position, movementScale);
    }
}
