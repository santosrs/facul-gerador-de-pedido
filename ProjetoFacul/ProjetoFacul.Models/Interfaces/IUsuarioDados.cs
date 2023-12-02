using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models.Interfaces
{
    public interface IUsuarioDados:IDados<Usuario>
    {
        Usuario ObterPorEmailSenha(string email, string senha);
    }
}
