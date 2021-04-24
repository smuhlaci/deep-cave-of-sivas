using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "UnnamedDialog", menuName = "Create Dialog")]
public class Dialog : ScriptableObject
{
    [FormerlySerializedAs("message")] public string[] Messages;

    public List<string> ActionName;
}
