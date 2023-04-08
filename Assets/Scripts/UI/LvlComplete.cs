using TMPro;
using UnityEngine;

public class LvlComplete : MonoBehaviour
{
    [SerializeField] private TMP_Text _LvlText;
    void Start()
    {
        _LvlText.text = Player._lvlNumber.ToString();
    }
}
