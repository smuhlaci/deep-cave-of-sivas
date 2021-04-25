using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerControl : MonoBehaviour
{
    public float playerMoveSpeed;
    [SerializeField] private GameObject _trigger;
    void Update()
    {
        MinerMove(); 
        Debug.Log("x: " + (int)transform.position.x + ", y: " + (int)transform.position.y);
    }

    void MinerMove()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime, 0);
    }
}
