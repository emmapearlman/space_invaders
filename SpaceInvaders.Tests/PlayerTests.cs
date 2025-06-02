using System.Drawing;
using SpaceInvaders.Game;
using NUnit.Framework;
using System.Collections.Generic;

namespace SpaceInvaders.Tests;

[TestFixture]
public class PlayerTests
{
    private Player player;
    private Point initialPosition;

    [SetUp]
    public void Setup()
    {
        initialPosition = new Point(400, 550);
        player = new Player(initialPosition);
    }

    [Test]
    public void Player_MoveLeft_DecreasesXPosition()
    {
        // Arrange
        player.MoveLeft = true;

        // Act
        player.Update();

        // Assert
        Assert.That(player.Position.X, Is.LessThan(initialPosition.X));
    }

    [Test]
    public void Player_MoveRight_IncreasesXPosition()
    {
        // Arrange
        player.MoveRight = true;

        // Act
        player.Update();

        // Assert
        Assert.That(player.Position.X, Is.GreaterThan(initialPosition.X));
    }

    [Test]
    public void Player_Shoot_CreatesBullet()
    {
        // Arrange
        var bullets = new List<Bullet>();

        // Act
        player.Shoot(bullets);

        // Assert
        Assert.That(bullets.Count, Is.EqualTo(1));
        Assert.That(bullets[0].Position.X, Is.EqualTo(player.Position.X + player.Bounds.Width / 2));
    }
} 