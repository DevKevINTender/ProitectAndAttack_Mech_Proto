using UnityEngine.UI;
using UnityEngine;

public class HpFillComponent: MonoBehaviour
{
    public Image hpFill;
    public HpComponent _hpComponent;

    public void Update()
    {
        hpFill.fillAmount = _hpComponent.GetFillValue();
    }
}