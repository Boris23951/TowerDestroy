using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class ObstacaleRotator : MonoBehaviour
{
    [SerializeField] private float _animationDuretion; 
    private void Start()
    {
        _animationDuretion = Random.Range(7,11);
        transform.DORotate(new Vector3(0,360,0), _animationDuretion, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Yoyo);
    }
}
