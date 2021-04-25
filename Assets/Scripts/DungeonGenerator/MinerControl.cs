using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerControl : MonoBehaviour
{
    public float playerMoveSpeed;
    void Update()
    {
        MinerMove();
    }

    void MinerMove() 
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime, 0);
    }
}