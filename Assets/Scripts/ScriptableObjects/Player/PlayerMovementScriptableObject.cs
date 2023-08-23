using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementScriptableObject", menuName = "Scriptables/PlayerMovementScriptableObject")]
public class PlayerMovementScriptableObject : ScriptableObject
{
    public float speed;
    public float jumpPower;
}
