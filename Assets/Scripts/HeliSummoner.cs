using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliSummoner : Enemy
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    Animator anim;

    public Enemy enemyToSummon;
    public float timeBetweenSummons;
    private float summonTime;


    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (player != null)
        {

            if (Vector2.Distance(transform.position, targetPosition) > 0.5)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            }
            else
            {
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    //anim.SetTrigger("HeliSumm");
                    Debug.Log("Summon");
                    Instantiate(enemyToSummon, transform.position, transform.rotation);


                }

            }
        }
    }

        public void Summon()
        {
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }



}

