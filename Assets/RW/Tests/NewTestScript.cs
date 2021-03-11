//using System.Collections;
//using System.Collections.Generic;
//using NUnit.Framework;
//using UnityEngine;
//using UnityEngine.TestTools;

//public class TestSuite
//{
//    private Game game;

//    [SetUp]
//    public void SetUp()
//    {
//        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));

//        game = gameGameObject.GetComponent<Game>();
//    }

//    [TearDown]

//    public void TearDown()
//    {
//        Object.Destroy(game.gameObject);
//    }

//    [UnityTest]
//    public IEnumerator AsteroidMoveDown()
//    {
//        Spawner spawner = game.GetSpawner();
//        GameObject asteroid = spawner.SpawnAsteroid();

//        float initialYPos = asteroid.transform.position.y;

//        yield return new WaitForSeconds(0.1f);

//        Assert.Less(asteroid.transform.position.y, initialYPos);
//    }

//    [UnityTest]
//    public IEnumerator GameOverOccursOnAsteroidCollion()
//    {
//        Spawner spawner = game.GetSpawner();
//        GameObject asteroid = spawner.SpawnAsteroid();

//        Ship ship = game.GetShip();
//        asteroid.transform.position = ship.transform.position;

//        yield return new WaitForSeconds(0.1f);

//        Assert.True(game.isGameOver);

//    }

//    [UnityTest]

//    public IEnumerator NewGameRestartButton()
//    {
//        game.isGameOver = true;
//        game.NewGame();

//        Assert.False(game.isGameOver);
//        yield return null;
//    }

//    public IEnumerator LaserMovesUp()
//    {
//        Ship ship = game.GetShip();
//        GameObject laser = ship.SpawnLaser();

//        float initialZpos = laser.transform.position.z;
//        yield return new WaitForSeconds(0.1f);

//        Assert.Greater(laser.transform.position.z, initialZpos);
//    }

//    [UnityTest]
//    public IEnumerator LaserDestroyAsteroid()
//    {
//        // Spawn laser
//        Ship ship = game.GetShip();
//        GameObject laser = ship.SpawnLaser();

//        // Spawn asteroid
//        Spawner spawner = game.GetSpawner();
//        GameObject asteroid = spawner.SpawnAsteroid();

//        // Put laser on asteroid
//        laser.transform.position = ship.transform.position;

//        yield return new WaitForSeconds(0.1f);

//        // We have to use the unity Assert.IsNull because Unity deals with nulls differently to normal C#
//        UnityEngine.Assertions.Assert.IsNull(asteroid);


//    }

//}
