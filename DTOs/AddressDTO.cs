namespace cdf_api_integrador.DTOs;

public record AdressDTO
{
    public string Cep {get;set;} = default!;
    public string Logradouro {get;set;} = default!;
    public string Numero {get;set;} = default!;
    public string Bairro {get;set;} = default!;
    public string Cidade {get;set;} = default!;
    public string Estado {get;set;} = default!;
    public string Complemento {get;set;} = default!;
}