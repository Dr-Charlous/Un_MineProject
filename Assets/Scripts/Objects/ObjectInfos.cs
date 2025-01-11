using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects",menuName = "Objetcs")]
public class ObjectInfos : ScriptableObject
{
    public ObjectType Type;

    public enum ObjectType
    {
        Key,
        Tool,
        Change
    }
}
