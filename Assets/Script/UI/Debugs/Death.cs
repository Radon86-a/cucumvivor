using UnityEngine;

public class Death : MonoBehaviour
{
    public Player player;
    public void doDeath()
    {
        player.HP = 0;
    }
}
