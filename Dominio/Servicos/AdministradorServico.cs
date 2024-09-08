using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTO;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.DTO;
using minimal_api.Infraestrutura.DB;

namespace minimal_api.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Admistradores.Where(v => v.Id == id).FirstOrDefault();
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Admistradores.Add(administrador);
        _contexto.SaveChanges();

        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Admistradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm; 
    }

    public List<Administrador> Todos(int? pagina)
    {
        var query = _contexto.Admistradores.AsQueryable();
    
        int itensPorPagina = 10;

        if(pagina != null)
        {
            query = query.Skip(((int) pagina - 1) * itensPorPagina).Take(itensPorPagina);
        }
        
        return query.ToList();
    }
    public void Apagar(Administrador administrador)
    {
        _contexto.Admistradores.Remove(administrador);
        _contexto.SaveChanges();
    } 
}