using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string item_name;
    public string item_detail;
    public long item_effect_object;
    public long item_effect_amount;
    public Sprite weapon_skin;
}
