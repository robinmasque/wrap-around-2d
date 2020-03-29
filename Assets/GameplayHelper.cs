using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayHelper : MonoBehaviour
{
    public GameObject WorldExtents;
    public GameObject ScreenExtents;

    public static Bounds WorldBounds;
    public static Vector3 WorldScreenSize;
    
    void Awake()
    {
        WorldBounds = WorldExtents.GetComponent<Collider>().bounds;
        WorldScreenSize = ScreenExtents.GetComponent<Collider>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
