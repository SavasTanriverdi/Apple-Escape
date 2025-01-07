using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        transform.DOMoveY(transform.position.y + 1, 0.5f).SetLoops(-1,LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
}
