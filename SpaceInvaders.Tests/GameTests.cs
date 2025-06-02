using System.Drawing;
using SpaceInvaders.Game;
using SpaceInvaders.Interfaces;
using NUnit.Framework;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SpaceInvaders.Tests;

[TestFixture]
public class GameTests
{
    private Game.Game game;
    private Size gameArea;

    [SetUp]
    public void Setup()
    {
        gameArea = new Size(800, 600);
        game = new Game.Game(gameArea);
    }

    [Test]
    public void Game_Initialization_CreatesCorrectNumberOfEnemies()
    {
        // Act
        var enemies = TestHelpers.GetPrivateField<List<Enemy>>(game, "enemies");

        // Assert
        Assert.That(enemies.Count, Is.EqualTo(55)); // 5 rows * 11 columns
    }

    [Test]
    public void Game_PlayerShoot_CreatesBullet()
    {
        // Arrange
        var bullets = TestHelpers.GetPrivateField<List<Bullet>>(game, "bullets");
        var initialBulletCount = bullets.Count;

        // Act
        game.HandleKeyDown(Keys.Space);

        // Assert
        Assert.That(bullets.Count, Is.EqualTo(initialBulletCount + 1));
    }

    [Test]
    public void Game_BulletHitsEnemy_RemovesEnemyAndIncreasesScore()
    {
        // Arrange
        var enemies = TestHelpers.GetPrivateField<List<Enemy>>(game, "enemies");
        var bullets = TestHelpers.GetPrivateField<List<Bullet>>(game, "bullets");
        var initialEnemyCount = enemies.Count;
        var initialScore = TestHelpers.GetPrivateField<int>(game, "score");

        // Create a bullet at the position of the first enemy
        var enemy = enemies[0];
        bullets.Add(new Bullet(new Point(enemy.Position.X, enemy.Position.Y), true));

        // Act
        game.Update();

        // Assert
        Assert.That(enemies.Count, Is.EqualTo(initialEnemyCount - 1));
        Assert.That(TestHelpers.GetPrivateField<int>(game, "score"), Is.GreaterThan(initialScore));
    }

    [Test]
    public void Game_EnemyReachesBottom_GameOver()
    {
        // Arrange
        var enemies = TestHelpers.GetPrivateField<List<Enemy>>(game, "enemies");
        var enemy = enemies[0];
        enemy.Position = new Point(enemy.Position.X, gameArea.Height - 40);

        // Act
        game.Update();

        // Assert
        Assert.That(TestHelpers.GetPrivateField<bool>(game, "gameOver"), Is.True);
    }

    [Test]
    public void Game_AllEnemiesDestroyed_GameOverAndWin()
    {
        // Arrange
        var enemies = TestHelpers.GetPrivateField<List<Enemy>>(game, "enemies");
        enemies.Clear();

        // Act
        game.Update();

        // Assert
        Assert.That(TestHelpers.GetPrivateField<bool>(game, "gameOver"), Is.True);
    }
} 