using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Tests
{
    // A Test behaves as an ordinary method

    //testando se a vida do bat diminui de acordo com a funcao damage dele
    [Test]
    public void Batlife()
    {
        var gameObject = new GameObject();
        var bat = gameObject.AddComponent<EnemyBat>();
        System.Random rand = new System.Random();
        int x;
        int y;
        for (int i = 0; i < 10; i++)
        {
            x = rand.Next(10,20);
            y = rand.Next(10);

            Debug.Log(x);
            Debug.Log(y);
            Debug.Log(x - y);
            Debug.Log("-----");

            bat.health = x;
            bat.Damage(y);

            var expected = x - y;
            var actual = bat.health;

            Assert.AreEqual(expected,actual);
        }
    }

    //testando se a vida da snake diminui de acordo com a funcao damage dela
    [Test]
    public void Snakelife()
    {
        var gameObject = new GameObject();
        var snake = gameObject.AddComponent<EnemySnake>();

        System.Random rand = new System.Random();
        int x;
        int y;
        for (int i = 0; i < 10; i++)
        {
            x = rand.Next(10, 20);
            y = rand.Next(10);

            Debug.Log(x);
            Debug.Log(y);
            Debug.Log(x - y);
            Debug.Log("-----");

            snake.health = x;
            snake.Damage(y);

            var expected = x - y;
            var actual = snake.health;

            Assert.AreEqual(expected, actual);
        }
    }

    //testando se o bat e destroido quando sua vida chega a 0
    [Test]
    public void DestroyBat()
    {
        var gameObject = new GameObject();

        System.Random rand = new System.Random();
        for (int i = 0; i < 10; i++)
        {
            var bat = gameObject.AddComponent<EnemyBat>();
            int x = rand.Next(20);

            Debug.Log(x);

            bat.health = x;
            bat.Damage(x);

            GameObject expected = null;
            var actual = bat;

            if (actual == null)
            {
                Debug.Log("destroido");
            }
            else
            {
                Debug.Log("nao destoida");
            }
            Debug.Log("-----");

            Assert.AreEqual(expected, actual);
        }

        
    }

    //testando se a snake e destroida quando sua vida chega a 0
    [Test]
    public void DestroySnake()
    {
        var gameObject = new GameObject();

        System.Random rand = new System.Random();
        for (int i = 0; i < 10; i++)
        {
            var snake = gameObject.AddComponent<EnemySnake>();
            int x = rand.Next(20);

            Debug.Log(x);

            snake.health = x;
            snake.Damage(x);

            GameObject expected = null;
            var actual = snake;

            if(actual== null)
            {
                Debug.Log("destroida");
            }
            else
            {
                Debug.Log("nao destoida");
            }
            Debug.Log("-----");

            Assert.AreEqual(expected, actual);
        }
    }

    //testando se o player realmente aumenta a velocidade quando consome um item de velocidade
    [Test]
    public void ItemVel()
    {
        var gameObject = new GameObject();
        var item = gameObject.AddComponent<ItemBox>();

        var gamep = new GameObject();
        var player = gamep.AddComponent<Player>();

        System.Random rand = new System.Random();
        for (int i = 0; i < 10; i++)
        {
            int x = rand.Next(20);
            int y = rand.Next(20);

            player.speed = x;
            player.speed += item.Vel(y);

            var expected = x+y;
            var actual = player.speed;

            if (expected == actual)
            {
                Debug.Log("certo");
                
            }
            else
            {
                Debug.Log("erro");
            }
            Debug.Log("-----");

            Assert.AreEqual(expected, actual);
        }
    }

    //testando se dependendo da posicao do player a seta ,que mostra o direcao do portal, aparece e some
    [Test]
    public void Seta()
    {
        var gameObject = new GameObject();
        var portal = gameObject.AddComponent<Portal>();

        System.Random rand = new System.Random();
        int x;
        int y;
        bool expected;
        bool actual;
        for (int i = 0; i < 10; i++)
        {
            x = rand.Next(10);
            y = rand.Next(10);

            Debug.Log(x);
            Debug.Log(y);

            
            portal.Seta(x,y);
            if (x > y)
            {
                 expected = false;
            }
            else
            {
                expected = true;
            }

            actual = portal.s;
            if (portal.s)
            {
                Debug.Log("apareceu");
                Debug.Log(expected);
            }
            else
            {
                Debug.Log("desapareceu");
                Debug.Log(expected);
            }
            Debug.Log("-----");

            Assert.AreEqual(expected, actual);
        }
    }

    //testando se a snake e destroida quando leva sucessivos ataques
    [Test]
    public void DestroyDamameSnake()
    {
        var gameObject = new GameObject();
        var snake = gameObject.AddComponent<EnemySnake>();

        System.Random rand = new System.Random();
        var d = snake;
        int x = rand.Next(10, 20);
        snake.health = x;
        for (int i = x, y = rand.Next(10); i >= 0; i -=y)
        {
            x = snake.health;

            Debug.Log(x);
            Debug.Log(y);
            var expected = x - y;
            snake.Damage(y);

            var actual = snake.health;

            if (d == null)
            {
                Debug.Log("destroida");
                Debug.Log("vida:" + snake.health);
            
                
            }
            else
            {
                Debug.Log("nao destoida");
                Debug.Log("vida:" + snake.health);
            }
            Debug.Log("-----");

            Assert.AreEqual(expected, actual);
        }
    }

    //testando se o bat e destroido quando leva sucessivos ataques
    [Test]
    public void DestroyDamameBat()
    {
        var gameObject = new GameObject();
        var bat = gameObject.AddComponent<EnemyBat>();

        System.Random rand = new System.Random();
        var d = bat;
        int x = rand.Next(10, 20);
        bat.health = x;
        for (int i = x, y = rand.Next(10); i >= 0; i -= y)
        {
            x = bat.health;
            Debug.Log(x);
            Debug.Log(y);
            var expected = x - y;
            bat.Damage(y);

            var actual = bat.health;

            if (d == null)
            {
                Debug.Log("destroida");
                Debug.Log("vida:" + bat.health);
            }
            else
            {
                Debug.Log("nao destoida");
                Debug.Log("vida:" + bat.health);
            }
            Debug.Log("-----");

            Assert.AreEqual(expected, actual);
        }
    }

    [Test]
    public void GameOver()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<Player>();

        System.Random rand = new System.Random();
        var d = player;
        int x = rand.Next(10, 20);
        player.health = x;
        for (int i = x, y = rand.Next(10); i >= 0; i -= y)
        {
            x = player.health;
            Debug.Log(x);
            Debug.Log(y);
            var expected = x - y;
            player.Damage(y);

            var actual = player.health;

            if (d == null)
            {
                Debug.Log("destroida");
                Debug.Log("vida:" + player.health);
            }
            else
            {
                Debug.Log("nao destoida");
                Debug.Log("vida:" + player.health);
            }
            Debug.Log("-----");

            Assert.AreEqual(expected, actual);
        }
    }

    //testar a movimentacao do player, direita e esquerda
    [Test]
    public void Mov()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<Player>();
        System.Random rand = new System.Random();
        float x;
        for (int i = 0; i < 10; i++)
        {
            x = rand.Next(-1,1);
            

            Debug.Log(x);
            
            player.Move(x);
            bool expected;
            if(x > 0)
            {
                expected =true;
                Debug.Log("direita");
            }
            else
            {
                expected =false;
                Debug.Log("esquerda");
            }
            Debug.Log("-----");


            var actual = player.d;

            Assert.AreEqual(expected, actual);
        }
    }
}


