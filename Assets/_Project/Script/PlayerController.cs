using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioSource playerDead;

    private Move2D move;
    private LifeController lifeController;

    private void Start()
    {
        move = GetComponent<Move2D>();
        lifeController = GetComponent<LifeController>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        move.UpdateMovement(new Vector2(h,v));


        Debug.Log("Hp" + lifeController.Hp);
        IsPlayerDead();
    }

    private void IsPlayerDead()
    {
        if (lifeController.isDead()) StartCoroutine(DeadPlayer());
    }

    IEnumerator DeadPlayer()
    {
        Time.timeScale = 0.2f;
        if(playerDead != null) playerDead.Play();

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
