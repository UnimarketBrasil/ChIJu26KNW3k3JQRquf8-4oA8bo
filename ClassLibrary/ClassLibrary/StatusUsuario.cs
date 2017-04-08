namespace ClassLibrary
{
    public class StatusUsuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public StatusUsuario(int valor)
        {
            this.Id = valor;
        }
    }
}
