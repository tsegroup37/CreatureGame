using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CurrentPlayer;
    public int CurrentPlayerNum;
    public List<Transform> Food;
    public List<GameObject> Organisms;
    public GameObject organisms;
    public GameObject food;
    public GameObject sprite;
    public GameObject GameOver;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        spawnOrganisms();
        CurrentPlayerNum = selectPlayer();
        CurrentPlayer = Organisms[CurrentPlayerNum].gameObject;
        Time.timeScale = 1f;
        spawnFood(10, food);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        if(CurrentPlayer == null)
        {
            GameOver.SetActive(true);
        }
    }
    public void addFood(GameObject x)
    {
        Food.Add(x.transform);
    }
    void spawnOrganisms()
    {
        int number = Random.Range(10, 25);
        for (int i = 0 ; i < number; i++)
        {
            GameObject creatures = (GameObject)Instantiate(organisms,transform.position, transform.rotation, GameObject.Find("Organisms").transform);
            Organisms.Add(creatures);
        }
    }
    public void removeFood(GameObject x)
    {
        Food.Remove(x.transform);
    }
    public void setTimeScale(float newtimeScale)
    {
        Time.timeScale = newtimeScale;
    }
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y ;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
    void spawnFood(int numObjects, GameObject prefab)
    {
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects/2; i++)
        {
            Vector3 pos = RandomCircle(center, 3.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, rot);
        }
        for (int i = 0; i < numObjects/2; i++)
        {
            Vector3 pos = RandomCircle(center, 5.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, rot);
        }
    }
    int selectPlayer()
    {
        int player = Random.Range(0, Organisms.Count);
        return player;
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
