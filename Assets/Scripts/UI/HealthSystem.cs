using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] GameObject Hearth1;
    [SerializeField] GameObject Hearth2;
    [SerializeField] GameObject Hearth3;
    private void OnEnable()
    {
        Player.onTakeDamage += OnHealthUpdate;
        Hearth1.SetActive(true);
        Hearth2.SetActive(true);
        Hearth3.SetActive(true);
    }
    private void OnDisable()
    {
        Player.onTakeDamage -= OnHealthUpdate;
    }
    private void OnHealthUpdate()
    {
        switch (Player._playerHealth)
        {
            case 0:
                Hearth1.SetActive(false);
                break;
            case 1:
                Hearth1.SetActive(true);
                Hearth2.SetActive(false);
                break;
            case 2:
                Hearth1.SetActive(true);
                Hearth2.SetActive(true);
                Hearth3.SetActive(false);
                break;
        }
    }
}
