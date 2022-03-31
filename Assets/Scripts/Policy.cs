using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomObj", menuName = "Policy", order = 1)]
public class Policy : ScriptableObject
{
    public string PolicyName;
    public string PolicyDesc;
    public bool policyApproval;
}
