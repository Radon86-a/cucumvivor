using System.Net.Sockets;
using UnityEngine;

[CreateAssetMenu(fileName = "pleyerData", menuName = "Scriptable Objects/pleyerData")]
public class pleyerData : ScriptableObject
{
    public long pleyer_max_HP;
    public long pleyer_attack;
    public float pleyer_speed;
    public float pleyer_attack_freq;
}
