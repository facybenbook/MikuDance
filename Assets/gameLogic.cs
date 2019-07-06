using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameLogic : MonoBehaviour {
    
    public Queue<GameObject> q;
    public GameObject padre;
    public GameObject freccia;
    public double sum = 0;
    public float punteggio = 0;
    public Text punteggioText;
    public Animator a;
    public AudioSource AudioS;
    public Text finaleText;
    public GameObject c;
    public float timerFrecce = 1.5f;
    public int probab = 30;

    private bool gameOn = true;
	// Use this for initialization
	void Start () {
        q = new Queue<GameObject>();

	}

    // Update is called once per frame
    void Update()
    {
        if(gameOn)
        {

       
        sum += Time.deltaTime;
        if (sum >= timerFrecce)
        {
            sum -= timerFrecce;
            if (Random.Range(1, 100) > probab)
            {
                GameObject f = Instantiate(freccia, padre.transform);
                q.Enqueue(f);
                if (Random.Range(0, 9) >= 5)
                {
                    f.transform.Rotate(new Vector3(0, 0, -180));
                }

            }
        }

        if (q.Count > 0)
        {
            var tmp = q.Peek();
            var distX = tmp.transform.position.x - this.transform.position.x;
            //Debug.Log(distX);
            if (distX < -100)
            {
                q.Dequeue();
                Destroy(tmp);
                CambiaPunteggio(50, false);
            }



        }

        if (q.Count > 0 && (Input.GetKey("a") || Input.GetKey("d")))
        {
            var tmp = q.Peek();
            var distX = tmp.transform.position.x - this.transform.position.x;
            //Debug.Log(distX);
                if (distX <= 100)
            {
                if (Input.GetKey("d"))
                {
                    q.Dequeue();
                    Destroy(tmp);
                    if (tmp.transform.rotation.z > 0)
                    {
                        CambiaPunteggio(distX, true);
                    }
                    else
                    {
                        CambiaPunteggio(distX, false);
                    }
                }

                if (Input.GetKey("a"))
                {
                    q.Dequeue();
                    Destroy(tmp);
                    if (tmp.transform.rotation.z < 0)
                    {
                        CambiaPunteggio(distX, true);
                    }
                    else
                    {
                        CambiaPunteggio(distX, false);
                    }
                }


            }



        }

            if (!AudioS.isPlaying)
            {
                gameOn = false;
                //fine del gioco
                finaleText.text = "Score: " + punteggioText.text;
                c.SetActive(true);
            }
        }
       
    }


    void CambiaPunteggio(float p, bool bene)
    {
        if(!bene)
        {
            p *= -1;
        }
        else
        {
            p = 100 - p;
        }
        p /= 10;
        punteggio += p;
        punteggioText.text = punteggio.ToString("0");
        a.SetFloat("punteggio", punteggio);
    }
}
