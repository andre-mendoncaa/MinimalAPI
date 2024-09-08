using minimal_api.Dominio.Enums;

namespace minimal_api.Dominio.ModelViews;

public record AdministradorLogado
{
    public string Token { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
}