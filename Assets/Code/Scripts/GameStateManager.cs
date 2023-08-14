using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager managerState;
    [SerializeField] GameObject[] gameObjectsOnMentalHealth; 
    [SerializeField] GameObject[] gameObjectsOnCapitalism; 
    [SerializeField] Material skyboxMentalHealth; 
    [SerializeField] Material skyboxCapitalism; 
    [SerializeField] public float value=0.5f;
    [SerializeField] public float valueOntimeMultiply;
    [SerializeField] public float changeOvertime;
    [SerializeField] public DeathLogic deathLogic;
    [SerializeField] public Transform objRotation;
    [SerializeField] Slider slider;
    [SerializeField] Button button_L;
    [SerializeField] Sprite button_Lsprite;
    [SerializeField] Sprite button_LspritePress;
    [SerializeField] Button button_R;
    [SerializeField] Sprite button_Rsprite;
    [SerializeField] Sprite button_RspritePress;
    private void Awake()
    {
        managerState = this;
        slider.value = 0.5f;
    }

    void Update()
    {
        changeOvertime += valueOntimeMultiply * Time.deltaTime;

        if (objRotation.eulerAngles.y == 90)
        {
            ModifyValue_(changeOvertime * Time.deltaTime);
            for (int i = 0; i < gameObjectsOnMentalHealth.Length; i++)
            {
                gameObjectsOnMentalHealth[i].gameObject.SetActive(true);
                RenderSettings.skybox = skyboxMentalHealth;
            }
            for (int i = 0; i < gameObjectsOnCapitalism.Length; i++)
            {
                RenderSettings.skybox = skyboxCapitalism;
                gameObjectsOnCapitalism[i].gameObject.SetActive(false);
            }

        }
        else
        {
            ModifyValue_(-changeOvertime * Time.deltaTime);
            for (int i = 0; i < gameObjectsOnMentalHealth.Length; i++)
            {
                gameObjectsOnMentalHealth[i].gameObject.SetActive(false);

            }
            for (int i = 0; i < gameObjectsOnCapitalism.Length; i++)
            {
                gameObjectsOnCapitalism[i].gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            button_R.image.sprite = button_RspritePress;
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            button_R.image.sprite = button_Rsprite;

        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            button_L.image.sprite = button_LspritePress;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            button_L.image.sprite = button_Lsprite;

        }
    }
    public void ModifyValue_(float valueToAdd)
    {
        this.value += valueToAdd;
        this.value = Mathf.Clamp01(this.value);
        slider.value = 1-this.value;
        if (value >= 1 || value <= 0)
        {
            deathLogic.OnGameLost();
        }
    }
}



