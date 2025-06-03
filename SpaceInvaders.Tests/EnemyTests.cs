using System.Drawing;
using SpaceInvaders.Game;
using NUnit.Framework;
using System.Collections.Generic;

namespace SpaceInvaders.Tests;

[TestFixture]
public class EnemyTests
{
    private Enemy enemy;
    private Point initialPosition;

    [SetUp]
    public void Setup()
    {
        initialPosition = new Point(50, 50);
        enemy = new Enemy(initialPosition, EnemyType.Small);
    }

    [Test]
    public void Enemy_Update_MovesRight()
    {
        // Act
        enemy.Update();

        // Assert
        Assert.That(enemy.Position.X, Is.GreaterThan(initialPosition.X));
    }

    [Test]
    public void Enemy_ReachesRightBoundary_MovesDownAndChangesDirection()
    {
        // Arrange
        enemy.Position = new Point(770, 50);

        // Act
        enemy.Update();

        // Assert
        Assert.That(enemy.Position.Y, Is.GreaterThan(50));
    }
} 