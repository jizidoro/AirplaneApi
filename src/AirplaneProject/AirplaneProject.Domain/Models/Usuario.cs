namespace AirplaneProject.Domain.Models
{
	public class Usuario
    {
        public string Chave { get; set; }

        public string Nome { get; set; }

        public Usuario()
        {

        }

        public Usuario(string _Chave)
        {
            Chave = _Chave;
        }

        public Usuario(string _Chave, string _Nome)
        {
            Chave = _Chave;
            Nome = _Nome;
        }

        public Usuario BuscarUsuario(string _chave)
        {
            Usuario usuario = new Usuario(_chave);
            return usuario;
        }
    }
}