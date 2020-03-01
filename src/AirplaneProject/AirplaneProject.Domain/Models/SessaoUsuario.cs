using System;

namespace AirplaneProject.Domain.Models
{
	public class SessaoUsuario
    {
        public Int64 Codigo { get; set; }
        public string Chave{ get; set; }

        public SessaoUsuario()
        {

        }

        public SessaoUsuario(string _chave)
        {
            Random aleatorio = new Random();
            aleatorio.Next(100000, 1000000);

            DateTime data = DateTime.Now;
            Int32 numeroData = Convert.ToInt32(data);

            string CodigoTexto = aleatorio.ToString() + numeroData.ToString();
            Codigo = Convert.ToInt64(CodigoTexto);
            Chave = _chave;
        }

        //public Usuario VerificarSessao(ref HttpSessionStateBase _session)
        //{
        //    try
        //    {
        //        string sessao = _session["Codigo"].ToString();
        //        Usuario usuario = new Usuario().BuscarUsuario(sessao);
        //        return usuario;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}