using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsPlayController : MonoBehaviour
{
    [SerializeField] private Sprite[] habitablePlanets;
    [SerializeField] private Sprite[] uninhabitablePlanets;
    [SerializeField] private Sprite[] gasGiants;

    [SerializeField] private float gameCircleTime = 5f;
    [SerializeField] private int planetsCount = 24;
    [SerializeField] private Planets basePlanet;

    private Planets[] planets;
    private bool inGame;

    private void Start()
    {
        inGame = true;
        StartCoroutine(GameCircle());
    }

    private IEnumerator GameCircle()
    {
        planets = new Planets[planetsCount];
        planets[0] = basePlanet;

        for (var i = 1; i < planetsCount; i++)
        {
            planets[i] = Instantiate(basePlanet, basePlanet.transform.parent, false);
        }

        while (inGame)
        {
            var habitablePlanetNumber = Random.Range(0, planetsCount);

            for (var i = 0; i < planetsCount; i++)
            {
                if (i == habitablePlanetNumber)
                {
                    planets[i].Setup(habitablePlanets[Random.Range(0, habitablePlanets.Length)],
                        OnHabitablePlanetClicked);
                    continue;
                }
                
                if (Random.Range(0, 3) == 0)
                {
                    planets[i].Setup(uninhabitablePlanets[Random.Range(0, habitablePlanets.Length)],
                        OnUninhabitablePlanetClicked);
                    continue;
                }
                planets[i].Setup(gasGiants[Random.Range(0, habitablePlanets.Length)], OnGasGiantClicked);
            }

            yield return new WaitForSeconds(gameCircleTime);
        }
    }
    
    private void OnHabitablePlanetClicked()
    {
        Debug.Log("Habitable");
    }

  

    private void OnUninhabitablePlanetClicked()
    {
        Debug.Log("Uninhabitable");
    }

    private void OnGasGiantClicked()
    {
        Debug.Log("GasGiant");
    }
}