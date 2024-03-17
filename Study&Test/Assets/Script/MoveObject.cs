using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float _xMoveSpeed; // 좌우 이동속도
    [SerializeField] private float _xDelta = 2; // 이동 범위
    private float _xStartPosition; // x 시작 위치

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToX();
    }

    public void MoveToX()
    {
        float y = _xStartPosition + _xDelta * Mathf.Sin(Time.time * _xMoveSpeed);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
