using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPointController : MonoBehaviour
{
     Vector3 P0 = new Vector3(0, 0.25f, 0);
     Vector3 P1 = new Vector3(-0.200000003f, 0.25f, 0);
     Vector3 P2 = new Vector3(-0.25f, 0.150000006f, 0);
     Vector3 P3 = new Vector3(-0.200000003f, 0.0500000007f, 0);
     Vector3 P4 = new Vector3(0, 0.100000001f, 0);
     Vector3 P5 = new Vector3(0.200000003f, 0.0500000007f, 0); 
     Vector3 P6 = new Vector3(0.25f, 0.150000006f, 0);
     Vector3 P7 = new Vector3(0.200000003f, 0.25f, 0);

    //public Transform point;
    public GameObject character;
    private void Update()
    {


        switch (character.GetComponent<PlayerAnimation>().lastDirection)
        {
            case 0:
                this.transform.position = character.transform.position + P0*1.5f;
                break;
            case 1:
                this.transform.position = character.transform.position + P1* 1.5f;
                break;
            case 2:
                this.transform.position = character.transform.position + P2* 1.5f;
                break;
            case 3:
                this.transform.position = character.transform.position + P3* 1.5f;
                break;
            case 4:
                this.transform.position = character.transform.position + P4* 1.5f;
                break;
            case 5:
                this.transform.position = character.transform.position + P5* 1.5f;
                break;
            case 6:
                this.transform.position = character.transform.position + P6* 1.5f;
                break;
            case 7:
                this.transform.position = character.transform.position + P7* 1.5f;
                break;
        }
        
    }

    /*

    void UpdateShootingPoint(int _direction)
    {
        switch (_direction)
        {
            case '0':
                transform.position = P0;
                break;
            case '1':
                transform.position = P1;
                break;
            case '2':
                transform.position = P2;
                break;
            case '3':
                transform.position = P3;
                break;
            case '4':
                transform.position = P4;
                break;
            case '5':
                transform.position = P5;
                break;
            case '6':
                transform.position = P6;
                break;
            case '7':
                transform.position = P7;
                break;
        }
        
    }
    */
}
