using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class NamedArrayAttribute : PropertyAttribute
{
    public readonly string[] names;
    public NamedArrayAttribute(string[] names) { this.names = names; }
}

[CustomPropertyDrawer(typeof(NamedArrayAttribute))] // inte mitt taget från nätet men används för att namnge array platserna i UnityEditorn
public class NamedArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        try
        {
            int pos = int.Parse(property.propertyPath.Split('[', ']')[1]);
            EditorGUI.ObjectField(rect, property, new GUIContent(((NamedArrayAttribute)attribute).names[pos]));
        }
        catch
        {
            EditorGUI.ObjectField(rect, property, label);
        }
    }
}

public class InventoryScript : MonoBehaviour
{


    [NamedArrayAttribute(new string[] { "Head", "RightArm", "RightLeg", "LeftArm",  "LeftLeg" })]
    public GameObject[] Bodyparts = new GameObject[5];

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pickup(collision.gameObject);
    }

    private void Pickup(GameObject obj)
    {
        
        if(obj.tag == "BodyPart")
        {
            obj.GetComponent<BoxCollider2D>().enabled = false;
            PickupBodypart(obj);
        }

    }

    private void PickupBodypart(GameObject obj)
    {
        for (int i = 0; i < Bodyparts.Length; i++)
        {
            if (Bodyparts[i] == null)
            {
                
                Bodyparts[i] = obj;
                obj.transform.position = transform.GetChild(i).position;
                obj.transform.SetParent(transform);
                
                ChangeBodyPart(transform.GetChild(i).gameObject, obj);
                Destroy(transform.GetChild(i));
                
                break;
            }
        }
    }

    private void ChangeBodyPart(GameObject ObjOnPlayer, GameObject ObjInArray)
    {
       
        ObjInArray.name = ObjOnPlayer.name;
        //Instantiate(ObjInArray, ObjOnPlayer.transform.position,ObjOnPlayer.transform.rotation,ObjOnPlayer.transform.parent);
        Destroy(ObjOnPlayer);
        
    }
   
}
