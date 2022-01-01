using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballInHole : MonoBehaviour
{
    public int hole_Number;
    public string goto_Hole_Name;

    void OnTriggerEnter (Collider col)
    {
        Debug.Log("Collider Detected");
        if (col.gameObject.tag == "golfBall")
        {
            Debug.Log("Golf Ball In the HOLE!");
            // Wait 2 seconds before transporting the object
            //teleportBall();

            GameObject next_Hole = GameObject.Find(goto_Hole_Name);
            GameObject start_Mat_Child = next_Hole.transform.Find("StartMat").gameObject;
            Debug.Log(start_Mat_Child);
            Transform next_Mat = next_Hole.transform.Find("StartMat");
            Vector3 move_Pos = start_Mat_Child.transform.position;
            Vector3 mat_Size = start_Mat_Child.transform.localScale;
            Debug.Log("mat_Size = " + mat_Size);
            // Vector3 move_Pos = next_Mat.position;
            // We need to get the size of the mat so we can center the ball on the mat


            //Vector3 mat_Size = next_Hole.transform.Find("StartMat").
            move_Pos.y = move_Pos.y + 0.1f;
            //move_Pos.x = move_Pos.x + (mat_Size.x * 0.5f);
            //move_Pos.z = move_Pos.z + (mat_Size.z * 0.5f);
            Debug.Log(move_Pos);
            System.Threading.Thread.Sleep(2000);
            col.transform.position = move_Pos;
        }
    }

    public void teleportBall()
    {
        GameObject next_Hole = GameObject.Find(goto_Hole_Name);
        Debug.Log(next_Hole.transform.Find("StartMat").position);
        System.Threading.Thread.Sleep(2000);

    }

}
