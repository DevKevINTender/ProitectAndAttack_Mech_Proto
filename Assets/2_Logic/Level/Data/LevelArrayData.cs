using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[JsonObject(MemberSerialization.OptIn)]
[CreateAssetMenu(fileName = "LevelSOData", menuName = "ScriptableObjects/LevelSOData", order = 1)]
public class LevelArrayData: ScriptableObject
{
    public List<LevelData> LevelList = new List<LevelData>();
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int CurrentLevelID = 0;
}

[Serializable]
[JsonObject(MemberSerialization.OptIn)]
public class LevelData
{
    public int Id;
    [JsonIgnore]
    public List<EnemySetData> EnemySetsList = new List<EnemySetData>();
    [JsonSerialize]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool IsComplete;
}

[Serializable]
public class EnemySetData
{
    public EnemyData[] EnemySet = new EnemyData[4];
}
[Serializable]
public class EnemyData
{
    public EnemyType EnemyType;
}

public enum EnemyType
{
    Empty,
    Defautl
}