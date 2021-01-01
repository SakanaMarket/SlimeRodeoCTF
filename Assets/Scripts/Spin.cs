using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField] private float RotateSpeed = 5f;
    [SerializeField] private float Radius = 0.1f;

    [SerializeField] private Vector2 _centre;
    [SerializeField] private float _angle;
    [SerializeField] private bool counter;
    [SerializeField] private bool counter2;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
    
        if (counter == true)
        {
            offset.x = -offset.x;
        }
        if (counter2 == true)
        {
            offset.y = -offset.y;
        }
       
        
        transform.position = _centre + offset;
    }
}
