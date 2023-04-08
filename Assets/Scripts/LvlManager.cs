using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;

public class LvlManager : MonoBehaviour
{
    private bool tower1Empty;
    private bool tower2Empty;
    private bool tower3Empty;
    private GameObject towerOff1;
    private GameObject towerOff2;
    private GameObject towerOff3;
    [SerializeField] Material towerOff1Material;
    [SerializeField] Material towerOff2Material;
    [SerializeField] Material towerOff3Material;

    public UnityEvent Save;
    [SerializeField] private GameObject ObjectFailedLvl;
    [SerializeField] private GameObject ObjectCompleteLvl;

    [SerializeField] private GameObject leftButtion;
    [SerializeField] private GameObject middleButtion;
    [SerializeField] private GameObject rightButtion;
    public static bool shootOn;
    private bool bonusRound;

    private void Awake()
    {
        towerOff1 = GameObject.Find("TowerOff1");
        towerOff2 = GameObject.Find("TowerOff2");
        towerOff3 = GameObject.Find("TowerOff3");
    }
    private void Start()
    {
        ObjectFailedLvl.SetActive(false);
        ObjectCompleteLvl.SetActive(false);

        towerOff1.SetActive(false);
        towerOff2.SetActive(false);
        towerOff3.SetActive(false);

        tower1Empty = false;
        tower2Empty = false;
        tower3Empty = false;

        towerOff1Material.DOColor(new Color32(47, 3, 74, 0), 0.1f);
        towerOff2Material.DOColor(new Color32(47, 3, 74, 0), 0.1f);
        towerOff3Material.DOColor(new Color32(47, 3, 74, 0), 0.1f);
    }
    private void OnEnable()
    {
        Player.onTakeDamage += PlayerHealthManager;
    }
    private void OnDisable()
    {
        Player.onTakeDamage -= PlayerHealthManager;
    }
    public void Rewarded(int id)
    {
        if(id == 0)
        {
            Player.shootOnTouch = false;
            Player._playerHealth = +2;
            Player.onTakeDamage();
            ObjectFailedLvl.SetActive(false);
            OnGameplay(true);
            bonusRound = true;
            shootOn = true;
        }
    }
    private void PlayerHealthManager()
    {
        if(Player._playerHealth == 0)
        {
            RestartLvl(false);
        }
    }
    #region IndividulTowerSizeChecking
    public void Tower1SizeCheck()
    {
        tower1Empty = true;
        AllTowerSizeCheck();
        TowerOff(1);
    }
    public void Tower2SizeCheck()
    {
        tower2Empty = true;
        AllTowerSizeCheck();
        TowerOff(2);
    }
    public void Tower3SizeCheck()
    {
        tower3Empty = true;
        AllTowerSizeCheck();
        TowerOff(3);
    }
    #endregion
    private void AllTowerSizeCheck()
    {
        if (tower1Empty && tower2Empty && tower3Empty)
        {
            RestartLvl(true);
        }
    }
    public void RestartLvl(bool _LvlComplete)
    {
        OnGameplay(false);
        bonusRound = false;
        if(_LvlComplete == false)
        {
            ObjectFailedLvl.SetActive(true);
            Invoke("LoadScene0", 5f);
        }
        else
        {
            ObjectCompleteLvl.SetActive(true);
            Player._lvlNumber++;
            Invoke("LoadScene0", 1f);
        }
        shootOn = false;
    }
    private void LoadScene0()
    {
        Save.Invoke();
        if(bonusRound)
        {

        }
        else
        {
            SceneManager.LoadScene("_0Scene");
        }
    }
    private void TowerOff(int TowerNum)
    {
        switch (TowerNum)
        {
            case 1:
                towerOff1.SetActive(true);
                towerOff1Material.DOColor(new Color32(47, 3, 74, 255), 1f);
                break;
            case 2:
                towerOff2.SetActive(true);
                towerOff2Material.DOColor(new Color32(47, 3, 74, 255), 1f);
                break;
            case 3:
                towerOff3.SetActive(true);
                towerOff3Material.DOColor(new Color32(47, 3, 74, 255), 1f);
                break;
        }
    }
    public void OnGameplay(bool gamePlayOn)
    {
        if (gamePlayOn)
        {
            TowersRotator.towersMove = false;
            leftButtion.SetActive(true);
            middleButtion.SetActive(true);
            rightButtion.SetActive(true);
        }
        else
        {
            TowersRotator.towersMove = true;
            leftButtion.SetActive(false);
            middleButtion.SetActive(false);
            rightButtion.SetActive(false);
        }
    }
}
