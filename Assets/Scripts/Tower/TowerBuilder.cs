using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Target _target;
    [SerializeField] private Color[] _colors;
    int _targetNumber;
    //int _bonusTarget;

    private List<Target> _targets;
    private void Awake()
    {
        TowerSizeGenerator();
        //_bonusTarget = Random.Range(1, _towerSize*5);
    }
    public List<Target> Build() 
    {
        {
            _targets = new List<Target>();

            Transform currentPoint = _buildPoint;

            for (int i = 0; i < _towerSize; i++)
            {
                Target newTarget = BuildTarget(currentPoint);
                _targets.Add(newTarget);
                currentPoint = newTarget.transform;
                newTarget.transform.gameObject.name = "Target";

                _targetNumber++;
                _targetIsEven(_targetNumber);
                if (_targetIsEven(_targetNumber))
                {
                    newTarget.SetColor(_colors[(0)]);
                }
                else
                {
                    newTarget.SetColor(_colors[(1)]);
                    /*if (_targetNumber == _bonusTarget)
                    {
                       newTarget.SetColor(_colors[(2)]);
                       newTarget.transform.gameObject.name = "BonusTarget";
                    }*/
                }
            }
        }
        return _targets;
    }
    private bool _targetIsEven(int number)
    {
        return number % 2 == 0;
    }
    private Target BuildTarget(Transform currentBuildPoint)
    {
        return Instantiate(_target, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint); 
    }
    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y /2 + _target.transform.localScale.y/2, _buildPoint.position.z);
    }
    private void TowerSizeGenerator()
    {
        if(Player._lvlNumber <= 10)
        {
            _towerSize = Player._lvlNumber + Random.Range(4, 10);
        }
        if (Player._lvlNumber > 10 && Player._lvlNumber <= 50)
        {
            _towerSize = 15 + Random.Range(3, 15);
        }
        if(Player._lvlNumber > 50)
        {
            _towerSize = 30 + Random.Range(4, 20);
        }
    }
}
