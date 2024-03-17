using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float _xMoveSpeed; // �¿� �̵��ӵ�
    [SerializeField] private float _xDelta = 2; // �̵� ����
    private float _xStartPosition; // x ���� ��ġ

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
