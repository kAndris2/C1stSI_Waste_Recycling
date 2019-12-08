using System;

namespace WasteRecycling
{
    public class Dustbin
    {
        public string color { get; set; }
        public PaperGarbage[] PaperContent { get; set; }
        public PlasticGarbage[] PlasticContent { get; set; }
        public Garbage[] HouseWasteContent { get; set; }

        public Dustbin(string color)
        {
            this.color = color;
            PaperContent = new PaperGarbage[0];
            PlasticContent = new PlasticGarbage[0];
            HouseWasteContent = new Garbage[0];
        }

        public void DisplayContents()
        {
            Console.WriteLine($"{color} Dustbin!");

            Console.WriteLine($"\nHouse waste content: {HouseWasteContent.Length} item(s)\n");
            if (HouseWasteContent.Length > 0)
                foreach (Garbage item in HouseWasteContent)
                    Console.WriteLine($"\t{item.Name}");

            Console.WriteLine($"\nPaper content: {PaperContent.Length} item(s)\n");
            if (PaperContent.Length > 0)
                foreach (PaperGarbage item in PaperContent)
                    Console.WriteLine($"\t{item.Name}");

            Console.WriteLine($"\nPlastic content: {PlasticContent.Length} item(s)\n");
            if (PlasticContent.Length > 0)
                foreach (PlasticGarbage item in PlasticContent)
                    Console.WriteLine($"\t{item.Name}");
        }

        public void ThrowOutGarbage(Garbage garbage)
        {
            if (garbage is PlasticGarbage)
            {
                if (((PlasticGarbage)garbage).Cleaned)
                {
                    PlasticContent = new PlasticGarbage[PlasticContent.Length + 1];
                    PlasticContent[PlasticContent.Length -1] = ((PlasticGarbage)garbage);
                }
                else
                    throw new DustbinContentException("The garbage is doesn't clean!");
            }
            else if (garbage is PaperGarbage)
            {
                if (((PaperGarbage)garbage).Squeezed)
                {
                    PaperContent = new PaperGarbage[PaperContent.Length + 1];
                    PaperContent[PaperContent.Length -1] = ((PaperGarbage)garbage);
                }
                else
                    throw new DustbinContentException("The garbage is doesn't squeezed!");
            }
            else if (garbage is Garbage)
            {
                HouseWasteContent = new Garbage[HouseWasteContent.Length + 1];
                HouseWasteContent[HouseWasteContent.Length -1] = garbage;
            }
            else
                throw new DustbinContentException("Unknown type of garbage!");
        }

        public void EmptyContents()
        {
            HouseWasteContent = new Garbage[0];
            PaperContent = new PaperGarbage[0];
            PlasticContent = new PlasticGarbage[0];
        }
    }
}
