namespace WasteRecycling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Garbage[] rottenTomatoes = new Garbage[3];
            for (int i = 0; i < 3; i++)
                rottenTomatoes[i] = new Garbage("rotten tomato nr." + (i + 1));

            PlasticGarbage milkJug = new PlasticGarbage("plastic milk jug", false);

            Dustbin dustbin = new Dustbin("Jenny's handsome");

            for (int i = 0; i < 3; i++)
                dustbin.ThrowOutGarbage(rottenTomatoes[i]);

            if (!milkJug.Cleaned)
                milkJug.Clean();

            dustbin.ThrowOutGarbage(milkJug);
            dustbin.DisplayContents();
            dustbin.EmptyContents();
        }
    }
}
