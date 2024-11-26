using System;
using Zenject;

public class LevelArrayDataManager
{
    private const string Key = "LevelKey";
    private ISOStorageService _storageService;
    private LevelArrayData _levelArrayData;


    [Inject]
    public LevelArrayDataManager(ISOStorageService sOStorageService)
    {
        _storageService = sOStorageService;
        _levelArrayData = _storageService.GetSOByType<LevelArrayData>();
        LoadData();
    }

    public LevelArrayData GetLevelArrayData() => _levelArrayData;

    public void LoadData()
    {
        foreach (var item in _levelArrayData.LevelList)
        {
            SaveLoader.LoadItem(Key + item.Id, item);
        }
        SaveLoader.LoadItem(Key, _levelArrayData);
    }

    public void SaveData()
    {
        foreach (var item in _levelArrayData.LevelList)
        {
            SaveLoader.SaveItem(Key + item.Id, item);
        }
        SaveLoader.SaveItem(Key, _levelArrayData);
    }

    public LevelData GetCurrentLevel() => _levelArrayData.LevelList[_levelArrayData.CurrentLevelID];

    public int GetNextLevelID()
    {
        return _levelArrayData.CurrentLevelID+1 < _levelArrayData.LevelList.Count ? _levelArrayData.CurrentLevelID+1 : _levelArrayData.CurrentLevelID;
    }

    public void UpdateNextLevel()
    {
        _levelArrayData.CurrentLevelID = GetNextLevelID();
        SaveData();
    }
}
