using System;
using TMPro;
using UnityEngine;

public class LvlFailed : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    private float _timer;
    private float _timer2;

    private void Start()
    {
        _timer = 5f;
        Invoke("StartNewLvl", 5);
    }
    void FixedUpdate()
    {
        _timer -= Time.deltaTime;
        _timer2 = (float)Math.Round(_timer);
        _timerText.text = _timer2.ToString();
    }
}
