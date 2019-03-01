using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CreatRoom2 : MonoBehaviour
{
    public float length ;

    static int id;

    static int amount = 0;
    public int AmountOfRooms;

    public GameObject Floor;
    public GameObject FirstFloor;

    int rand;
    //public List<GameObject> Down = new List<GameObject>();

    List<GameObject> gointToPrint = new List<GameObject>();
    List<Vector3> dirOfPrint = new List<Vector3>();

    Ray[] rays = new Ray[4];
    RaycastHit[] hits = new RaycastHit[4];

    Vector2 look;

    // Start is called before the first frame update
    void Start()
    {

        id++;
        #region fungerar


        Debug.DrawRay(transform.position, Vector3.right * length, Color.red, 2);
        Debug.DrawRay(transform.position, Vector3.up * length, Color.red, 2);
        Debug.DrawRay(transform.position, Vector3.left * length, Color.red, 2);
        Debug.DrawRay(transform.position, Vector3.down * length, Color.red, 2);


        Ray rayU = new Ray(transform.position, Vector3.up);
        Ray rayD = new Ray(transform.position, Vector3.down);
        Ray rayR = new Ray(transform.position, Vector3.right);
        Ray rayL = new Ray(transform.position, Vector3.left);

        RaycastHit hitU;
        RaycastHit hitR;
        RaycastHit hitL;
        RaycastHit hitD;

        //RaycastHit2D hitU2d = Physics2D.Raycast(transform.position, new Vector2(0, 1),2);
        //RaycastHit2D hitR2d = Physics2D.Raycast(transform.position, new Vector2(1, 0),2);
        //RaycastHit2D hitL2d = Physics2D.Raycast(transform.position, new Vector2(-1, 0),2);
        //RaycastHit2D hitD2d = Physics2D.Raycast(transform.position, new Vector2(0, -1),2);

        //if(hitD2d != null)
        //{
        //    Debug.Log(hitU2d.rigidbody.gameObject.name);
        //}
        //if (hitR2d != null)
        //{
        //    Debug.Log(hitU2d.rigidbody.gameObject.name);
        //}
        //if (hitL2d != null)
        //{
        //    Debug.Log(hitU2d.rigidbody.gameObject.name);
        //}
        //if (hitD2d != null)
        //{
        //    Debug.Log(hitU2d.rigidbody.gameObject.name);
        //}


        #endregion
        if (amount < AmountOfRooms)
        {

            if (!Physics.Raycast(rayU, out hitU, length))
            {
                dirOfPrint.Add(Vector3.up);
            }

            if (!Physics.Raycast(rayD, out hitD, length))
            {
                dirOfPrint.Add(Vector3.down);
            }

            if (!Physics.Raycast(rayR, out hitR, length))
            {
                dirOfPrint.Add(Vector3.right);
            }

            if (!Physics.Raycast(rayL, out hitL, length))
            {
                dirOfPrint.Add(Vector3.left);
            }

            for (int j = 0; j < dirOfPrint.Count; j++)
            {
                amount++;

                gointToPrint.Add(Instantiate(Floor, transform.position + (dirOfPrint[j] * length), Quaternion.identity));

                gointToPrint[j].name = id + "." + j.ToString();

                print(gointToPrint[j].name + " my dir is :" + dirOfPrint[j]);

                roomType(j, dirOfPrint[j]);

                if (amount >= AmountOfRooms && j == dirOfPrint.Count - 1)
                    gointToPrint[amount].GetComponent<Renderer>().material.color = Color.red;

            }

        }
    }

    public void Restart()
    {
        for (int i = 0; i < dirOfPrint.Count; i++)
        {
            Destroy(gointToPrint[i]);
        }

        Instantiate(FirstFloor, GameObject.Find("Player").transform.position, Quaternion.identity);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="witchWall">0 = höger, 1 = upp, 2 = vänster, 3 = ner</param>
    //void addOutSideWall(int ID, int witchWall)
    //{
    //    gointToPrint[ID].transform.GetChild(witchWall).gameObject.SetActive(true);
    //}

    void roomType(int ID, Vector3 dir)
    {
        rand = Random.Range(0, 6);


        //Ett random rum med öppnig uppåt
        if (dir == Vector3.up)
        {
            gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(false);

            switch (rand) // de olika slags rummen
            {
                case 0:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);

                    return;

                case 1:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    return;

                case 2:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    return;

                case 3:
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    return;

                case 4:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    return;

                case 5:
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    return;

                case 6:
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    return;
            }
        }

        //Ett random rum med öppnig neråt
        if (dir == Vector3.down)
        {
            gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(false);

            switch (rand)// de olika slags rummen
            {
                case 0:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);

                    return;

                case 1:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    return;

                case 2:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    return;

                case 3:
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    return;

                case 4:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    return;

                case 5:
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    return;

                case 6:
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    return;
            }
        }

        //Ett random rum med öppnig åt höger
        if (dir == Vector3.right)
        {
            gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(false);

            switch (rand)// de olika slags rummen
            {
                case 0:
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);

                    return;

                case 1:
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    return;

                case 2:
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    return;

                case 3:
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    return;

                case 4:
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    return;

                case 5:
                    gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(true);
                    return;

                case 6:
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    return;
            }
        }

        //Ett random rum med öppnig åt vänster
        if (dir == Vector3.left)
        {
            gointToPrint[ID].transform.GetChild(0).gameObject.SetActive(false);

            switch (rand)// de olika slags rummen
            {
                case 0:
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);

                    return;

                case 1:
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    return;

                case 2:
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    return;

                case 3:
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    return;

                case 4:
                    gointToPrint[ID].transform.GetChild(2).gameObject.SetActive(true);
                    return;

                case 5:
                    gointToPrint[ID].transform.GetChild(1).gameObject.SetActive(true);
                    return;

                case 6:
                    gointToPrint[ID].transform.GetChild(3).gameObject.SetActive(true);
                    return;
            }
        }

    }

    /* Loop som inte funkade8skapar rum)
     * 
     *     switch (rand)
                        {
                            case 0:

                                return;

                            case 1:

                                return;

                            case 2:

                                return;

                            case 3:

                                return;

                            case 4:

                                return;

                            case 5:

                                return;

                            case 6:

                                return;

                            case 7:

                                return;

                            case 8:

                                return;

                            case 9:

                                return;

                            case 10:

                                return;

                            case 11:

                                return;

                            case 12:

                                return;

                            case 13:

                                return;

                            case 14:

                                return;
                        }
     * 
    void loop()
    {
        for (int i = 0; i < 4; i++)
        {
            print(i);

            if (i == 0)
            {
                look = Vector2.left;
            }
            if (i == 1)
            {
                look = Vector2.right;
            }
            if (i == 2)
            {
                look = Vector2.up;
            }
            if (i == 3)
            {
                look = Vector2.down;
            }

          //  Vector3 outsideColl = new Vector3((look.x * transform.localScale.x), (look.y * transform.localScale.y), 0);

            rays[i] = new Ray(transform.position, look);

            Debug.DrawRay(transform.position, look * length, Color.green, 2);

            if (Physics.Raycast(rays[i], out hits[i], length))
            {
                {
                    print("raycast " + hits[i].collider.tag);
                }
            }
            //else
            //{
            //    gointToPrint.Add(Up[i]);
            //}
        }

    }
    */
}



