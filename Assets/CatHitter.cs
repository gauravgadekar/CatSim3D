using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class CatHitter : MonoBehaviour
{
    public GameObject[] hitparticles;
    public GameObject textScore;
    public TextMeshPro textScore3d;
    public GameManager gm;

    public bool isAi = false;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isAi)
        {
            if (hit.gameObject.tag=="hittable")
            {
                print("OBJECT"+ hit.gameObject.name);
                hit.gameObject.tag = "hitted";
                Rigidbody obj_rb = hit.gameObject.GetComponent<Rigidbody>();
                HittableObjects ho = hit.gameObject.GetComponent<HittableObjects>();
                HitEffect(obj_rb,hit);
                Score3DEffect(ho);
                GetCoins(ho);

            }
            
        }

    }

    public void HitEffect(Rigidbody obj_rb, ControllerColliderHit hit)
    {
        obj_rb.isKinematic = false;
        obj_rb.AddExplosionForce(50,transform.position + Vector3.down,30);
        Instantiate(hitparticles[UnityEngine.Random.Range(0, hitparticles.Length)], hit.gameObject.transform.position,
            Quaternion.identity);
            
        iTween.PunchScale(textScore, new Vector3(1.25f, 1.25f,1.25f), 0.3f);
    }

    public void Score3DEffect(HittableObjects ho)
    {
        int newScore = int.Parse(textScore.GetComponent<TextMeshProUGUI>().text) + ho.points;
        textScore.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
        textScore3d.text = "+" + ho.points;
        Invoke("ResetText3D",0.5f);
    }

    public void GetCoins(HittableObjects ho)
    {
        int actualCoins = PlayerPrefs.GetInt("nbCoins", 0);

        if (actualCoins +ho.coins > 999999999)
        {
            PlayerPrefs.SetInt("nbCoins", 999999999);
        }
        
        PlayerPrefs.SetInt("nbCoins", actualCoins + ho.coins);
    }

    public void ResetText3D()
    {
        textScore3d.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAi && gm.gameStarted && !gm.gameEnded)
        {
            if (other.gameObject.tag == "hittable")
            {
                Rigidbody obj_rb = other.gameObject.GetComponent<Rigidbody>();
                HittableObjects ho = other.gameObject.GetComponent<HittableObjects>();
                
                obj_rb.isKinematic = false;
                obj_rb.AddExplosionForce(50,transform.position + Vector3.down,30);
                Instantiate(hitparticles[UnityEngine.Random.Range(0, hitparticles.Length)], other.gameObject.transform.position,
                    Quaternion.identity);
                if (other.gameObject.name!="touched")
                {
                   AiPlayer aip = GetComponent<AiPlayer>();
                   aip.GetPoints(ho.points);
                }
                other.gameObject.name = "touched";

            }

        }
    }
}
