using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    public static int _lvlNumber;
    public static bool _tutorialComplete;

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweenShoot;
    private float _timeAfterShoot;
    [ContextMenuItem("Shoot_test", "Shoot")]
    [SerializeField] private float _backForce;

    public static int _playerHealth;
    public static Action onTakeDamage;
    public static bool shootOnTouch;

    [SerializeField] private AudioSource _shootSound;

    private void Awake()
    {
        LvlManager.shootOn = true;
        LoadPlayer();
    }
    private void Start()
    {
        shootOnTouch = false;
        _playerHealth = 3;
    }
    private void OnEnable()
    {
        onTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        onTakeDamage -= TakeDamage;
    }
    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;
        if (shootOnTouch && LvlManager.shootOn)
        {
            Invoke("ShootDelay", 0.1f);
        }
    }
    private void ShootDelay()
    {
        if (TowersRotator.towersMove == false)
        {
            if (_timeAfterShoot > _delayBetweenShoot)
            {
                Shoot();
                _timeAfterShoot = 0;
            }
        }
    }
    public void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
        ShootAnimation();
        _shootSound.Play();
    }
    private void ShootAnimation()
    {
        transform.DOMoveZ(transform.position.z - _backForce, _delayBetweenShoot / 2).SetLoops(2, LoopType.Yoyo);
    }
    public void TakeDamage()
    {
        _playerHealth--;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.Load();

        Player._lvlNumber = data._level;
        Player._tutorialComplete = data._tutorialWasEnd;
    }
}