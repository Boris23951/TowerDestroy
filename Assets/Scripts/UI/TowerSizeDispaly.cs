using TMPro;
using UnityEngine;

public class TowerSizeDispaly : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.SizeUpdated += OnsizeUpdate;
    }
    private void OnDisable()
    {
        _tower.SizeUpdated -= OnsizeUpdate;
    }
    private void OnsizeUpdate(int size)
    {
        _sizeView.text = size.ToString();
    }
}
