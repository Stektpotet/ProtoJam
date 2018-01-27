using UnityEngine;
using System;
/// <summary>
/// All scripted behaviour that needs access to internal components should inherit from this.
/// </summary>
public static partial class ExtensionMethods
{
    /// <summary>
    /// Requires a component from the gameobject currently beeing scripted
    /// without the need for constant use of GetComponent or messy inspectors
    /// using multiple [SerializeField]-attributes.
    /// 
    /// Called in Awake()
    /// </summary>
    public static T RequireComponent<T>(this Component behaviour) where T : Component
    {
        T component = behaviour.GetComponent<T>();
        if (component == null) { component = behaviour.gameObject.AddComponent<T>(); }
        return component;
    }

    /// <summary>
    /// Require a component with a specific setup, e.g. change the component properties
    /// </summary>
    public static T RequireComponent<T>(this Component behaviour, Action<T> setup) where T : Component
    {
        T component = behaviour.GetComponent<T>();
        if (component == null) { component = behaviour.gameObject.AddComponent<T>(); }
        setup(component);
        return component;
    }
}