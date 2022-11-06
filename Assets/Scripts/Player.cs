using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variaveis do player 
    public float speed = 0;
    public float jumpForce = 0;
    public int health = 0;

    public GameObject weapon1;
    public Transform attackPoint1;

    private bool isJumping;
    private bool doubleJump;
    private bool isAttack;

    private Rigidbody2D rig;
    private Animator anim;

    private float movement;

    public static Player p;

    // Start is called before the first frame update
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameControl.instance.UpdadeLives(health);
        p = this;

    }

    // Update is called once per frame
    void Update()
    {

        Jump();
        WeaponAttack();
        Limitacao();

    }

    //update que melora o desempenho do rigidbody
    private void FixedUpdate()
    {
        Move();
    }

    //funcao que controla a movimentacao
    void Move()
    {
        //quando precionar botoes horizontais retorna valores de -1 a 1 dependendo da direcao desejada esquerda -1 direita 1
        movement = Input.GetAxis("Horizontal");

        //rig.velocity adiciona a velocidade ao player no eixo x e y / rig.velocity.y retorna a posicao y do player
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        //mudar a direcao do personagem
        //andando para direita
        if (movement > 0)
        {
           //para nao mudar a animacao quando ele estiver pulando
            if (!isJumping)
            {
                //animacao do player para ele andando
                anim.SetInteger("transition", 1);
            }

            //rotacionar player
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        //andando para esquerda
        if (movement < 0)
        {
            //para nao mudar a animacao quando ele estiver pulando
            if (!isJumping)
            {
                //animacao do player para ele andando
                anim.SetInteger("transition", 1);
            }

            //rotacionar player
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        /// parado
        if (movement == 0 && !isJumping && !isAttack)
        {
            //animacao do player para ele parado
            anim.SetInteger("transition", 0);
        }
    }

    void Limitacao()
    {
        if(transform.position.x < -8)
        {
            Debug.Log("oi");
            transform.position = new Vector2(-8,transform.position.y);
        }
    }

    //funcao que controla o pulo
    void Jump()
    {
        //precionar botao jump 
        if (Input.GetButtonDown("Jump"))
        {
            //saber se o player estar pulando
            if (!isJumping)
            {
                //animacao do player para ele pulando
                anim.SetInteger("transition", 2);

                //adicina uma forca para o eixo x e y/a outra parte eu acho que adiciona um impilso mas eu nao entrnde muito bem como funciona
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                //um pulo so precisa disso
                //isJumping = true;

                // pulo duplo
                doubleJump = true;
                isJumping = true;
            }
            else
            {
                if (doubleJump)
                {
                    //animacao do player para ele pulando
                    anim.SetInteger("transition", 2);

                    rig.AddForce(new Vector2(0, jumpForce * 2), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }

        }

    }

    //e chamado quando o objeto enconsta em outro
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //saber se o player esta no chao
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
        }
    }

    //funcao para o player atirar frexa
    void WeaponAttack()
    {
        //chamar a corrotina
        StartCoroutine("Attack1");

    }

    //criar uma rotina, primeiro faz alguma acao e depois de um determinado tempo faz outra
    IEnumerator Attack1()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAttack = true;
            anim.SetInteger("transition", 3);

            //criar o machado em certa posicao
            GameObject WeaponAttack = Instantiate(weapon1, attackPoint1.position, attackPoint1.rotation);

            //mudar a direcao do machado
            if (transform.rotation.y == 0)
            {
                // modificar a variavel isRight no script Weapon
                WeaponAttack.GetComponent<Weapon>().isRight = true;

            }

            if (transform.rotation.y == 180)
            {
                WeaponAttack.GetComponent<Weapon>().isRight = false;
            }

            //tempo em segundo para a executar a proxima acao
            yield return new WaitForSeconds(0.25f);
            isAttack = false;
            anim.SetInteger("transition", 0);
        }
    }

    //dano que o player sofre do inimigo sofre
    public void Damage(int dmg)
    {
        health -= dmg;
        GameControl.instance.UpdadeLives(health);
        anim.SetTrigger("hit");

        if (Enemy.e.boss != 3)
        {
            //colidir com o inimigo faz o player ser jogado para tras
            if (transform.rotation.y == 0)
            {
                transform.position += new Vector3(-0.5f, 0, 0);

            }
            else // (transform.rotation.y == 180)
            {
                transform.position += new Vector3(0.5f, 0, 0);
            }
        }
        else if(Enemy.e.boss == 3)
        {
            if (transform.rotation.y == 0)
            {
                transform.position += new Vector3(-5, 0, 0);

            }
            else // (transform.rotation.y == 180)
            {
                transform.position += new Vector3(5, 0, 0);
            }
        }

        if (health <= 0)
        {
            health = 0;
            //game over
            GameControl.instance.GameOver();

        }
    }

    public void DmgSpeed( int dSpeed)
    {
        speed -= dSpeed;

    }

    public void IncreaseLife(int volue)
    {
        health += volue;
        GameControl.instance.UpdadeLives(health);
    }
   

}
