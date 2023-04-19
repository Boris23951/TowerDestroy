using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    public static Action onBonusActive;
    public static Action onMoneyChange;
    private Vector3 _moveDirection;

    [SerializeField] AudioSource _obstacaleTrigger;

    private void Start()
    {
        _moveDirection = Vector3.forward;
    }
    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Target target))
        {
            target.Break();
            Destroy(gameObject);
            /*if (other.gameObject.name == "BonusTarget")
            {
                BonusDoubleDamageActive();
            }*/
        }
        if(other.TryGetComponent(out Obstacale obstacale))
        {
            Player.onTakeDamage.Invoke();
            Bounce();
            _obstacaleTrigger.Play();
        }
        if (other.gameObject.tag == "BlockBullet")
        {
            Destroy(gameObject);
        }
    }
    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, 1), _bounceRadius); 
    }
}
