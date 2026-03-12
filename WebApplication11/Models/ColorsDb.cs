namespace WebApplication11.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ColorViewModel
    {
        public List<Color> Colors { get; set; }
    }

    public class ColorsDb
    {

        public List<Color> GetAll()
        {
            return new List<Color>
            {
                new Color{Id = 1, Name = "Red"},
                new Color{Id = 2, Name = "Green"},
                new Color{Id = 3, Name = "Blue"},
                new Color{Id = 4, Name = "Black"},
                new Color{Id = 5, Name = "White"},
                new Color{Id = 6, Name = "Purple"},

            };
        }

        public Color GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }
    }
}
