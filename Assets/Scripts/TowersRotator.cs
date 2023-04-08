using UnityEngine;
using DG.Tweening;

public class TowersRotator : MonoBehaviour
{
    [SerializeField] GameObject towerRotationPoint;
    [SerializeField] private float _rotationDuretion;

    private float _delayBetweenSwipe;
    private float _timeAfterSwipe;

    private bool leftKey;
    private bool rightKey;
    public static bool towersMove;//задержка и - стрельба

    [SerializeField] GameObject playerGroundRotationPoint;//40 on 120

    void Start()
    {
        _delayBetweenSwipe = _rotationDuretion + 0.1f;
        _timeAfterSwipe = _delayBetweenSwipe;
        leftKey = false; 
    }
    public void LeftKey()
    {
        leftKey = true;
    }
    public void RightKey()
    {
        rightKey = true;
    }
    private void Update()
    {
        _timeAfterSwipe += Time.deltaTime;
        if (_timeAfterSwipe > _delayBetweenSwipe)
        {
            towersMove = false;
            if (leftKey)
            {
                _timeAfterSwipe = 0;
                TurnLeft();
                leftKey = false;
            }
            if (rightKey)
            {
                _timeAfterSwipe = 0;
                TurnRight();
                rightKey = false;
            }
        }
    }
    public void TurnLeft()
    {
        towersMove = true;
        towerRotationPoint.transform.DORotate(new Vector3(0, -120, 0), _rotationDuretion, RotateMode.LocalAxisAdd);
        playerGroundRotationPoint.transform.DORotate(new Vector3(0, 40, 0), _rotationDuretion, RotateMode.LocalAxisAdd);
    }
    public void TurnRight()
    {
        towersMove = true;
        towerRotationPoint.transform.DORotate(new Vector3(0, 120, 0), _rotationDuretion, RotateMode.LocalAxisAdd);
        playerGroundRotationPoint.transform.DORotate(new Vector3(0, -40, 0), _rotationDuretion, RotateMode.LocalAxisAdd);
    }
}
