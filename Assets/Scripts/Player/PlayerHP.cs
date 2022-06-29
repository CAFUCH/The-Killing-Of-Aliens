using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour, IDamage
{
    private float CurrentHP = 0;
    [SerializeField] private float MaxHP = 10;
    private float CurrentFilm = 0;
    [SerializeField] private float MaxFilm = 0;
    private Image HpGage = null;
    private Image FilmGage = null;
    private Transform HpTransform;
    private Transform FilmTransform = null;
    private void Awake()
    {
        HpGage = GameObject.Find("HP/HPs/HP2").GetComponent<Image>();
        FilmGage = GameObject.Find("Film/Films/Film1").GetComponent<Image>();
        HpTransform = GameObject.Find("HP/HPs").GetComponent<Transform>();
        FilmTransform = GameObject.Find("Film/Films").GetComponent<Transform>();
        CurrentHP = MaxHP;
        CurrentFilm = MaxFilm;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            CurrentHP += 15;

        HpGage.fillAmount = CurrentHP / MaxHP;
        FilmGage.fillAmount = CurrentFilm;

        Vector2 hpposition = new Vector2(transform.position.x, transform.position.y + 0.1f);
        HpTransform.transform.position = Camera.main.WorldToScreenPoint(hpposition);
        Vector2 filmposition = new Vector2(transform.position.x, transform.position.y + 0.1f);
        FilmTransform.transform.position = Camera.main.WorldToScreenPoint(filmposition);
    }

    public void HpHeal(float amount)
    {
        CurrentHP += amount;
        Mathf.Max(CurrentHP, MaxHP);
    }
    public void FilmHeal()
    {
        CurrentFilm = 1;
        //Mathf.Max(CurrentFilm, MaxFilm);
    }
    public void OnDamage(float damage)
    {
        if (CurrentFilm <= 0)
            CurrentHP -= damage;
        else { CurrentFilm = 0; }
    }
}