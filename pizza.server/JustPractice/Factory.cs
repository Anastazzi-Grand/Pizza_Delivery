interface Door
{
    public float getWidth();
    public float getHeight();
}

public class WoodenDoor : Door
{
    private float width;
    private float height;

    public WoodenDoor(float width, float height)
    {
        this.width = width;
        this.height = height;
    }

    public float getHeight()
    {
        return this.height;
    }

    public float getWidth()
    {
        return this.width;
    }
}

public class DoorFactory 
{
    public static WoodenDoor MakeDoor(float width, float height)
    {
        return new WoodenDoor(width, height);
    }
}

public class Factory
{
    public static void main(String[] args)
    {
        DoorFactory factory = new DoorFactory();
        //Console.WriteLine(factory.MakeDoor(16, 18));
       
    }
}