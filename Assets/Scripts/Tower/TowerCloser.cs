using UnityEngine;
using DG.Tweening;

public class TowerCloser : MonoBehaviour
{
    [SerializeField] GameObject towerCloser1;
    [SerializeField] GameObject towerCloser2;
    [SerializeField] GameObject towerCloser3;
    [SerializeField] Material towerCloser1Material;
    [SerializeField] Material towerCloser2Material;
    [SerializeField] Material towerCloser3Material;
    [SerializeField] private float _goUpDuretion;
    [SerializeField] private float _closeDuretion;

    private float timer;
    private short goUpDownController;
    private float delayBetweenClose;

    private int towerNumber;
    private void Start()
    {
        towerCloser1Material.DOColor(new Color32(47, 3, 74, 225), 0.1f);
        towerCloser2Material.DOColor(new Color32(47, 3, 74, 225), 0.1f);
        towerCloser3Material.DOColor(new Color32(47, 3, 74, 225), 0.1f);

        delayBetweenClose = 3.2f;
        goUpDownController = 1;
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > delayBetweenClose && goUpDownController == 1)
        {
            towerNumber = Random.Range(1, 4);
            GoUp(towerNumber);
            goUpDownController = 2;
            timer = Random.Range(-3, 0);
        }
        if(timer > delayBetweenClose && goUpDownController == 2)
        {
            GoDown(towerNumber);
            goUpDownController = 1;
            timer = Random.Range(-7, -2);
        }
    }
    public void GoUp(int towerNumber)
    {
        switch (towerNumber)
        {
            case 1:
                towerCloser1.transform.DOMoveY(transform.position.y + 1.05f, _goUpDuretion);
                towerCloser1Material.DOColor(new Color32(248, 6, 204, 225), _goUpDuretion);
                break;
            case 2:
                towerCloser2.transform.DOMoveY(transform.position.y + 1.05f, _goUpDuretion);
                towerCloser2Material.DOColor(new Color32(248, 6, 204, 225), _goUpDuretion);
                break;
            case 3:
                towerCloser3.transform.DOMoveY(transform.position.y + 1.05f, _goUpDuretion);
                towerCloser3Material.DOColor(new Color32(248, 6, 204, 225), _goUpDuretion);
                break;
        }
    }
    public void GoDown(int towerNumber)
    {
        switch (towerNumber)
        {
            case 1:
                towerCloser1.transform.DOMoveY(transform.position.y - 1.05f, _goUpDuretion);
                towerCloser1Material.DOColor(new Color32(47, 3, 74, 225), _goUpDuretion);
                break;
            case 2:
                towerCloser2.transform.DOMoveY(transform.position.y - 1.05f, _goUpDuretion);
                towerCloser2Material.DOColor(new Color32(47, 3, 74, 225), _goUpDuretion);
                break;
            case 3:
                towerCloser3.transform.DOMoveY(transform.position.y - 1.05f, _goUpDuretion);
                towerCloser3Material.DOColor(new Color32(47, 3, 74, 225), _goUpDuretion);
                break;
        }
    }
}