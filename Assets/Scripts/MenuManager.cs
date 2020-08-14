using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI weatherText;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            print("I am visible");
            Cursor.visible = true;
            Screen.lockCursor = false;
        }
        GetWeather();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetWeather()
    {
        RestClient.Get(new RequestHelper
        {
            Uri = "https://cors-anywhere.herokuapp.com/http://api.openweathermap.org/data/2.5/weather?q=delhi&appid=316b4e83a3e5c6c57b5b004df6715869&units=metric"
       ,Headers = new Dictionary<string, string> {
{ "origin", "test" }
}
        }

            
            ).Then(response =>
        {
            print(response.Text);
            Root weatherResponse = JsonUtility.FromJson<Root>(response.Text);

            weatherText.text = weatherResponse.name + " " + weatherResponse.main.temp + " \u00B0C" + " feels like " + weatherResponse.main.feels_like + " \u00B0C";
        },error=>{
        print(error.Message);
            }
            );
    }

    public void GoToWalkThrough()
    {
        print("test");
        SceneManager.LoadScene("VirtualWalkthrough");
    }

    public void GoToMainMenu()
    {
        print("test");
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }

}
