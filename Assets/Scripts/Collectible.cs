using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    void Start()
    {
        StartAnimation();
    }

    void Update()
    {
        
    }
    
    private void StartAnimation()
    {
        transform.DORotate(new Vector3(0f, 360f, 0f), 10f, RotateMode.Fast)
            .SetRelative(true)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }
}
