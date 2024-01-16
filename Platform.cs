using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;

    public Vector3 direction;

    public bool isActive;




    void Update()
    {
        if (isActive)
        {
            transform.position +=direction * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        /*Если платформа достигает точки остановки, то она меняет направление
        своего движения*/
        if (other.tag == "PlatformStop")
        {
            direction *= -1;
        }
        //Если платформы коснулся игрок, то она активируется
        if (other.tag == "Player")
        {
            isActive = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //Если с платформы ушёл игрок, то она дезактивируется
        if (other.tag == "Player")
        {
            isActive = false;
        }
    }
}