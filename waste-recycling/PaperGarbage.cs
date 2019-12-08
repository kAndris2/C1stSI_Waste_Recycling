namespace WasteRecycling
{
    public class PaperGarbage : Garbage
    {
        public bool Squeezed { get; set; }

        public PaperGarbage(string name, bool squeezed) : base(name)
        {
            this.Squeezed = squeezed;
        }

        public void Squeeze()
        {
            this.Squeezed = true;
        }
    }
}
