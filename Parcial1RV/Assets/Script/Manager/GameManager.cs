using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    /// <summary>Recolectable de la escena SkyRider.</summary>
    public int point = 0;

    /// <summary>
    /// Asigna esta instancia como Singleton y persiste entre escenas.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>Agrega valor a point.</summary>
    public void sumPoint(int value)
    {
        point += value;
    }

    /// <summary>Resetea todos los recolectables.</summary>
    public void Reset()
    {
        point = 0;
    }

    public int Point { get => point; set => point = value; }
}
