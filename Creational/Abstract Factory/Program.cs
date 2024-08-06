using System;

// Abstract products
public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Render();
}

// Abstract factory
public interface IUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete products for Light Theme
public class LightButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Light Button...");
    }
}

public class LightCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Light Checkbox...");
    }
}

// Concrete products for Dark Theme
public class DarkButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Dark Button...");
    }
}

public class DarkCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Dark Checkbox...");
    }
}

// Concrete factories
public class LightThemeFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new LightCheckbox();
    }
}

public class DarkThemeFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new DarkCheckbox();
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        IUIFactory factory;

        // Using Light Theme Factory
        factory = new LightThemeFactory();
        IButton lightButton = factory.CreateButton();
        ICheckbox lightCheckbox = factory.CreateCheckbox();
        lightButton.Render();
        lightCheckbox.Render();

        // Using Dark Theme Factory
        factory = new DarkThemeFactory();
        IButton darkButton = factory.CreateButton();
        ICheckbox darkCheckbox = factory.CreateCheckbox();
        darkButton.Render();
        darkCheckbox.Render();
    }
}
