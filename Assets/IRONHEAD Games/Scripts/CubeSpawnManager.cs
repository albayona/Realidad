using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TextObject : MonoBehaviour
{
    public SpriteRenderer backGround;
    public TextMesh textMesh;
    public Color backGroundColour = Color.white;
    public Color textColour = Color.black;
    public string text = "AB";
    // Use this for initialization

    void Start()
    {
        backGround.color = backGroundColour;
        textMesh.color = textColour;
        textMesh.text = text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class CubeSpawnManager : MonoBehaviour
{
    public GameObject[] Spawnpoints;
    public GameObject[] Cubeprefabs;
    private int index;
    private int indexcube;

    public float timeRate;

    void Start()
    {
        StartCoroutine(CreateCubes());
    }


    private IEnumerator CreateCubes()
    {
        int cont = 0;
        while (true) { 

            cont++;
            index = Random.Range(0, 4);

            int number = Random.Range(0, 500);
            indexcube = number % 2;

            bool isBig = index == 2 && indexcube == 1;
            if (isBig) {
                indexcube = 2;
            }


            GameObject cube = Instantiate(Cubeprefabs[indexcube], Spawnpoints[index].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;

            cube.GetComponentInChildren<Text>().text = "" + number;



            cube.transform.SetParent(transform);

            yield return new WaitForSeconds(timeRate);
        }
    }

}
