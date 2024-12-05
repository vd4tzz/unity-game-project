using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform mainCamera;
    public Transform MidBG;
    public Transform SideBG;
    public float length;

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra và cập nhật vị trí của nền dựa trên vị trí camera
        if (mainCamera.position.x > MidBG.position.x)
        {
            UpdateBackgroundPosition(Vector3.right);
        }
        else if (mainCamera.position.x < MidBG.position.x)
        {
            UpdateBackgroundPosition(Vector3.left);
        }
    }

    void UpdateBackgroundPosition(Vector3 direction)
    {
        SideBG.position = MidBG.position + direction * length;
        Transform temp = MidBG;
        MidBG = SideBG;
        SideBG = temp;
    }
}
