using UnityEngine;

[CreateAssetMenu(fileName = "itemData", menuName = "Scriptable Objects/itemData")]
public class itemData : ScriptableObject
{
    public Items[] items;
}

[System.Serializable]
public struct Items
{
    public long item_id;
    public string item_name;
    public long status_id;
    public long increment;
}