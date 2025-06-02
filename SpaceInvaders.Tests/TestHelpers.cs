namespace SpaceInvaders.Tests;

public static class TestHelpers
{
    public static T GetPrivateField<T>(object instance, string fieldName)
    {
        if (instance == null)
            throw new ArgumentNullException(nameof(instance));
        if (string.IsNullOrEmpty(fieldName))
            throw new ArgumentNullException(nameof(fieldName));

        var field = instance.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (field == null)
            throw new ArgumentException($"Field '{fieldName}' not found in type {instance.GetType().Name}");

        var value = field.GetValue(instance);
        if (value == null)
            throw new InvalidOperationException($"Field '{fieldName}' is null");

        return (T)value;
    }

    public static void SetPrivateField(object instance, string fieldName, object value)
    {
        if (instance == null)
            throw new ArgumentNullException(nameof(instance));
        if (string.IsNullOrEmpty(fieldName))
            throw new ArgumentNullException(nameof(fieldName));

        var field = instance.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (field == null)
            throw new ArgumentException($"Field '{fieldName}' not found in type {instance.GetType().Name}");

        field.SetValue(instance, value);
    }
} 