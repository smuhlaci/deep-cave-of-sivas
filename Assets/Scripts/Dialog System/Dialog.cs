using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "UnnamedDialog", menuName = "Create Dialog")]
public class Dialog : ScriptableObject
{
    [FormerlySerializedAs("message")] public string[] Messages;

    public List<string> ActionName;
}
