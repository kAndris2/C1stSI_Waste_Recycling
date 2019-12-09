namespace WasteRecycling
{
    public class PlasticGarbage : Garbage
    {
        public bool Cleaned;

        public PlasticGarbage(string name, bool cleaned) : base(name)
        {
            this.Cleaned = cleaned;
        }

        public void Clean()
        {
            this.Cleaned = true;
        }
    }
}
