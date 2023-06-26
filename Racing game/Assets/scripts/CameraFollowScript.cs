using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour

    public GameObject atachedVehcile;
    private GameObject CameraFolder;
    private Transform[]camLocations;
    private float loacationIndicator = 2;

{
    // Start is called before the first frame update
    void Start()
    {
        atachedVehcile = GameObject.FindGameObjectWithTag("Player");
        CameraFolder = atachedVehcile.transform.Find("CAMERA").gameObject;
        camLocation = CameraFolder.GetComponetsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
