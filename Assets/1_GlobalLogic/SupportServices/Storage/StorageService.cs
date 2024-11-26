using System.Collections.Generic;
using UnityEngine;

public interface ISOStorageService
{
    public T GetSOByType<T>() where T : ScriptableObject;
    public List<T> GetSOsByType<T>() where T : ScriptableObject;
}
public interface IPrefabStorageService
{
    public GameObject GetPrefabByType<T>();
}

public class StorageService : IPrefabStorageService, ISOStorageService
{
    private List<GameObject> prefabs = new List<GameObject>();
    private List<ScriptableObject> ScriptableObjects = new List<ScriptableObject>();
    private string _prefabPath = "Prefabs/";
    private string _soPath = "SO/";

    public StorageService()
    {
        prefabs.AddRange(LoadPrefabsFromPath(_prefabPath));
        ScriptableObjects.AddRange(LoadSOFromPath(_soPath));
    }

    private GameObject[] LoadPrefabsFromPath(string path)
    {
        // ��������� ��� ������� (�������) � ��������� ����������
        GameObject[] objects = Resources.LoadAll<GameObject>(path);
        return objects;
    }

    private ScriptableObject[] LoadSOFromPath(string path)
    {
        // ��������� ��� ������� (SO) � ��������� ����������
        ScriptableObject[] SOs = Resources.LoadAll<ScriptableObject>(path);
        return SOs;
    }


    public GameObject GetPrefabByType<T>()
    {
        GameObject obj = null;

        foreach (GameObject item in prefabs)
        {
            // ���������, ���� �� � �������� ������� ��������� � �������� ������
            Component targetComponent = item.GetComponent(typeof(T).Name);

            if (targetComponent != null) obj = item;
        }

        if (obj == null) Debug.LogError($"Not found Prefabs with type {typeof(T).Name} in {_prefabPath}");
        return obj;
    }

    public T GetSOByType<T>() where T : ScriptableObject
    {
        T obj = null;
        foreach (ScriptableObject item in ScriptableObjects)
        {
            if (item.GetType() == typeof(T))
                obj = (T)item;
        }
        if (obj == null) Debug.LogError($"Not found ScriptableObject with type {typeof(T).Name} in {_prefabPath}");
        return obj;
    }

    public List<T> GetSOsByType<T>() where T : ScriptableObject
    {
        List<T> objs = null;
        foreach (ScriptableObject item in ScriptableObjects)
        {
            if (item.GetType() == typeof(T))
                objs.Add((T)item);
        }
        if (objs == null) Debug.LogError($"Not found ScriptableObjects with type {typeof(T).Name} in {_prefabPath}");
        return objs;
    }

}
