using System;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float speed;
    [SerializeField] private float tapForce = 10;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotationZ;
    [SerializeField] private float minRotationZ;

    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, minRotationZ);
        
        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(speed, 0);

            transform.rotation = _maxRotation;
            
            _rigidbody2D.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, rotationSpeed * Time.deltaTime);
    }


    public void ResetBird()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody2D.velocity = Vector2.zero;
    }
    
}
