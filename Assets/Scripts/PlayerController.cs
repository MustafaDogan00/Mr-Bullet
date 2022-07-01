using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 100, _bulletSpeed = 100;

    private Transform _handPos;
    private Transform _firePos1,_firePos2;

    private LineRenderer _lineRenderer;

    [SerializeField] GameObject _bullet;

    void Awake()
    {
        _handPos = GameObject.FindGameObjectWithTag("LeftArm").transform;
        _firePos1 = GameObject.FindGameObjectWithTag("FirePos1").transform;
        _firePos2 = GameObject.FindGameObjectWithTag("FirePos2").transform;
        _lineRenderer = GameObject.FindGameObjectWithTag("Gun").GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;       
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Aim();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }

    }

    void Aim()
    {
        Vector2 direction=Camera.main.ScreenToWorldPoint(Input.mousePosition)-_handPos.position;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg+90;
        Quaternion rotation=Quaternion.AngleAxis(angle,Vector3.forward);
        _handPos.rotation = Quaternion.Slerp(transform.rotation,rotation,_rotateSpeed*Time.deltaTime);   

        _lineRenderer.enabled=true;
        _lineRenderer.SetPosition(0, _firePos1.position);
        _lineRenderer.SetPosition(1, _firePos2.position);
    }
     void Shoot()
    {
        _lineRenderer.enabled = false;

        GameObject g=Instantiate(_bullet,_firePos1.position,Quaternion.identity);
        if (transform.localScale.x > 0)
            g.GetComponent<Rigidbody2D>().AddForce(_firePos1.right * _bulletSpeed, ForceMode2D.Impulse);
        else
            g.GetComponent<Rigidbody2D>().AddForce(-_firePos1.right * _bulletSpeed, ForceMode2D.Impulse);
        Destroy(g, 2);

    }


}
