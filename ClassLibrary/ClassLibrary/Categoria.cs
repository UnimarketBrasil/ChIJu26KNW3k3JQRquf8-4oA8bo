namespace ClassLibrary
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Categoria(int id)
        {
            this.Id = id;
        }
        // public Categoria(string nome)
        // {
        //     Nome = nome;
        //  }
    }
}
