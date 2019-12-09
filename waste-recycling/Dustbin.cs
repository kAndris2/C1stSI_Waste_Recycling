using System;

namespace WasteRecycling
{
    public class Dustbin
    {
        public string color;
        public PaperGarbage[] PaperContent;
        public PlasticGarbage[] PlasticContent;
        public Garbage[] HouseWasteContent;

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
                    PlasticGarbage[] myarray = new PlasticGarbage[PlasticContent.Length];
                    Array.Copy(PlasticContent, myarray, PlasticContent.Length);
                    PlasticContent = new PlasticGarbage[myarray.Length + 1];

                    for (int i = 0; i < myarray.Length; i++)
                        PlasticContent[i] = myarray[i];

                    PlasticContent[PlasticContent.Length -1] = (PlasticGarbage)garbage;
                }
                else
                    throw new DustbinContentException("The garbage is doesn't clean!");
            }
            else if (garbage is PaperGarbage)
            {
                if (((PaperGarbage)garbage).Squeezed)
                {
                    PaperGarbage[] myarray = new PaperGarbage[PaperContent.Length];
                    Array.Copy(PaperContent, myarray, PaperContent.Length);
                    PaperContent = new PaperGarbage[myarray.Length + 1];

                    for (int i = 0; i < myarray.Length; i++)
                        PaperContent[i] = myarray[i];

                    PaperContent[PaperContent.Length - 1] = (PaperGarbage)garbage;
                }
                else
                    throw new DustbinContentException("The garbage is doesn't squeezed!");
            }
            else if (garbage is Garbage)
            {
                Garbage[] myarray = new Garbage[HouseWasteContent.Length];
                Array.Copy(HouseWasteContent, myarray, HouseWasteContent.Length);
                HouseWasteContent = new Garbage[myarray.Length + 1];

                for (int i = 0; i < myarray.Length; i++)
                    HouseWasteContent[i] = myarray[i];

                HouseWasteContent[HouseWasteContent.Length - 1] = (Garbage)garbage;
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
