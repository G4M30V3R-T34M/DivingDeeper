using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementScriptableObject", menuName = "Scriptables/PlayerMovementScriptableObject")]
public class PlayerMovementScriptableObject : ScriptableObject
{
    public float speed;
    public float jumpPower;
    public float fearSpeed;
    public float runAwayDistance;
}
