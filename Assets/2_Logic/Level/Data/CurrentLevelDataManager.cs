using UniRx;

public class CurrentLevelDataManager
{
    public ReactiveProperty<int> CurrentSetID = new ReactiveProperty<int>(0);

    public void ChangeCurrentSetID(int newSetId)
    {
        CurrentSetID.Value = newSetId;
    }
}