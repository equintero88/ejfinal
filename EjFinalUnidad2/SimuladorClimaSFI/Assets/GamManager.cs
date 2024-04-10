using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamManager : MonoBehaviour
{
    public static GamManager Instance;

    public List<lluviasele> personajes;

    private void Awake()
    {
        if (GamManager.Instance == null)
        {
            GamManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
