using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float xRotate, yRotate, xRotateMove, yRotateMove; 
    public float rotateSpeed = 500.0f;
    public float moveSpeed = 300.0f; // 이동 속도 조절

    void Update()
    {
        if(Input.GetMouseButton(0)) // 클릭한 경우
        {
            xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

            yRotate = transform.eulerAngles.y + yRotateMove;
            //xRotate = transform.eulerAngles.x + xRotateMove; 
            xRotate = xRotate + xRotateMove;
            
            xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정
            Debug.Log(xRotate);
            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        }
    }
    public void MoveForward()
    {
        // 카메라를 로컬 z축 방향으로 이동
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }

    public void MoveBackward()
    {
        // 카메라를 로컬 z축 반대 방향으로 이동
        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }
}
