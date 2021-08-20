using System.Collections.Generic;

namespace Webapi.Apresentacao
{

  public class HomeView
  {
    public string Mensagem
    {
      get{ return "Olá alunos, bem vindo a minha api!"; }
    }
     public List<string> Endpoints
    {
      get{ 
          return new List<string>()
    {
          "/carros",
          "/modelos"
    }; 
} 
    }
  }
}      