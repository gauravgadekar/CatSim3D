using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = System.Random;

public class AiPlayer : MonoBehaviour
{
    public NavMeshAgent nma;
    public float radius = 10;
    public Animator catAnim;
    public int score = 0;
    public GameManager gm;
    public Texture[] skins;

    private void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = skins[UnityEngine.Random.Range(0, skins.Length)];
    }

    public void StartGame()
    {
        nma.destination = RandomNavmeshLocation(radius);
        catAnim.SetBool("canWalk", true);
        InvokeRepeating("ChangeDest", UnityEngine.Random.Range(8,12), UnityEngine.Random.Range(8,12));
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere* radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection,out hit,radius,1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }

    private void ChangeDest()
    {
        nma.destination = RandomNavmeshLocation(radius);
    }

    private void Update()
    {
        if (gm.gameStarted && nma.remainingDistance < 1.5f)
        {
            ChangeDest();
        }
    }

    public void GetPoints(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
