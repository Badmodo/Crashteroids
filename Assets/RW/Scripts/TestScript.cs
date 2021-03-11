using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private Game game;

    [SetUp]

    public void SetUp()
    {
        GameObject gameGameobject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));

        //spawn the asteroid
        game = gameGameobject.GetComponent<Game>();
    }

    [TearDown]

    public void TearDown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator AsteroidMovesDown()
    {


        Spawner spawner = game.GetSpawner();

        GameObject asteroid = spawner.SpawnAsteroid();

        float initialYPos = asteroid.transform.position.z;

        yield return new WaitForSeconds(0.9f);

        Assert.Less(asteroid.transform.position.z, initialYPos);
    }

    [UnityTest]

    public IEnumerator GameOverOccursOnAsteroidCollision()
    {
        Spawner spawner = game.GetSpawner();
        GameObject asteroid = spawner.SpawnAsteroid();

        Ship ship = game.GetShip();
        asteroid.transform.position = ship.transform.position;

        yield return new WaitForSeconds(0.1f);

        Assert.True(game.isGameOver);
        //Assert.IsNotNull(ship);
    }

    [UnityTest]
    public IEnumerator NewGameRestartGame()
    {
        game.isGameOver = true;
        game.NewGame();

        Assert.False(game.isGameOver);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator LaserMovesUp()
    {
        Ship ship = game.GetShip();        
        GameObject laser = ship.SpawnLaser();

        float initialZpos = laser.transform.position.z;
        yield return new WaitForSeconds(0.1f);

        Assert.Greater(laser.transform.position.z, initialZpos);
    }

    [UnityTest]
    public IEnumerator LaserDestroyAsteroid()
    {
        // Spawn laser
        Ship ship = game.GetShip();        
        GameObject laser = ship.SpawnLaser();

        // Spawn asteroid
        Spawner spawner = game.GetSpawner();
        GameObject asteroid = spawner.SpawnAsteroid();

        // Put laser on asteroid
        laser.transform.position = ship.transform.position;

        yield return new WaitForSeconds(0.1f);

        // We have to usevthe unity Assert.IsNull because Unity deals with nulls differently to normal C#
        //UnityEngine.Assertions.Assert.IsNull(asteroid);


    }
}
