using System;
using UnityEngine;


using Sirenix.OdinInspector;
using Sirenix.Utilities;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class EnumMaskAttribute : PropertyAttribute
{
    public bool alwaysFoldOut = true;
    public EnumMaskLayout layout = EnumMaskLayout.Vertical;
}

public enum EnumMaskLayout
{
    Vertical,
    Horizontal
}