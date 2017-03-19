namespace ClassLibrary
{
    public class TipoUsuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public TipoUsuario(int id)
        {
            this.Id = id;
        }

    }
}
