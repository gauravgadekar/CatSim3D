using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Obstacles : MonoBehaviour
{

    public float speed = 10.0f;

    public GameObject text;
   // public TextMeshProUGUI text;

    public Transform WinParticlesPos;
    public GameObject WinParticles;
    public GameObject LoseParticles;
    
    
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            WinParticlesPos = GameObject.Find("PosWinParticles").transform;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        text = GameObject.Find("ScoreTxt");

    }


    void Update()
    {
        transform.Translate( speed * Time.deltaTime *Vector3.back );
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Instantiate(LoseParticles, collision.gameObject.transform.position, Quaternion.identity);
           
            iTween.PunchScale(text,new Vector3(1.5f,1.5f,1.5f),1.0f);
            Destroy(collision.gameObject,0.5f);
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Destroy(gameObject.GetComponent<TrailRenderer>());
            Invoke("Reloadlevel",3);
        }

        if (collision.gameObject.name=="Out")
        {
            iTween.PunchScale(text,new Vector3(2,2,2),1.0f);
            try
            {
                Instantiate(WinParticles, WinParticlesPos.position, Quaternion.identity);
            }
            catch (Exception e)
            {
                print(e.Message);
            }
            
            int newScore = int.Parse(text.GetComponent<TextMeshProUGUI>().text)+1;
            text.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
            Destroy(gameObject);
        }
    }

    public void Reloadlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
