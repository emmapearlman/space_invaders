using System.Drawing;
using SpaceInvaders.Game;
using NUnit.Framework;

namespace SpaceInvaders.Tests;

[TestFixture]
public class BulletTests
{
    private Bullet playerBullet;
    private Bullet enemyBullet;
    private Point initialPosition;

    [SetUp]
    public void Setup()
    {
        initialPosition = new Point(400, 300);
        playerBullet = new Bullet(initialPosition, true);
        enemyBullet = new Bullet(initialPosition, false);
    }

    [Test]
    public void PlayerBullet_Update_MovesUp()
    {
        // Act
        playerBullet.Update();

        // Assert
        Assert.That(playerBullet.Position.Y, Is.LessThan(initialPosition.Y));
    }

    [Test]
    public void EnemyBullet_Update_MovesDown()
    {
        // Act
        enemyBullet.Update();

        // Assert
        Assert.That(enemyBullet.Position.Y, Is.GreaterThan(initialPosition.Y));
    }
} 