using UnityEngine;
using Zenject;

public class UnitMovePointView: MonoBehaviour
{
    public GameObject NDirection; 
    public GameObject SDirection; 
    public GameObject WDirection; 
    public GameObject EDirection;

    public GameObject ActiveStatusObj;
    public GameObject DeactiveStatusObj;
    public GameObject DirectionObj;

    public void Activate(UnitMovePointMarker marker)
    {
        NDirection.SetActive(marker.N != null);
        SDirection.SetActive(marker.S != null);
        WDirection.SetActive(marker.W != null);
        EDirection.SetActive(marker.E != null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<UnitMoveComponent>())
        {
            Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<UnitMoveComponent>())
        {
            Hide();
        }
    }

    private void Show()
    {
        DirectionObj.SetActive(true);
        DeactiveStatusObj.SetActive(true);
        ActiveStatusObj.SetActive(false);
    }


    private void Hide()
    {
        DirectionObj.SetActive(false);
        DeactiveStatusObj.SetActive(false);
        ActiveStatusObj.SetActive(true);

    }
}

public class UnitMovePointViewService
{
    [Inject] private IViewFabric _viewFabric;
    private UnitMovePointMarker _marker;
    private UnitMovePointView _view;
    public void Activete(UnitMovePointMarker marker)
    {
        _marker = marker;
        _view = _viewFabric.Init<UnitMovePointView>(marker.transform);
        _view.Activate(marker);
    }
}
