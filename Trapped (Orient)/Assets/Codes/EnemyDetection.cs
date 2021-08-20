using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    private GameObject player;
    private Light light;

    //float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.black;

    void Start()
    {
        light = null;
        player = GameObject.FindGameObjectWithTag("Player");

        int i = 0;
        while (light == null && i < player.transform.childCount)
        {
            light = player.transform.GetChild(i).gameObject.GetComponent<Light>();
            i++;
        }
    }

    //light turns red when enemy in range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        { 
            //float t = Mathf.PingPong(Time.time, duration) / duration;
            light.color = Color.Lerp(color1, color0, 300);
        }

        Debug.Log("Enemy In Range");
    }

    //light goes back to normal when enemy is out of range range
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            //float t = Mathf.PingPong(Time.time, duration) / duration;
            light.color = Color.Lerp(color0, color1, 300);
        }

        Debug.Log("Enemy Out Of Range");
    }
}
