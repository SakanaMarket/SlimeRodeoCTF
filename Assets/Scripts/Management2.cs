using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Management2 : MonoBehaviour
{
    [SerializeField] private int total_collected;
    [SerializeField] private int death_toll;
    [SerializeField] Text t;
    [SerializeField] int endCount;
    [SerializeField] private bool all_collected;
    [SerializeField] private bool flag_cap;
    [SerializeField] GameObject props;
    [SerializeField] GameObject BigBoiSlime;
    [SerializeField] GameObject[] spoders;

    private void Awake()
    {
        total_collected = 0;
        death_toll = 0;
        all_collected = false;
    }

    private void Update()
    {
        Debug.Log(total_collected);
        EndGame();
        if (flag_cap == true)
        {
            Debug.Log("BOOOOOOM");
            BigBoiSlime.SetActive(false);
            foreach (GameObject sp in spoders)
            {
                sp.SetActive(false);
            }
            EndGame2();
        }
        
    }

    public void increment_count()
    {
        total_collected += 1;
    }

    public void ResetCount()
    {
        total_collected = 0;
    }

    public int GetCount()
    {
        return total_collected;
    }

    public void increment_death()
    {
        death_toll += 1;
    }

    public int GetDeath()
    {
        return death_toll;
    }

    private void EndGame()
    {
        if (total_collected >= endCount)
        {
            if (death_toll == 0)
            {
                //t.text = "GREAT JOB!\nYou've Instructed Gabe Flawlessly!";
                all_collected = true;
                props.SetActive(false);
                GameObject[] spiders = GameObject.FindGameObjectsWithTag("bad");
                GameObject[] slimes = GameObject.FindGameObjectsWithTag("collect");
                foreach (GameObject s in spiders)
                {
                    s.SetActive(false);
                }
                foreach (GameObject ss in slimes)
                {
                    ss.SetActive(false);
                }
                BigBoiSlime.SetActive(true);
                foreach (GameObject sp in spoders)
                {
                    sp.SetActive(true);
                }
                //spoders.SetActive(true);
                GridMovement2 g = GameObject.FindGameObjectWithTag("Player").GetComponent<GridMovement2>();
                g.Set_Capping();
                total_collected = 0;
            }
            else
            {
                //t.text = "NICE!\nBut you could do Better!";
            }
            
        }
        
    }
    private void EndGame2()
    {
        t.text = "Flag Captured: Instructions";
    }

    public bool Return_Flag_Capped()
    {
        return flag_cap;
    }

    public void Flag_Cap()
    {
        flag_cap = true;

    }
}
