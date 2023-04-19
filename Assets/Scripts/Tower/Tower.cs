using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Target> _targets;

    public event UnityAction<int> SizeUpdated;
    public UnityEvent TowerSizeZero;

    [SerializeField] AudioSource _towerComplete;

    public UnityEvent<int> TowerSizeOutput;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _targets = _towerBuilder.Build(); 

        foreach(var target in _targets)
        {
            target.BulletHit += OnBulletHit;
        }
        SizeUpdated?.Invoke(_targets.Count);
        TowerSizeOutput?.Invoke(_targets.Count);
    }
    private void OnBulletHit(Target HitedTarget)
    {
        HitedTarget.BulletHit -= OnBulletHit;

        _targets.Remove(HitedTarget);

        foreach(var target in _targets)
        {
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y - target.transform.localScale.y, target.transform.position.z);
        }
        SizeUpdated?.Invoke(_targets.Count);
        if (_targets.Count == 0)
        {
            _towerComplete.Play();
            TowerSizeZero.Invoke();
        }
    }
}
